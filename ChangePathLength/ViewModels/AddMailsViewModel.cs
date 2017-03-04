using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace ChangePathLength.ViewModels
{
    [Export(typeof(AddMailsViewModel))]
    public class AddMailsViewModel : Screen
    {
        public string Caption { get; set; }

        public AddMailsViewModel()
        {
            Caption = "This is AddMailsView. . . ";
        }
    }
}
