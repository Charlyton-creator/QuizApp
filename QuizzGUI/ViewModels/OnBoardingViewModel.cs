using QuizzGUI.Models;
using System.Collections.ObjectModel;
using PropertyChanged;
using QuizzGUI.Views;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace QuizzGUI.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class OnBoardingViewModel
    { 
        public ObservableCollection<Boarding> Boardings { get; set; }

        public int PositionIndex { get; set; }

        public string NextButtonText
        {
            get
            {
                if (PositionIndex == Boardings.Count - 1)
                {
                    return "Commencer";
                }else
                {
                    return "Suivant";
                }
            }
        }
        
        public ICommand NextCommand { get; set; }
        public ICommand SkipCommand { get; set; }

        public OnBoardingViewModel()
        {
            Boardings = new ObservableCollection<Boarding>
            {
                new Boarding()
                {
                    ImagePath = "survey.svg",
                    Header = "Booster votre Cerveau!!!",
                    Content = "AAAAAAAA",
                    CarouselItem = new WalkthroughItemPage()
                },
                new Boarding()
                {
                    ImagePath = "awardMedal.svg",
                    Header = "Booster votre Cerveau!!!",
                    Content = "AAAAAAAA",
                    CarouselItem = new WalkthroughItemPage()

                },
                new Boarding()
                {
                    ImagePath = "win.svg",
                    Header = "Booster votre Cerveau!!!",
                    Content = "AAAAAAAA",
                    CarouselItem = new WalkthroughItemPage()
                }
            };
            foreach (var boarding in Boardings)
            {
                boarding.CarouselItem.BindingContext = boarding;
            }
            NextCommand = new Command(Next);
            SkipCommand = new Command(StartWelcomePage);
        }

        private void StartWelcomePage()
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginPage1());
        }

        private void Next(object obj)
        {
            if(PositionIndex < Boardings.Count - 1)
            {
                PositionIndex++;
            }else
            {
                StartWelcomePage();
            }
        }
    }
}
