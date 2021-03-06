using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace QuizzGUI.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage1
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage1" /> class.
        /// </summary>
        public LoginPage1()
        {
            this.InitializeComponent();
        }
    }
}