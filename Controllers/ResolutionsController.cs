using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1_v3.Data;
using Assignment1_v3.Models;
using Assignment1_v3.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Encodings.Web;
namespace Assignment1_v3.Controllers
{
  public class ResolutionsController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IEmailSender _emailSender;


    public ResolutionsController(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IEmailSender emailSender
        )
    {
      _context = context;
      _userManager = userManager;
      _roleManager = roleManager;
      _emailSender = emailSender;
    }

    public async Task<IActionResult> Index(string? sortOrder)
    {
      if (_context.Resolutions == null)
      {
        return NotFound();
      }


      // dynamically updates the Status of the resolution based on # of feedbacks
      var resolutions = await _context.Resolutions
                      .Include(f => f.ApplicationUser)
                      .Include(f => f.Feedbacks)
                      .ToListAsync();

      var rejected = 0;
      var accepted = 0;
      var feedbackTotal = 0;
      foreach (var resolution in resolutions)
      {
        foreach (var feedback in resolution.Feedbacks!)
        {
          feedbackTotal++;
          if (feedback.Message == FeedbackMessage.Accepted)
          {
            accepted++;
          }
          else if (feedback.Message == FeedbackMessage.Rejected)
          {
            rejected++;
          }
        }

        if (feedbackTotal == 0)
        {
          resolution.Status = Status.draft;
        }
        else if (accepted > rejected)
        {
          resolution.Status = Status.accept;
        }
        else if (rejected > accepted)
        {
          resolution.Status = Status.rejected;
        }
        else
        {
          resolution.Status = Status.incomplete;
        }

        await _context.SaveChangesAsync();

        rejected = 0;
        accepted = 0;
        feedbackTotal = 0;
      }


      // allows the table to be filtered by Status and by BoardMember
      ViewData["BoardMemberSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";

      if (resolutions == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Resolutions'  is null.");
      }

      switch (sortOrder)
      {
        case "name_desc":
          resolutions = resolutions.OrderByDescending(s => (s.ApplicationUser!.FirstName + " " + s.ApplicationUser.LastName)).ToList();
          break;
        case "Status":
          resolutions = resolutions.OrderBy(s => s.Status).ToList();
          break;
        case "status_desc":
          resolutions = resolutions.OrderByDescending(s => s.Status).ToList();
          break;
        default:
          resolutions = resolutions.OrderBy(s => (s.ApplicationUser!.FirstName + " " + s.ApplicationUser.LastName)).ToList();
          break;
      }

      return View(resolutions.ToList());
    }


    // GET: Resolutions/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
      if (id == null || _context.Resolutions == null || _context.Resolutions.Include(f => f.Feedbacks) == null)
      {
        return NotFound();
      }

      var resolution = await _context.Resolutions
          .Include(f => f.Feedbacks)
            .ThenInclude(s => s.ApplicationUser)
          .FirstOrDefaultAsync(m => m.ResolutionId == id);
      if (resolution == null)
      {
        return NotFound();
      }
      HttpContext.Session.SetString("ResolutionId", id.ToString()!);
      return View(resolution);
    }

    // GET: Resolutions/Create
    public IActionResult Create()
    {
      string id = _userManager.GetUserId(User);

      if (id == null)
      {
        return Redirect("/Identity/Account/Login");
      }
      ViewData["UserId"] = id;
      ViewData["Status"] = Status.draft;
      return View();
    }

    // POST: Resolutions/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ResolutionId,CreationDate,ResolutionAbstract,Status,UserId")] Resolution resolution)
    {
      if (ModelState.IsValid)
      {
        resolution.ResolutionId = Guid.NewGuid();
        _context.Add(resolution);
        await _context.SaveChangesAsync();
        if (_context.Resolutions.Where(s => s.ResolutionId == resolution.ResolutionId) != null)
        {
          var callbackUrl = $"https://localhost:5000/Resolutions/Details/{resolution.ResolutionId}";
          await _emailSender.SendEmailAsync("comp4976@outlook.com", $"Please send your feedback to a newly created resolution",
                        $"Send your feedback to the resolution <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
        return RedirectToAction(nameof(Index));
      }
      return View(resolution);
    }

    // GET: Resolutions/Edit/5
    [Authorize(Roles = "Member")]
    public async Task<IActionResult> Edit(Guid? id)
    {
      if (_userManager.GetUserId(User) == null)
      {
        return Redirect("/Identity/Account/Login");
      }

      if (id == null || _context.Resolutions == null)
      {
        return NotFound();
      }

      var resolution = await _context.Resolutions.FindAsync(id);

      if (resolution == null)
      {
        return NotFound();
      }

      if (_userManager.GetUserId(User) != resolution.UserId)
      {
        return Forbid();
      }

      if (resolution.Status != Status.draft)
      {
        return Forbid();
      }

      ViewData["Status"] = resolution.Status;
      ViewData["UserId"] = resolution.UserId;
      return View(resolution);
    }

    // POST: Resolutions/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Member")]
    public async Task<IActionResult> Edit(Guid id, [Bind("ResolutionId,CreationDate,ResolutionAbstract,Status,OwnerUserId")] Resolution resolution)
    {
      if (id != resolution.ResolutionId)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(resolution);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!ResolutionExists(resolution.ResolutionId))
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
      ViewData["UserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", resolution.UserId);
      return View(resolution);
    }

    // GET: Resolutions/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
      if (_userManager.GetUserId(User) == null)
      {
        return Redirect("/Identity/Account/Login");
      }

      if (id == null || _context.Resolutions == null)
      {
        return NotFound();
      }

      var resolution = await _context.Resolutions
          .FirstOrDefaultAsync(m => m.ResolutionId == id);
      if (resolution == null)
      {
        return NotFound();
      }

      if (_userManager.GetUserId(User) != resolution.UserId)
      {
        return Forbid();
      }

      if (resolution.Status != Status.draft)
      {
        return Redirect("/Resolutions/Create");
      }

      return View(resolution);
    }

    // POST: Resolutions/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
      if (_context.Resolutions == null)
      {
        return Problem("Entity set 'ApplicationDbContext.Resolutions'  is null.");
      }
      var resolution = await _context.Resolutions.FindAsync(id);
      if (resolution != null)
      {
        _context.Resolutions.Remove(resolution);
      }

      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    // GET: Resolutions/Feedback/5
    public async Task<IActionResult> Feedback(Guid? id)
    {
      if (id == null || _context.Resolutions == null)
      {
        return NotFound();
      }

      var resolution = await _context.Resolutions.FindAsync(id);

      return View(resolution);
    }

    private bool ResolutionExists(Guid id)
    {
      return (_context.Resolutions?.Any(e => e.ResolutionId == id)).GetValueOrDefault();
    }
  }
}
