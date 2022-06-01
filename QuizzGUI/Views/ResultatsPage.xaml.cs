using QuizzGUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzGUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultatsPage : ContentPage
    {
        public ResultatsPage(int score)
        {
            ResultatsPageViewModel resultatsPageViewModel = new ResultatsPageViewModel(score);
            BindingContext = resultatsPageViewModel;
            InitializeComponent();
            
        }
    }
}