using System;
using Staytment.Shared.Demo.ViewModels;

namespace Staytment.Shared.Demo
{
    /// <summary>Interaction logic for BrowserWindow.xaml</summary>
    public partial class BrowserWindow
    {
        public BrowserWindow(string title, string url)
        {
            InitializeComponent();
            var dc = (BrowserModel)DataContext;
            dc.Url = url;
            dc.Title = title;
        }
    }
}
