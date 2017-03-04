using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace ChangePathLength.ViewModels
{
    [Export(typeof(FolderAnsichtViewModel))]
    public class FolderAnsichtViewModel : Screen
    {

        



        private ObservableCollection<FoldersViewModel> _HardDisks;
        public ObservableCollection<FoldersViewModel> HardDisks
        {
            get { return _HardDisks; }
            set
            {
                if (value != _HardDisks)
                {
                    _HardDisks = value;
                    NotifyOfPropertyChange(() => HardDisks);
                    //  isDirty = true;
                }
            }
        }

        public FolderAnsichtViewModel()
        {
            FoldersViewModel CDisk = new FoldersViewModel("C:", null, true);
            FoldersViewModel GDisk = new FoldersViewModel("G:", null, true);
            FoldersViewModel FDisk = new FoldersViewModel("F:", null, true);

            HardDisks = new ObservableCollection<FoldersViewModel>();


            HardDisks.Add(CDisk);
            HardDisks.Add(GDisk);
            HardDisks.Add(FDisk);
            foreach (var item in HardDisks)
            {
                item.GetSubfolders();
            }

        }



    }
}
