using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using Algorytmy_Zaawansowane.Classes;
using System.Globalization;

namespace Algorytmy_Zaawansowane
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        BoxList Boxes = new BoxList();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            List<Box> BoxesTmp;
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                string line = file.ReadToEnd();

                if ((BoxesTmp = InputOutput.InitializeList(line)) == null)
                    MessageBox.Show("Errors in text file");
                else
                {
                    Boxes.DodajPudelka(BoxesTmp);
                    BoxView.ItemsSource = Boxes.ListBox;
                        }
  
            }
        }

        private void save_as_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {

                string filename = dlg.FileName;
            }


        }

        private void _Start_Click(object sender, RoutedEventArgs e)
        {
            if (Boxes.GetBoxNumber() == 0)
                return;
            Boxes.UstawPionowo();

            BoxList A = new BoxList();
            BoxList B = new BoxList();

            A.DodajPudelka(Boxes.GetBoxList());
            B.DodajPudelka(Boxes.GetBoxList());

            A.SortujPudelka(true);
            B.SortujPudelka(false);

            var tmp = Algorithm.NajdluzszyWspolnyPodciag(A.GetBoxList(), B.GetBoxList());
        }
    }
}
