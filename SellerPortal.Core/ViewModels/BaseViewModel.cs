namespace SellerPortal.Core.ViewModels
{
    public abstract class BaseViewModel
    {
        public virtual void OnInit() { }

        public virtual Task OnInitAsync()
        {
            return Task.CompletedTask;
        }
    }
}
