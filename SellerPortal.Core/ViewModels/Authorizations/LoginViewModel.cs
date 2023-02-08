using SellerPortal.Core.Interfaces.Services;
using SellerPortal.Core.Interfaces.ViewModels.Authorizations;
using SellerPortal.Core.Models.Authorizations;

namespace SellerPortal.Core.ViewModels.Authorizations
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        public LoginModel Model { get; private set; } = new LoginModel();

        private readonly IAuthService _authService;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public override void OnInit()
        {
            Model.UserName = "USERNAME";
            Model.Password = "P@ssw0rd";
        }

        public Task LoginAsync()
        {
            // TODO: call authService here
            return Task.CompletedTask;
        }
    }
}
