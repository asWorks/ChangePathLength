using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ChangePathLength.Views
{
    /// <summary>
    /// Interaction logic for FolderAnsichtView.xaml
    /// </summary>
    public partial class FolderAnsichtView : UserControl
    {
        public FolderAnsichtView()
        {
            InitializeComponent();
            //var vModel = new ViewModels.FoldersViewModel("C:\\test", null, true);
            //this.GridTreeView.DataContext = vModel;
        }

        private void GetDataContext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            object dc = this.DataContext;

            Debug.Print(dc.ToString());

        }
    }
}
