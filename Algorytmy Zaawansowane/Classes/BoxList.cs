using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    public class BoxList
    {
        public ObservableCollection<Box> ListBox = new ObservableCollection<Box>();


        public void DodajPudelka(Box box)
        {
            if (box != null)
                ListBox.Add(box);
        }

        public void DodajPudelka(ObservableCollection<Box> lstbox)
        {
            if (lstbox != null)
                foreach (var item in lstbox)
                    ListBox.Add(item);
        }

        public void StworzListeUnused(ObservableCollection<Box> AllBoxes, ObservableCollection<Box> UsedBoxes)
        {
            ListBox.Clear();
            foreach (var item in AllBoxes)
                if (!UsedBoxes.Contains(item))
                    ListBox.Add(item);
        }

        public void CzyscListe()
        {
            ListBox.Clear();
        }

        public int GetBoxNumber()
        {
            return ListBox.Count;
        }

        public ObservableCollection<Box> GetBoxList()
        {
            return ListBox;
        }

        public void SetBoxList( ObservableCollection<Box> val)
        {
            ListBox.Clear();
            foreach (var item in val)
                ListBox.Add(item);
        }

        public void ReorderBoxList()
        {
            ListBox.Reverse();
        }


        public void SortujPudelka(bool SortujPoWysokosci)
        {
            if (SortujPoWysokosci)
                QuicksortHeight(ListBox, 0, ListBox.Count - 1);
            else
                  QuicksortWidht(ListBox, 0, ListBox.Count - 1);
        }

        public void UstawPionowo()
        {
            foreach( var item in ListBox)
                if( item.Height < item.Width)
                {
                    var tmp = item.Height;
                    item.Height = item.Width;
                    item.Width = tmp;
                }
        }
        private static void QuicksortHeight(ObservableCollection<Box> elements, int left, int right)
        {
            int i = left, j = right;
            Box pivot = elements.ElementAt((left + right) / 2);

            while (i <= j)
            {
                while ( Helper.CompareHeight(pivot,elements.ElementAt(i)))// < pivot.Height)
                    i++;

                while (Helper.CompareHeight(elements.ElementAt(j) ,pivot))
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

        private static void QuicksortWidht(ObservableCollection<Box> elements, int left, int right)
        {
            int i = left, j = right;
            Box pivot = elements.ElementAt((left + right) / 2);

            while (i <= j)
            {
                while (Helper.CompareWidth(pivot,elements.ElementAt(i) ))// && !(elements.ElementAt(i).Width == pivot.Width && elements.ElementAt(i).Height > pivot.Height))
                    i++;

                while (Helper.CompareWidth(elements.ElementAt(j) , pivot))// && !(elements.ElementAt(i).Width == pivot.Width && elements.ElementAt(i).Height < pivot.Height))
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


        private static void BubbleSortWidth(ObservableCollection<Box> elements)
        {
            for( int i = 0; i < elements.Count-1; i++)
            {

                var FoundMin = elements.ElementAt(i);
                for( int j = i+1; j< elements.Count; j++)
                {
                    if( elements.ElementAt(j).Width <= FoundMin.Width && !( elements.ElementAt(j).Width == elements.ElementAt(i).Width && elements.ElementAt(j).Height > elements.ElementAt(i).Height) )
                    {
                        var swapindex = j;
                    }
                }

            }
        }
    }
}
