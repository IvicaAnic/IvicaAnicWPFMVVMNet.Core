using Microsoft.Extensions.DependencyInjection;

namespace WpfNetCoreMvvm.ViewModels
{
    public class MyViewModelLocator
    {
        public MyViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MyViewModel>();
    }
}
