using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SecondBrain.Data;
using SecondBrain.DTOs.Account;
using SecondBrain.Interfaces;
using SecondBrain.Models;

namespace SecondBrain.Repositories
{
    public class AccountRepository : IAccount
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SecondBrainDataContext _context;

        public AccountRepository(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, SecondBrainDataContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Register(Register model, string RequestMethod, bool isValid)
        {
            if (string.Equals(RequestMethod, "POST", StringComparison.OrdinalIgnoreCase))
            {
                if (isValid)
                {
                    AppUser newUser = new()
                    {
                        Email = model.Email,
                        UserName = model.Email,
                        Name = model.Name
                    };
                    var result = await _userManager.CreateAsync(newUser, model.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(newUser, false);
                        await _context.UserProfile.AddAsync(new UserProfile
                        {
                            IsSuspend = false,
                            UserAccount = _context.Users.Where(x => x.Email == newUser.Email).FirstOrDefault(),
                        });
                        _context.SaveChanges();
                    }
                }
            }
        }

        public async Task<string> SignIn(SignIn model, bool IsValid)
        {
            if (IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    UserProfile User = _context.UserProfile.Include(x => x.UserAccount).Where(x => x.UserAccount.Email == model.Email).FirstOrDefault();
                    return User.Id.ToString();
                }
            }
            return "";
        }
    }
}
