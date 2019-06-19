using System.Linq;
using LambdaForums.Data;
using LambdaForums.Data.Models;
using LambdaForums.Models.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LambdaForums.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager; //Provided by Microsoft.AspNetCore.Identity
        private readonly IApplicationUser _userService;
        private readonly IUpload _uploadService; //To upload profile image to the cloud

        public ProfileController(UserManager<ApplicationUser> userManager, IApplicationUser userService, IUpload uploadService)
        {
            this._userManager = userManager;
            this._userService = userService;
            this._uploadService = uploadService;
        }

        public IActionResult Detail(string id)
        {
            var user = _userService.GetById(id);
            var userRoles = _userManager.GetRolesAsync(user).Result;    

            var model = new ProfileViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRating = user.Rating.ToString(),
                Email = user.Email,
                ProfileImageUrl = user.ProfileImageUrl,
                MemeberSince = user.MemberSince,
                IsAdmin = userRoles.Contains("Admin")
            };

            return View(model);
        }

        public IActionResult Index()
        {
            var profiles = _userService.GetAll()
                .OrderByDescending(user => user.Rating)
                .Select(u => new ProfileViewModel
                {
                    Email = u.Email,
                    ProfileImageUrl = u.ProfileImageUrl,
                    UserRating = u.Rating.ToString(),
                    MemeberSince = u.MemberSince,
                });

            var model = new ProfileListViewModel
            {
                Profiles = profiles
            };

            return View(model);
        }
    }
}