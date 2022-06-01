using Newtonsoft.Json;
using QuizzGUI.Models;
using QuizzGUI.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace QuizzGUI.ViewModels
{
    /// <summary>
    /// ViewModel for no item page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class NoItemPageViewModel : BaseViewModel
    {
        #region Fields

        public NoItem noItem1 { get; set; }

        private Command gobackCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="NoItemPageViewModel" /> class.
        /// </summary>
        public NoItemPageViewModel()
        {
            noItem1 = GetNoItem();
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets the command that is executed when the Go back button is clicked.
        /// </summary>
        public Command GoBackCommand
        {
            get
            {
                return this.gobackCommand ?? (this.gobackCommand = new Command(this.GoBack));
            }
        }

        #endregion

        #region Methods
        public NoItem GetNoItem()
        {
            var assembly = typeof(NoItemPage).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("QuizzGUI.errorAndEmpty.json");

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                NoItem noItem = JsonConvert.DeserializeObject<NoItem>(json);
                noItem1 = noItem;
            }
            return noItem1;
        }

        /// <summary>
        /// Invoked when the Go back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void GoBack(object obj)
        {
            // Do something
        }

        #endregion
    }
}
