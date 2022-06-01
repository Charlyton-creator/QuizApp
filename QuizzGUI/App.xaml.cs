using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using QuizzGUI.Views;
using Xamarin.Essentials;

[assembly: ExportFont("Montserrat-Bold.ttf",Alias="Montserrat-Bold")]
     [assembly: ExportFont("Montserrat-Medium.ttf", Alias = "Montserrat-Medium")]
     [assembly: ExportFont("Montserrat-Regular.ttf", Alias = "Montserrat-Regular")]
     [assembly: ExportFont("Montserrat-SemiBold.ttf", Alias = "Montserrat-SemiBold")]
[assembly: ExportFont("UIFontIcons.ttf", Alias = "FontIcons")]
namespace QuizzGUI
{
    public partial class App : Application
    {
        public static string ImageServerPath { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjMxMjM3QDMyMzAyZTMxMmUzMG1TVXRUSkVWQ0lQeURlMkdkWGdjVFRjcGJBY1YzOUZ2OUQxWW8yTWdwNFU9");
            InitializeComponent();

            MainPage = new NavigationPage(new SplashPage());
        }

        protected override void OnStart()
        {
            VersionTracking.Track();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        { 
        }
    }
}
