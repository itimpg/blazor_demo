using SellerPortal.Core.Models.Authorizations;

namespace SellerPortal.Core.Interfaces.ViewModels.Authorizations
{
    public interface ILoginViewModel : IViewModel
    {
        public LoginModel Model { get; }

        Task LoginAsync();
    }
}
