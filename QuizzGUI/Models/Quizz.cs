using System.Collections.Generic;
using Xamarin.Forms;

namespace QuizzGUI.Models
{
    public class Quizz
    {
        public string Title { get; set; }
        public string Question { get; set; }
        public string Catégorie { get; set; }
        public List<string> Propositions { get; set; }
        public string Answer { get; set; }
        public View CarouselItem { get; set; }
    }
}
