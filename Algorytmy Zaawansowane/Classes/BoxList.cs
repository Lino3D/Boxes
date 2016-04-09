using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    public class BoxList
    {
        private List<Box> BoxList = new List<Box>();

        public void DodajPudelka(Box box)
        {
            if (box != null)
                BoxList.Add(box);
        }

        public void DodajPudelka(List<Box> lstbox)
        {
            if (lstbox != null)
                foreach (var item in lstbox)
                    BoxList.Add(item);
        }

        public int GetBoxNumber()
        {
            return BoxList.Count;
        }

        public List<Box> GetBoxList()
        {
            return BoxList;
        }

        public void SortujPudelka(bool SortujPoWysokosci)
        {
            if (SortujPoWysokosci)
                QuicksortHeight(BoxList, 0, BoxList.Count - 1);
            else
                QuicksortWidht(BoxList, 0, BoxList.Count - 1);
        }


        private static void QuicksortHeight(List<Box> elements, int left, int right)
        {
            int i = left, j = right;
            Box pivot = elements.ElementAt((left + right) / 2);

            while (i <= j)
            {
                while (elements.ElementAt(i).Height < pivot.Height)
                    i++;

                while (elements.ElementAt(j).Height > pivot.Height)
                    j--;

                if (i <= j)
                {
                    Box tmp = elements.ElementAt(i);
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
                QuicksortHeight(elements, left, j);
            if (i < right)
                QuicksortHeight(elements, i, right);
        }

        private static void QuicksortWidht(List<Box> elements, int left, int right)
        {
            int i = left, j = right;
            Box pivot = elements.ElementAt((left + right) / 2);

            while (i <= j)
            {
                while (elements.ElementAt(i).Width < pivot.Width)
                    i++;

                while (elements.ElementAt(j).Width > pivot.Width)
                    j--;

                if (i <= j)
                {
                    Box tmp = elements.ElementAt(i);
                    elements[i] = elements[j];
                    elements[j] = tmp;
                    i++;
                    j--;
                }
            }

            if (left < j)
                QuicksortWidht(elements, left, j);
            if (i < right)
                QuicksortWidht(elements, i, right);
        }
    }
}
