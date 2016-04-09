using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy_Zaawansowane.Classes
{
    public static class Algorithm
    {
        public static int[,] NajdluzszyWspolnyPodciag( List<Box> A, List<Box> B)
        {
            if( A.Count() != B.Count() )
                throw( new Exception("Ilosc pudelek w obu listach sie nie zgadza"));
            int n = A.Count();
            int[,] C = new int[n,n];
            
            for( int i = 0; i < n; i++)
                C[i,0] = 0;
            for( int j = 0; j < n; j++)
                C[0,j] = 0;

            for( int i = 1; i < n; i++)
            {
                for( int j = 1; j < n; j++)
                {
                    if( A.ElementAt(i).Equals(B.ElementAt(j)))
                        C[i,j] = C[i-1,j-1]+1;
                    else
                        C[i,j] = Math.Max( C[i-1,j], C[i,j-1]);
                }
            }

            return C;
        }


    }
}
