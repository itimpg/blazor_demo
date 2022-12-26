using Microsoft.AspNetCore.Components;

namespace BlazorWasm.Tests
{
    public class FakeNavigationManager : NavigationManager
    {
        public FakeNavigationManager()
        {
            Initialize("https://unit-test.example/", "https://unit-test.example/");
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            NotifyLocationChanged(false);
        }
    }
}
