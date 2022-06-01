using QuizzGUI.Models;
using QuizzGUI.Views;

namespace QuizzGUI.ViewModels
{
    public class ResultatsPageViewModel
    {
        public Resultats resultats { get; set; }
        public ResultatsPageViewModel(int score)
        {
            resultats = getResultats(score);
;            
        }
        public Resultats getResultats(int score)
        {
            resultats = new Resultats();
            if (score > 1000 && score == 2000)
            { 
               resultats = new Resultats()
                {
                    ResultTitle = "Félicitations!!!",
                    Resultanimation = "trophyAnimation.json",
                    ResultText = "Gros Félicitations! Vous avez reussi. Vous avez un Score superieur ou égale à 1000!!",
                    Score = score

                };
            }
            else if (score > 500 && score <= 1000)
            {
                 resultats = new Resultats()
                {
                    ResultTitle = "Pas Mal",
                    Resultanimation = "exams.json",
                    ResultText = "Pas Mal, vous avez un Score Moyen. Perdez pas espoir vous reuissirez une prochaine fois!!",
                    Score = score

                };

            }
            else if(score >= 0 && score <= 500)
            {
                resultats = new Resultats()
                {
                    ResultTitle = "Mauvais Travail",
                    Resultanimation = "feedbackBad.json",
                    ResultText = "Mauvais travail, encore plus d'éfforts, vous avez un Score très bas. Revenez quand vous serez prets",
                    Score = score

                };

            }
            return resultats;
        }
    }
}
