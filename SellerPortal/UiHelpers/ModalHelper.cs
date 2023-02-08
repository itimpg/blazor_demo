using Blazored.Modal;
using Blazored.Modal.Services;
using SellerPortal.Core.Enums;
using SellerPortal.Core.Interfaces.UiHelpers;
using SellerPortal.Shared;

namespace SellerPortal.UiHelpers
{
    public class ModalHelper : IModalHelper
    {
        private readonly IModalService _modalService;

        public ModalHelper(IModalService modalService)
        {
            _modalService = modalService;
        }

        private Task<ModalResult> ShowMessageAsync(string title, string message, ModalTypes modalType)
        {
            var parameters = new ModalParameters()
              .Add(nameof(ModalMessage.Message), message)
              .Add(nameof(ModalMessage.ModalType), modalType);

            var modal = _modalService.Show<ModalMessage>(title, parameters);
            return modal.Result;
        }

        public Task ShowSuccessMessageAsync(string title, string message)
        {
            return ShowMessageAsync(title, message, ModalTypes.Success);
        }

        public Task ShowErrorMessageAsync(string title, string message)
        {
            return ShowMessageAsync(title, message, ModalTypes.Error);
        }

        public Task ShowWarningMessageAsync(string title, string message)
        {
            return ShowMessageAsync(title, message, ModalTypes.Warning);
        }

        public async Task<bool> ShowConfirmationMessageAsync(string title, string message)
        {
            var result = await ShowMessageAsync(title, message, ModalTypes.Confirm);

            return result.Confirmed;
        }
    }
}
