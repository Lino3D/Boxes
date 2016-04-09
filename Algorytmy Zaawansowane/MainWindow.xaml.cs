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
        List<Box> Boxes = new List<Box>();
        char decimalsperator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                System.IO.StreamReader file = new System.IO.StreamReader(filename);
                string line = file.ReadToEnd();
                line = line.Replace('\r', ' ');

                if (decimalsperator == ',') { line = line.Replace('.', ','); }
             

                List<string> stringboxes = line.Split('\n').ToList();
                    
                int x = 5;

                foreach(string s in stringboxes)
                {
                    if (s.Contains("/"))
                    {
                        List<string> stringbox = s.Split('/').ToList();

                        double height;
                        double.TryParse(stringbox[0], out height);

                        double width;
                        double.TryParse(stringbox[1], out width);

                        if (height != 0 & width != 0)
                        {
                            Box box = new Box(height, width);
                            Boxes.Add(box);
                        }
                        else
                        {
                            MessageBox.Show("Errors in text file");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Errors in text file");
                    }
                   
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
    }
}
