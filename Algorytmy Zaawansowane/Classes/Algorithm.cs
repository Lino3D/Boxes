using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    public static class Algorithm
    {
        public static ObservableCollection<Box> NajdluzszyWspolnyPodciag( ObservableCollection<Box> A, ObservableCollection<Box> B)
        {
            if( A.Count() != B.Count() )
                throw( new Exception("Ilosc pudelek w obu listach sie nie zgadza"));
            int n = A.Count();
            n++;
            int[,] C = new int[n,n];
            
            for( int i = 0; i < n; i++)
                C[i,0] = 0;
            for( int j = 0; j < n; j++)
                C[0,j] = 0;

            for( int i = 1; i < n; i++)
            {
                for( int j = 1; j < n; j++)
                {
                    if( A.ElementAt(i-1).Equals(B.ElementAt(j-1)))
                        C[i,j] = C[i-1,j-1]+1;
                    else
                        C[i,j] = Math.Max( C[i-1,j], C[i,j-1]);
                }
            }


            return ZnajdzCiag(C, A, B, n);
        }

        private static ObservableCollection<Box> ZnajdzCiag( int[,] tab, ObservableCollection<Box> A, ObservableCollection<Box> B, int n)
        {
            ObservableCollection<Box> ret = new ObservableCollection<Box>();
            int val;
            //for (int i = n - 1; i > 0; i--)
            //    for (int j = n - 1; j > 0; j--)
            //    {
            int i = n - 1;
            int j = n - 1;
            while (!(i == 0 && j == 0))
            {
                val = tab[i, j];
                if (i > 0 && tab[i - 1, j] == val)// && i > 0)
                {
                    //przejdz
                    i--;
                    continue;
                }
                if (j> 0 && tab[i, j - 1] == val )//&& j > 0)
                {
                    //przejdz
                    j--;
                    continue;
                }

                ret.Add(A.ElementAt(i-1));
                if (i > 0)
                    i--;
                if (j > 0)
                    j--;


            }
           //     }



                return ret;
        }


    }
}
