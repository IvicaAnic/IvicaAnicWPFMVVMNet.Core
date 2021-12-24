using System;

namespace WpfNetCoreMvvm.Services
{
    public class MyService : IMyService
    {
        public string GetCurrentDate()
        {
            return DateTime.Now.ToLongDateString();
        }
    }
}
