using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1_v3.Data;
using Assignment1_v3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Assignment1_v3.Controllers
{
  public class FeedbacksController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public FeedbacksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;
    }

    // GET: Feedbacks
    public async Task<IActionResult> Index()
    {
      var applicationDbContext = _context.Feedbacks!.Include(f => f.ApplicationUser).Include(f => f.Resolution);
      return View(await applicationDbContext.ToListAsync());
    }

    // GET: Feedbacks/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null || _context.Feedbacks == null)
      {
        return NotFound();
      }

      var feedback = await _context.Feedbacks
          .Include(f => f.ApplicationUser)
          .Include(f => f.Resolution)
          .FirstOrDefaultAsync(m => m.FeedbackId == id);
      if (feedback == null)
      {
        return NotFound();
      }

      return View(feedback);
    }

    // GET: Feedbacks/Create
    public IActionResult Create()
    {
      string id = _userManager.GetUserId(User);

      if (id == null)
      {
        return Redirect("/Identity/Account/Login");
      }

      ViewData["UserId"] = id;
      ViewData["ResolutionId"] = HttpContext.Session.GetString("ResolutionId");

      return View();
    }

    // POST: Feedbacks/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("FeedbackId,Link,Message,UserId,ResolutionId")] Feedback feedback)
    {
      var requestingUser = await _userManager.GetUserAsync(User);
      var isFeedbackFound = await _context.Feedbacks!.Where(m => (m.UserId == requestingUser.Id && m.ResolutionId == feedback.ResolutionId)).FirstOrDefaultAsync();
      if (isFeedbackFound != null)
      {
        return Forbid();
      }
      if (ModelState.IsValid)
      {
        feedback.FeedbackId = Guid.NewGuid();
        _context.Add(feedback);
        await _context.SaveChangesAsync();
        // return RedirectToAction(nameof(Index));
        return RedirectToAction("Index", "Resolutions");
      }

      return Forbid();
    }

    // GET: Feedbacks/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (_userManager.GetUserId(User) == null)
      {
        return Redirect("/Identity/Account/Login");
      }

      if (_userManager.GetUserId(User) != _context.Feedbacks!.Where(m => m.FeedbackId == id).FirstOrDefault()!.UserId)
      {
        return Forbid();
      }

      if (id == null || _context.Feedbacks == null)
      {
        return NotFound();
      }

      var feedback = await _context.Feedbacks.FindAsync(id);
      if (feedback == null)
      {
        return NotFound();
      }
      ViewData["UserId"] = _userManager.GetUserId(User);
      ViewData["ResolutionId"] = _context.Feedbacks!.Where(m => m.FeedbackId == id).FirstOrDefault()!.ResolutionId;
      return View(feedback);
    }

    // POST: Feedbacks/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("FeedbackId,Link,Message,UserId,ResolutionId")] Feedback feedback)
    {
      if (id != feedback.FeedbackId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(feedback);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!FeedbackExists(feedback.FeedbackId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", feedback.UserId);
      ViewData["ResolutionId"] = new SelectList(_context.Resolutions, "ResolutionId", "ResolutionId", feedback.ResolutionId);
      return View(feedback);
    }

    // GET: Feedbacks/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (_userManager.GetUserId(User) == null)
      {
        return Redirect("/Identity/Account/Login");
      }

      if (_userManager.GetUserId(User) != _context.Feedbacks!.Find(id)!.UserId)
      {
        return Forbid();
      }

      if (id == null || _context.Feedbacks == null)
      {
        return NotFound();
      }

      var feedback = await _context.Feedbacks
          .Include(f => f.ApplicationUser)
          .Include(f => f.Resolution)
          .FirstOrDefaultAsync(m => m.FeedbackId == id);
      if (feedback == null)
      {
        return NotFound();
      }

      return View(feedback);
    }

    // POST: Feedbacks/Delete/5
    [HttpPost, ActionName("Delete")]
    [Authorize(Roles = "Admin")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      if (_context.Feedbacks == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Feedbacks'  is null.");
      }
      var feedback = await _context.Feedbacks.FindAsync(id);
      if (feedback != null)
      {
        _context.Feedbacks.Remove(feedback);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool FeedbackExists(Guid id)
    {
      return (_context.Feedbacks?.Any(e => e.FeedbackId == id)).GetValueOrDefault();
    }
  }
}
