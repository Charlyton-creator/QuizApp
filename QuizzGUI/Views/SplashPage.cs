using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizzGUI.Views
{
    public class SplashPage: ContentPage
    {
        Image SplashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "trophee.png",
                WidthRequest = 100,
                HeightRequest = 100

            };
            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(SplashImage);
            this.BackgroundColor = Color.FromHex("#429de3");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(0.9, 1500, Easing.Linear);
            await SplashImage.ScaleTo(150, 1200, Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new LoginPage1());
        }
    }
}
