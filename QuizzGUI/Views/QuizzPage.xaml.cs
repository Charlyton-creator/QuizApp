using System.Collections.Generic;

using Xamarin.Forms;
using QuizzGUI.Models;
using Xamarin.Forms.Xaml;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;
using System;

namespace QuizzGUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizzPage : ContentPage
    {
        public List<Quizz> Quizzs { get; set; }
        public Command SendAnswerCommand { get; set; }
        public string GoodAnswer { get; set; }
        public int Position { get; set; }

        int Score = 0;

        public string UserAnswer { get; set; }



        private bool isChecked = true;

        public bool IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }



        public QuizzPage(string categorie)
        {
            BindingContext = this;
            InitializeComponent();
            var assembly = typeof(UserPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QuizzGUI.data.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                List<Quizz> quizzes = JsonConvert.DeserializeObject<List<Quizz>>(json);

                Quizzs = new List<Quizz>();

                foreach(var quiz in quizzes)
                {
                    if(quiz.Catégorie == categorie)
                    {
                        Quizzs.Add(quiz);
                    }                         
                }
            }
            if(Quizzs.Count > 0)
            {
                QuizzcarouselView.ItemsSource = Quizzs;
            }
            else
            {

                
            }      
        }

        public int CountQuiz(List<Quizz> quizzs)
        {
            return quizzs.Count;
        }

        private void CheckedChanged_eventAsync(object sender, Syncfusion.XForms.Buttons.CheckedChangedEventArgs e)
        {
            string answer = e.CurrentItem.Text;
            foreach (var quizz in Quizzs)
            {
                string Goodanswer = quizz.Answer;
                string UserAnswer = answer;
                if (UserAnswer == Goodanswer)
                {
                    e.CurrentItem.TextColor = Color.FromHex("#7ED321");

                    e.CurrentItem.CheckedColor = Color.FromHex("#7ED321");

                    Score += 500;
                    App.Current.MainPage.DisplayAlert("Bravo vous avez accumulé  ", Score.ToString()   + "Points!!!", "Ok");
                }
            }

            // To get the selected RadioButton - e.CurrentItem
            // To get the previously selected RadioButton -  e.PreviousItem
        }

        private void SwipeEndEvent(object sender, EventArgs e)
        {
            But.IsEnabled = true;
        }

        private async void End(object sender, EventArgs e)
        {
            
            await App.Current.MainPage.DisplayAlert("Vous venez de terminer ce quizz!", "Et vous avez Accumuler" +     Score, "OK");
            //await App.Current.MainPage.Navigation.PushAsync(new NoItemPage());
            await App.Current.MainPage.Navigation.PushAsync(new ResultatsPage(Score));

        }

    }

}