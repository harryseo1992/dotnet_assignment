using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1_v3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Assignment1_v3.Data.ApplicationDbContext;

namespace Assignment1_v3.Data
{
  public static class ModelBuilderExtensions
  {
    public static void Seed(this ModelBuilder builder)
    {
      var pwd = "P@$$w0rd";
      var passwordHasher = new PasswordHasher<ApplicationUser>();

      // Seed Roles
      var adminRole = new IdentityRole("Admin");
      adminRole.NormalizedName = adminRole.Name.ToUpper();

      var memberRole = new IdentityRole("Member");
      memberRole.NormalizedName = memberRole.Name.ToUpper();

      List<IdentityRole> roles = new List<IdentityRole>() {
                adminRole,
                memberRole
            };

      builder.Entity<IdentityRole>().HasData(roles);


      // Seed Users
      var adminUser = new ApplicationUser
      {
        UserName = "aa@aa.aa",
        Email = "aa@aa.aa",
        EmailConfirmed = true,
        FirstName = "Admin",
        LastName = "Administrator",
      };
      adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
      // adminUser.NormalizedEmail = adminUser.Email.ToUpper();
      adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

      var memberUser = new ApplicationUser
      {
        UserName = "11@11.11",
        Email = "11@11.11",
        EmailConfirmed = true,
        FirstName = "Pat",
        LastName = "John"
      };
      memberUser.NormalizedUserName = memberUser.UserName.ToUpper();
      // memberUser.NormalizedEmail = memberUser.Email.ToUpper();
      memberUser.PasswordHash = passwordHasher.HashPassword(memberUser, pwd);

      var memberUser1 = new ApplicationUser
      {
        UserName = "22@22.22",
        Email = "22@22.22",
        EmailConfirmed = true,
        FirstName = "Sue",
        LastName = "Fox"
      };
      memberUser1.NormalizedUserName = memberUser1.UserName.ToUpper();
      // memberUser1.NormalizedEmail = memberUser1.Email.ToUpper();
      memberUser1.PasswordHash = passwordHasher.HashPassword(memberUser1, pwd);

      var memberUser2 = new ApplicationUser
      {
        UserName = "33@33.33",
        Email = "33@33.33",
        EmailConfirmed = true,
        FirstName = "Bob",
        LastName = "Sims"
      };
      memberUser2.NormalizedUserName = memberUser2.UserName.ToUpper();
      // memberUser2.NormalizedEmail = memberUser2.Email.ToUpper();
      memberUser2.PasswordHash = passwordHasher.HashPassword(memberUser2, pwd);

      var memberUser3 = new ApplicationUser
      {
        UserName = "44@44.44",
        Email = "44@44.44",
        EmailConfirmed = true,
        FirstName = "Eddy",
        LastName = "Glen"
      };
      memberUser3.NormalizedUserName = memberUser3.UserName.ToUpper();
      // memberUser3.NormalizedEmail = memberUser3.Email.ToUpper();
      memberUser3.PasswordHash = passwordHasher.HashPassword(memberUser3, pwd);

      var memberUser4 = new ApplicationUser
      {
        UserName = "comp4976@outlook.com",
        Email = "comp4976@outlook.com",
        EmailConfirmed = false,
        FirstName = "Medhat",
        LastName = "Elmasry"
      };
      memberUser4.NormalizedUserName = memberUser4.UserName.ToUpper();
      // memberUser4.NormalizedEmail = memberUser4.Email.ToUpper();
      memberUser4.PasswordHash = passwordHasher.HashPassword(memberUser4, pwd);


      List<ApplicationUser> users = new List<ApplicationUser>() {
                adminUser,
                memberUser,
                memberUser1,
                memberUser2,
                memberUser3,
                memberUser4
            };

      builder.Entity<ApplicationUser>().HasData(users);

      // Seed UserRoles
      List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[0].Id,
        RoleId = roles.First(q => q.Name == "Admin").Id
      });

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[1].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[2].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[3].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[4].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });

      userRoles.Add(new IdentityUserRole<string>
      {
        UserId = users[5].Id,
        RoleId = roles.First(q => q.Name == "Member").Id
      });

      builder.Entity<IdentityUserRole<string>>().HasData(userRoles);



      List<Resolution> resolutions = new List<Resolution> {
                new Resolution {
                    ResolutionAbstract="Abstract1",
                    Status=Status.draft,
                    UserId = users[1].Id
                },
                new Resolution {
                    ResolutionAbstract="Abstract2",
                    Status=Status.accept,
                    UserId = users[2].Id
                },
                new Resolution {
                    ResolutionAbstract="Abstract3",
                    Status=Status.rejected,
                    UserId = users[3].Id
                },
                new Resolution {
                    ResolutionAbstract="Abstract4",
                    Status=Status.incomplete,
                    UserId = users[4].Id
                }
            };

      builder.Entity<Resolution>().HasData(
          resolutions
      );

      builder.Entity<Feedback>().HasData(
          SeedFeedbacks(users, resolutions)
      );
    }

    public static List<Feedback> SeedFeedbacks(List<ApplicationUser> users, List<Resolution> resolutions)
    {
      List<Feedback> feedbacks = new List<Feedback> {
                new Feedback {
                    Link="www.google.ca",
                    Message=FeedbackMessage.Accepted,
                    UserId=users[1].Id,
                    ResolutionId=resolutions[0].ResolutionId
                },
                new Feedback {
                    Link="www.apple.ca",
                    Message=FeedbackMessage.Rejected,
                    UserId=users[2].Id,
                    ResolutionId=resolutions[1].ResolutionId
                },
                new Feedback {
                    Link="www.microsoft.ca",
                    Message=FeedbackMessage.Accepted,
                    UserId=users[3].Id,
                    ResolutionId=resolutions[2].ResolutionId
                },
                new Feedback {
                    Link="www.amazon.ca",
                    Message=FeedbackMessage.Rejected,
                    UserId=users[4].Id,
                    ResolutionId=resolutions[3].ResolutionId
                }
            };

      return feedbacks;
    }
  }

}