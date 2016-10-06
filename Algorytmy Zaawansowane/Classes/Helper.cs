using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    public static   class Helper
    {
        /// <summary>
        /// Return true if A is greater than B in terms of height
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool CompareHeight(Box A, Box B)
        {
            if (A.Height > B.Height)
                return true;
            else if (A.Height < B.Height)
                return false;
            else if (A.Width > B.Width)
                return true;
            else return false;
        }

        public static bool CompareWidth(Box A, Box B)
        {
            if (A.Width > B.Width)
                return true;
            else if (A.Width < B.Width)
                return false;
            else if (A.Height > B.Height)
                return true;
            else return false;
        }
    }
}
