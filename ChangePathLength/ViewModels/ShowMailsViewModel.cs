using Caliburn.Micro;
using ChangePathLength.Models;
using ChangePathLength.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace ChangePathLength.ViewModels
{
    [Export(typeof(ShowMailsViewModel))]
    public class ShowMailsViewModel : Screen

    {
        private ObservableCollection<MailFile> _Mails;
        public ObservableCollection<MailFile> Mails
        {
            get { return _Mails; }
            set
            {
                if (value != _Mails)
                {
                    _Mails = value;
                    MailsCount = _Mails.Count;

                    NotifyOfPropertyChange(() => Mails);
                    //  isDirty = true;
                }
            }
        }


        private int _MailsCount;
        public int MailsCount
        {
            get { return _MailsCount; }
            set
            {
                if (value != _MailsCount)
                {
                    _MailsCount = value;
                    NotifyOfPropertyChange(() => MailsCount);
                    //  isDirty = true;
                }
            }
        }




        public void LookForFiles()
        {
            var parsemails = new ParseFolders();
            parsemails.LookForMailFolder("C:\\test\\MT1");

            List<MailFile> GetMails = parsemails.Mails;


            if (GetMails.Count > 0)
            {
                Mails = new ObservableCollection<MailFile>(GetMails);
            }

        }

        public void TestAddFile()
        {
            Mails.Add(new MailFile { Mailname = "Mail Nr. 2", MailPath = "Test_Test_TestTest_Test_TestTest_Test_TestTest_Test_Test", PathLength = 241 });
            NotifyOfPropertyChange(() => Mails);


        }



        public ShowMailsViewModel()
        {

            //Mails = new ObservableCollection<MailFile> { new MailFile { Mailname = "Mail Nr. 1", MailPath = "Test_Test_TestTest_Test_TestTest_Test_TestTest_Test_Test", PathLength = 241 } };
            //Mails.Add(new MailFile { Mailname = "Mail Nr. 2", MailPath = "Test_Test_TestTest_Test_TestTest_Test_TestTest_Test_Test", PathLength = 241 });

            LookForFiles();



        }
    }

}
