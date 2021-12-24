using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Extensions.Options;
using ReaderSample;
using System.Collections.Generic;
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

        private string output1;
        public string Output1
        {
            get => output1;            
             set => Set(ref output1, value);
            
        }
        private string myoutput2;
        public string myOutput2
        {
            get => myoutput2;
            set
            {
                myoutput2 = value;
                RaisePropertyChanged(nameof(myOutput2));
            }
                
               
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

        private async Task<Task> ExecuteAsync()
        {
            Debug.WriteLine($"Current value: {input}");

            // List<string> mylist

            int i = 0;
            await foreach (var dataPoint in Ivica_Anic_JSONReader.ReadJSONFile())
            {
                if (i == 0)
                    Output1 = dataPoint;
                else if (i == 1)
                {
                    myOutput2 = dataPoint;
                   
                }
                i = i + 1;
            }


            return Task.CompletedTask;
        }
    }
}
