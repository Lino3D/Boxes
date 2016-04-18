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
        BoxList UnusedBoxes = new BoxList();
        int spacingLeft = 0;
        int spacingTop = 0;
        bool IsCalculated = false;
      
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
                    Boxes.CzyscListe();
                    Boxes.DodajPudelka(BoxesTmp);
                    Boxes.UstawPionowo();
                    BoxView.ItemsSource = Boxes.ListBox;
                   
                    fillCanvas();
                    IsCalculated = false;
                 


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
            if (IsCalculated)
                return;
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
            UnusedBoxes.StworzListeUnused(Boxes.GetBoxList(), tmp);
            Boxes.SetBoxList(tmp);
            Boxes.ReorderBoxList();
            BoxView.ItemsSource = Boxes.ListBox;
            reDrawAll();
            IsCalculated = true;
            
        }
        private void fillCanvas()
        {
            int maxHeight = 0;
            int maxWidth = 0;


            foreach (Box box in Boxes.ListBox)
            {
                Rectangle r = new Rectangle();
                r.Height = box.Height * 4;
                r.Width = box.Width * 4;
                r.Stroke = Brushes.Black;
                r.StrokeThickness = 2;

                if (r.Height > maxHeight)
                    maxHeight = (int)r.Height;
                if (r.Width > maxWidth)
                    maxWidth = (int)r.Width;
                if (spacingLeft+maxWidth > Main.Width)
                {
                    spacingLeft = 0;
                    spacingTop = maxHeight + 10;
                }
                Canvas.SetLeft(r, spacingLeft);
                spacingLeft += (int)(r.Width + 10);
                Canvas.SetTop(r, spacingTop);
                MyCanvas.Children.Add(r);
            }
        }

        private void Main_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            reDrawAll();
        }
        public void reDrawAll()
        {
            spacingLeft = 0;
            spacingTop = 0;
            MyCanvas.Children.Clear();
            fillCanvas();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            OpisWejsciaWyjsciaWindow IODescription = new OpisWejsciaWyjsciaWindow();
            IODescription.ShowDialog();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
