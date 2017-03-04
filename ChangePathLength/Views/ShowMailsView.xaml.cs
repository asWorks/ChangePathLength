using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ChangePathLength.Views
{
    /// <summary>
    /// Interaction logic for ShowMailsView.xaml
    /// </summary>
    public partial class ShowMailsView : UserControl
    {
        ListBox dragSource = null;

        public ShowMailsView()
        {
            InitializeComponent();
        }

        private void listBox_Drop(object sender, DragEventArgs e)
        {

        }

        private void listBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //ListBox parent = sender as ListBox;
            //FileClass data = GetObjectDataFromPoint(parent, e.GetPosition(parent)) as FileClass;
            //if (data != null)
            //{
            //    DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            //}


        }





        private static object GetDataFromListBox(ListBox source, Point point)
        {
            UIElement element = source.InputHitTest(point) as UIElement;
            if (element != null)
            {
                object data = DependencyProperty.UnsetValue;
                while (data == DependencyProperty.UnsetValue)
                {
                    data = source.ItemContainerGenerator.ItemFromContainer(element);
                    if (data == DependencyProperty.UnsetValue)
                    {
                        element = VisualTreeHelper.GetParent(element) as UIElement;
                    }
                    if (element == source)
                    {
                        return null;
                    }
                }
                if (data != DependencyProperty.UnsetValue)
                {
                    return data;
                }
            }
            return null;
        }

        private void listBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ListBox parent = (ListBox)sender;
            dragSource = parent;
            object data = GetDataFromListBox(dragSource, e.GetPosition(parent));

            if (data != null)
            {
                DragDrop.DoDragDrop(parent, data, DragDropEffects.Move);
            }
        }
    }
}
