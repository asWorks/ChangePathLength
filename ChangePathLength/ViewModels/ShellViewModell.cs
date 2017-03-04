using Caliburn.Micro;
using ChangePathLength.Interfaces;
using System;
using System.ComponentModel.Composition;
using System.Windows.Threading;

namespace ChangePathLength.ViewModels
{
    [Export(typeof(IShellViewModel))]
    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive, IShellViewModel, IHandle<Events.EventMessage>
    {

        //  public ShowMailsViewModel MailsViewModel;
        private readonly IEventAggregator _events;

        private DispatcherTimer ti;




        private string _CurrentTime;
        public string CurrentTime
        {
            get { return _CurrentTime; }
            set
            {
                if (value != _CurrentTime)
                {
                    _CurrentTime = value;
                    NotifyOfPropertyChange(() => CurrentTime);
                    //  isDirty = true;
                }
            }
        }

        private ShowMailsViewModel _MailsViewModel;
        public ShowMailsViewModel MailsViewModel
        {
            get { return _MailsViewModel; }
            set
            {
                if (value != _MailsViewModel)
                {
                    _MailsViewModel = value;
                    NotifyOfPropertyChange(() => MailsViewModel);
                    //  isDirty = true;
                }
            }
        }


        private FolderAnsichtViewModel _FolderAnsichtVModel;
        public FolderAnsichtViewModel FolderAnsichtVModel
        {
            get { return _FolderAnsichtVModel; }
            set
            {
                if (value != _FolderAnsichtVModel)
                {
                    _FolderAnsichtVModel = value;
                    NotifyOfPropertyChange(() => FolderAnsichtVModel);
                    //  isDirty = true;
                }
            }
        }

        AddMailsViewModel AddMailsVModel;

        [ImportingConstructor]
        public ShellViewModel(ShowMailsViewModel MailsVModel, FolderAnsichtViewModel FolderAnsichtVM, AddMailsViewModel AddMailsVM, IEventAggregator Events)
        {

            _events = Events;

            MailsViewModel = MailsVModel;
            FolderAnsichtVModel = FolderAnsichtVM;
            AddMailsVModel = AddMailsVM;
            //ToDo
            CurrentTime = DateTime.Now.ToLongTimeString();
            ti = new DispatcherTimer();
            ti.Tick += Ti_Tick;
            ti.Interval = new TimeSpan(0, 0, 0, 0, 500);
            ti.Start();

        }

        private void Ti_Tick(object sender, EventArgs e)
        {
            CurrentTime = DateTime.Now.ToLongTimeString();
        }

        public ShellViewModel()
        {

        }

        public void RunParsing()
        {
            ActivateItem(MailsViewModel);
            //MailsViewModel.LookForFiles();
        }

        public void TestBinding()
        {
            ActivateItem(FolderAnsichtVModel);
        }

        public void ShowAddMails()
        {
            ActivateItem(AddMailsVModel);
        }

        public void TestAddFile()
        {
            MailsViewModel.TestAddFile();
        }

        public void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToLongTimeString();
        }

        public void Handle(Events.EventMessage message)
        {
            throw new NotImplementedException();
        }



    }






}
