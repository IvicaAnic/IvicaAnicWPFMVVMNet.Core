using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading.Tasks;
using WpfNetCoreMvvm.Models;
using WpfNetCoreMvvm.Services;

namespace WpfNetCoreMvvm.ViewModels
{
    public class MyViewModel : ViewModelBase
    {
        private string input="Ivica Anic";
        public string Input
        {
            get => input;
            set => Set(ref input, value);
        }

        private readonly IMyService sampleService;
        private readonly AppSettings settings;

        public RelayCommand ExecuteCommand { get; }

        public MyViewModel(IMyService sampleService,
            IOptions<AppSettings> options)
        {
            this.sampleService = sampleService;
            settings = options.Value;

            ExecuteCommand = new RelayCommand(async () => await ExecuteAsync());
        }

        private Task ExecuteAsync()
        {
            Debug.WriteLine($"Current value: {input}");
            return Task.CompletedTask;
        }
    }
}
