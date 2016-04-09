using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    class Box
    {
        private double boxHeight { get; set; }
        private double boxWidth { get; set; }

        public double Height
        {
            get
            {
                return boxHeight;
            }
            set
            {
                boxHeight = value;
            }
        }
        public double Width
        {
            get
            {
                return boxWidth;
            }
            set
            {
                boxWidth = value;
            }
        }
        public Box(double a, double b)
        {
            boxHeight = a;
            boxWidth = b;
        }
        public Box()
        {
            boxHeight = 0;
            boxWidth = 0;
        }


        public override bool Equals(System.Object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Box p = obj as Box;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return (boxHeight == p.boxHeight) && (boxWidth == p.boxWidth);
        }
    }
}
