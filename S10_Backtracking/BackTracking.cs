using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_Backtracking
{
    internal class BackTracking
    {
        public static void Imprimir(int[,] a)
        {
            Console.WriteLine();
            for(int fil = 0; fil < a.GetLength(0); fil++)
            {
                for (int col = 0; col < a.GetLength(1); col++)
                    Console.Write(a[fil, col] + ",");
                Console.WriteLine();
            }
        }
        public static bool RestriccionSudoku(int[,] a, int fila,  int col,int value)
        {
            for(int i = 0; i < a.GetLength(0); i++)//fila
            {
                if (a[fila, i] == value) return false;
            }
            for (int i = 0; i < a.GetLength(1); i++)//fila
            {
                if (a[i, col] == value) return false;
            }
            int filAux = fila - fila % 3;
            int colAux = col-col % 3;
            //averiguar en el cuadrado del sudoku
            for (int i = 0; i <3; i++)//fila
                {
                    for (int f = 0; f < 3; f++)//colum
                    {
                        if (a[i+filAux, f+colAux] == value) return false;
                    }
                }
            a[fila, col] = value;
            return true;
            }
            

        
        public static bool SigLibre(int[,]a,ref int fila,ref int col)
        {
            for(int i=0;i<a.GetLength(0);i++)
            {
                for(int j=0;j<a.GetLength(1);j++)
                {
                    if (a[i, j] == 0) {
                        fila = i;col = j; return false;
                    }
                    
                }
            }
            return true;
        }

        public static bool Resolsudoku(int[,]a)
        {
            int fila=0, col = 0;
            if (SigLibre(a, ref fila, ref col))
                return true;
            else
            {
                Imprimir(a);
                for (int i = 1; i < 10 ; i++)
                { if (RestriccionSudoku(a, fila, col, i) && Resolsudoku(a))
                    {
                       // a[fila, col] = i;                      
                      return true;
                    }
                    
                }                
                    a[fila, col] = 0;
                    return false;
                
                
            }
        }

    }
}
