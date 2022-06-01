using Newtonsoft.Json;
using QuizzGUI.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Xamarin.Forms;

using Xamarin.Forms.Xaml;
using QuizzGUI.ViewModels;

namespace QuizzGUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public ObservableCollection<QuizzCat> QuizzCatList { get; set; }
        public UserPage()
        {
            BindingContext = this;
            InitializeComponent();
            var assembly = typeof(UserPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QuizzGUI.categories.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<QuizzCat> quizzCats = JsonConvert.DeserializeObject<List<QuizzCat>>(json);

                QuizzCatList = new ObservableCollection<QuizzCat>(quizzCats);
            }
            CatList.ItemsSource = QuizzCatList;
        }

        private async void OnItemSelected(Object sender,ItemTappedEventArgs e)
        {
                var quizz = e.Item as QuizzCat;
                await App.Current.MainPage.Navigation.PushAsync(new QuizzPage(quizz.categorie));
            
           

        }
    }
}