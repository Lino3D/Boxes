﻿using System;
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

    }
}
