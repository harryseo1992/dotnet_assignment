using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_v3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Assignment1_v3.Controllers
{
    public class UserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
              var users = await _userManager.Users.ToListAsync();
              var userRolesViewModel = new List<UserRolesViewModel>();
              foreach (ApplicationUser user in users)
              {
                var thisViewModel = new UserRolesViewModel();
                thisViewModel.UserId = user.Id;
                thisViewModel.Email = user.Email;
                thisViewModel.FirstName = user.FirstName;
                thisViewModel.LastName = user.LastName;
                thisViewModel.Roles = new List<string>(await _userManager.GetRolesAsync(user));
                userRolesViewModel.Add(thisViewModel);
              }
              return View(userRolesViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string roleName)
        {
            var roleExistsAlready = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExistsAlready)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string roleId)
        {
            if (roleId == null || _roleManager.Roles == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(roleId);
            ViewBag.roleName = role.Name;
            ViewBag.roleId = roleId;
            if (role == null)
            {
                return NotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string roleId)
        {
            if (_roleManager.Roles == null)
            {
                return Problem("Cannot find any roles");
            }
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role != null && role.Name != "Admin")
            {
                await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Manage(string userId)
        {
            ViewBag.userId = userId;
            var userInQuestion = await _userManager.FindByIdAsync(userId);
            if (userInQuestion == null)
            {
                return NotFound($"User with Id: {userId} not found");
            }
            ViewBag.UserName = userInQuestion.UserName;
            var manageUserRolesViewModel = new List<ManageUserRolesViewModel>();
            foreach (var role in _roleManager.Roles.ToArray())
            {
                var userRolesViewModel = new ManageUserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(userInQuestion, role.Name))
                {
                    userRolesViewModel.Selected = true;
                } else 
                {
                    userRolesViewModel.Selected = false;
                }
                manageUserRolesViewModel.Add(userRolesViewModel);
            }
            return View(manageUserRolesViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(List<ManageUserRolesViewModel> manageUserRolesViewModels, string userId)
        {
            var userInQuestion = await _userManager.FindByIdAsync(userId);
            if (userInQuestion == null)
            {
                return View();
            }
            var rolesForUserInQuestion = await _userManager.GetRolesAsync(userInQuestion);
            var result = await _userManager.RemoveFromRolesAsync(userInQuestion, rolesForUserInQuestion);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user from current role");
                return View(manageUserRolesViewModels);
            }
            result = await _userManager.AddToRolesAsync(
                userInQuestion, 
                manageUserRolesViewModels
                    .Where(obj => obj.Selected)
                    .Select(role => role.RoleName)
            );
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected role to user in question");
                return View(manageUserRolesViewModels);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}