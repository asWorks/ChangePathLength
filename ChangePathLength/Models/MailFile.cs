using System.Windows.Media;

namespace ChangePathLength.Models
{
    public class MailFile
    {
        public string Mailname { get; set; }
        public string MailPath { get; set; }
        public int PathLength { get; set; }

        public Brush BackGround { get; set; }

        public override string ToString()
        {
            return Mailname;
        }


    }
}
