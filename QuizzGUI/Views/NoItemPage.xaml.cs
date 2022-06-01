using QuizzGUI.ViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace QuizzGUI.Views
{
    /// <summary>
    /// Page to show the no item
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoItemPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoItemPage" /> class.
        /// </summary>
        public NoItemPage()
        {
            NoItemPageViewModel noItemPageViewModel = new NoItemPageViewModel();
            BindingContext = noItemPageViewModel;
            InitializeComponent();
            
        }
    }
}