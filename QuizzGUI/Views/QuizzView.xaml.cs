using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizzGUI.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzGUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizzView : ContentView
    {
        public QuizzView()
        {
            InitializeComponent();
        }
    }
}