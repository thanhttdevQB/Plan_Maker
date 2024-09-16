using SecondBrain.DTOs.Account;

namespace SecondBrain.Interfaces
{
    public interface IAccount
    {
        public Task Register(Register model, string RequestMethod, bool IsValid);
        public Task<string> SignIn(SignIn model, bool IsValid);
        public Task Logout();
    }
}
