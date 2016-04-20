using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Algorytmy_Zaawansowane.Classes
{
    public static class InputOutput
    {

        public static ObservableCollection<Box> InitializeList(string line)
        {
            char decimalsperator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            ObservableCollection<Box> Boxes = new ObservableCollection<Box>();
            line = line.Replace('\r', ' ');
            if (decimalsperator == ',') { line = line.Replace('.', ','); }
            List<string> stringboxes = line.Split('\n').ToList();
            foreach (string s in stringboxes)
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
                        return null;
                    }
                }
            }
            return Boxes;
        }
  
    }
}
