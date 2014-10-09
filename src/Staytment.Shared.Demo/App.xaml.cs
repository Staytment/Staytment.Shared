using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Staytment.Shared.Demo.Authentication;

using Settings = Staytment.Shared.Demo.Properties.Settings;

namespace Staytment.Shared.Demo
{
    /// <summary>Interaction logic for App.xaml</summary>
    public partial class App : Application
    {
        protected async override void OnStartup(StartupEventArgs e)
        {
            var token = Settings.Default.ApiToken;
            if (string.IsNullOrWhiteSpace(token))
            {
                // TODO: GUI for auth selection
                var t = await new GoogleAuth().RequestToken();
                if (string.IsNullOrWhiteSpace(t))
                {
                    Debugger.Break(); // User cancelled
                    return;
                }
                Settings.Default.ApiToken = t;
                Settings.Default.Save();
            }
            base.OnStartup(e);
        }
    }
}
