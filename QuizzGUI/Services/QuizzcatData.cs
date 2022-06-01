using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace QuizzGUI.Services
{
    public interface QuizzcatData<T>
    {
        Task<ObservableCollection<T>> GetQuizzCategorieAsync();
    }
}
