namespace SellerPortal.Core.Interfaces.UiHelpers
{
    public interface IModalHelper
    {
        Task ShowSuccessMessageAsync(string title, string message);
        Task ShowErrorMessageAsync(string title, string message);
        Task ShowWarningMessageAsync(string title, string message);
        Task<bool> ShowConfirmationMessageAsync(string title, string message);
    }
}
