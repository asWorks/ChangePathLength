using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows;

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

        public void CopyPath()
        {
            Clipboard.SetData(DataFormats.Text, SelectetItemSubDC??"IsNull");
        }

        public FolderAnsichtViewModel()
        {
            FoldersViewModel CDisk = new FoldersViewModel("C:", null, true);
            CDisk.ParentViewModel = this;
            FoldersViewModel GDisk = new FoldersViewModel("G:", null, true);
            GDisk.ParentViewModel = this;
            FoldersViewModel FDisk = new FoldersViewModel("F:", null, true);
            FDisk.ParentViewModel = this;

            HardDisks = new ObservableCollection<FoldersViewModel>();


            HardDisks.Add(CDisk);
            HardDisks.Add(GDisk);
            HardDisks.Add(FDisk);
            foreach (var item in HardDisks)
            {
                item.GetSubfolders();
            }

        }




        private string _SelectetItemSubDC;
        public string SelectetItemSubDC
        {
            get { return _SelectetItemSubDC; }
            set
            {
                if (value != _SelectetItemSubDC)
                {
                    _SelectetItemSubDC = value;
                    NotifyOfPropertyChange(() => SelectetItemSubDC);
                    //  isDirty = true;
                }
            }
        }


    }
}
