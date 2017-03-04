using ChangePathLength.Models;
using Delimon.Win32.IO;
using System.Collections.Generic;
using System.Windows.Media;

namespace ChangePathLength.Services
{
    public class ParseFolders
    {
        public List<MailFile> Mails = new List<MailFile>();
        public List<string> Dirs = new List<string>();


        public void LookForMailFolder(string StartFolder)
        {

            var sFolder = new DirectoryInfo(StartFolder);

            foreach (var item in sFolder.GetDirectories())
            {
                Dirs.Add(item.FullName);

                if (item.Name.ToLowerInvariant().Contains("mail"))
                {



                    foreach (var fi in item.GetFiles())
                    {


                        var mf = new MailFile();
                        mf.Mailname = fi.Name;
                        mf.MailPath = fi.FullName;
                        mf.PathLength = fi.FullName.Length;
                        if (mf.PathLength > 200)
                        {
                            mf.BackGround = new SolidColorBrush(Colors.LightSalmon);

                        }
                        else
                        {
                            mf.BackGround = new SolidColorBrush(Colors.LightGreen);
                        }
                        Mails.Add(mf);


                    }


                }
                LookForMailFolder(item.FullName.ToString());


            }














        }


        public void ParseFolderStructure(string startfolder)
        {
            
        }
    }
}

