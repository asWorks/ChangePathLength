using OutlookToolsLib;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ChangePathLength.Views
{
    /// <summary>
    /// Interaction logic for AddMailsView.xaml
    /// </summary>
    public partial class AddMailsView : UserControl
    {
        public AddMailsView()
        {
            InitializeComponent();
        }







        private void Ellipse_Drop(object sender, DragEventArgs e)
        {


            OutlookDataObject dataObject = new OutlookDataObject(e.Data);
            //get the names and data streams of the files dropped
            string[] filenames = (string[])dataObject.GetData("FileGroupDescriptorW");
            MemoryStream[] filestreams = (MemoryStream[])dataObject.GetData("FileContents");

            string buffer = string.Empty;

            label1.Content += "Files:\n";
            for (int fileIndex = 0; fileIndex < filenames.Length; fileIndex++)
            {
                //use the fileindex to get the name and data stream
                string filename = filenames[fileIndex];
                MemoryStream filestream = filestreams[fileIndex];
                label1.Content += "    " + filename + "\n";

                //save the file stream using its name to the application path
                FileStream outputStream = File.Create(filename);
                filestream.WriteTo(outputStream);
                outputStream.Close();
            }


            



        }

        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {


            label1.Content = "Formats:\n";
            foreach (string format in e.Data.GetFormats())
            {
                label1.Content += "    " + format + "\n";
            }

            //ensure FileGroupDescriptor is present before allowing drop
            if (e.Data.GetDataPresent("FileGroupDescriptor"))
            {
                e.Effects = DragDropEffects.All;
            }
        }

    }
}

