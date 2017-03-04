﻿using Caliburn.Micro;
using ChangePathLength.Models;
using Delimon.Win32.IO;
using System.Collections.ObjectModel;

namespace ChangePathLength.ViewModels
{
    public class FoldersViewModel : PropertyChangedBase
    {

        //bool hasSubFolders;
        //string FolderShortName;
        //string FolderFullPath;
        DirectoryInfo di;

        bool isLazyLoading;

        private string _Folderbezeichnung;
        public string Folderbezeichnung
        {
            get { return _Folderbezeichnung; }
            set
            {
                if (value != _Folderbezeichnung)
                {
                    _Folderbezeichnung = value;
                    NotifyOfPropertyChange(() => Folderbezeichnung);
                    //  isDirty = true;
                }
            }
        }

        private Folder _FolderName;
        public Folder FolderName
        {
            get { return _FolderName; }
            set
            {
                if (value != _FolderName)
                {
                    _FolderName = value;
                    Folderbezeichnung = FolderName.FolderName;
                    NotifyOfPropertyChange(() => FolderName);
                    //  isDirty = true;
                }
            }
        }


        private ObservableCollection<FoldersViewModel> _SubFolders;
        public ObservableCollection<FoldersViewModel> SubFolders
        {
            get
            {
                if (_SubFolders == null)
                {
                    _SubFolders = new ObservableCollection<FoldersViewModel>();
                }
                return _SubFolders;
            }
            set
            {
                if (value != _SubFolders)
                {
                    _SubFolders = value;
                    NotifyOfPropertyChange(() => SubFolders);
                    //  isDirty = true;
                }
            }
        }


        private FoldersViewModel _Parent;
        public FoldersViewModel Parent
        {
            get { return _Parent; }
            set
            {
                if (value != _Parent)
                {
                    _Parent = value;
                    NotifyOfPropertyChange(() => Parent);
                    //  isDirty = true;
                }
            }
        }

        FoldersViewModel DummyChild;


        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    if (value)
                    {


                        if (SubFolders.Contains(DummyChild))
                        {

                            GetSubfolders();

                        }


                    }
                    NotifyOfPropertyChange(() => IsExpanded);
                    //  isDirty = true;
                }
            }
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    if (value)
                    {
                        if (SubFolders.Contains(DummyChild))
                        {
                            
                            GetSubfolders();

                        }
                    }
                    _isSelected = value;
                    NotifyOfPropertyChange(() => IsSelected);
                    //  isDirty = true;
                }
            }
        }



        private string _TestVModel;
        public string TestVModel
        {
            get { return _TestVModel; }
            set
            {
                if (value != _TestVModel)
                {
                    _TestVModel = value;
                    NotifyOfPropertyChange(() => TestVModel);
                    //  isDirty = true;
                }
            }
        }
        public FoldersViewModel()
        {
            //FolderName = new Folder("C:");
            //GetSubfolders();
        }



        public FoldersViewModel(string Startfolder, FoldersViewModel parent, bool LoadLazy)
        {
            // FolderName = new Folder(Startfolder);
            di = new DirectoryInfo(Startfolder);

            
            Folderbezeichnung = di.Name;
            Parent = parent;
            TestVModel = Folderbezeichnung;
            isLazyLoading = LoadLazy;
            if (LoadLazy)
            {
                if (di.GetDirectories().Length > 0)
                {
                    DummyChild = new FoldersViewModel();
                    DummyChild.Folderbezeichnung = "...";

                    SubFolders.Add(DummyChild);
                }
                
            }
            else
            {
                GetSubfolders();
            }

            // IsExpanded = true;
            
        }

        public void GetSubfolders()
        {
            if (di == null)
            {
                di = new DirectoryInfo(FolderName.FolderName);
            }
            
            var sFolders = di.GetDirectories();
            if (sFolders.Length > 0)
            {
                if (!SubFolders.Contains(DummyChild))
                {
                    return;
                }
                else
                {
                    SubFolders.Remove(DummyChild);
                }

            }

            foreach (var item in sFolders)
            {
                try
                {
                    var f = new FoldersViewModel(item.FullName, this, isLazyLoading);
                    
                    SubFolders.Add(f);
                }
                catch (System.Exception)
                {


                }
                
            }

            di = null;
        }



    }
}
