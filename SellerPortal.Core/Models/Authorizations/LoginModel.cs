using System.ComponentModel.DataAnnotations;

namespace SellerPortal.Core.Models.Authorizations
{
    public class LoginModel
    {
        [Required(
            ErrorMessageResourceType = typeof(Resources.App),
            ErrorMessageResourceName = nameof(Resources.App.LoginPage_LabelUsernameRequired))]
        public string UserName { get; set; } = string.Empty;

        [Required(
            ErrorMessageResourceType = typeof(Resources.App),
            ErrorMessageResourceName = nameof(Resources.App.LoginPage_LabelPasswordRequired))]
        public string Password { get; set; } = string.Empty;
    }
}
