using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichasAjedrez_01
{
    internal class Reina
    {
        public static bool Valides1(int[,] a, int fila, int col)//reina=1
        {
            if (fila >= 0 && fila < a.GetLength(0) && col >= 0 && col < a.GetLength(1))
            {
                return true;
            }
            return false;
        }
        /*public static void Relleno1_7(int[,] a,int fila,int col, int borrar)
        {
            if (borrar == 0) borrar = 7;
            else borrar = 0;
            for (int i = 0; i < a.GetLength(1); i++)//fila
            {
                if (a[fila, i] != 1) a[fila, i]= borrar;
            }
            for (int i = 0; i < a.GetLength(0); i++)//fila
            {
                if (a[i, col] != 1) a[i, col] = borrar;
            }

            int FilaAux = fila, ColAux = col;
            while (Valides1(a, FilaAux - 1, ColAux - 1))//diagonal izq sup
            {
                a[FilaAux - 1, ColAux - 1] = borrar;
                ColAux -= 1; FilaAux -= 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux + 1, ColAux - 1))//diagonal izq inf
            {
                a[FilaAux + 1, ColAux - 1] = borrar;
                ColAux -= 1; FilaAux += 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux - 1, ColAux + 1))//diagonal der sup
            {
                a[FilaAux - 1, ColAux + 1] = borrar;
                ColAux += 1; FilaAux -= 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux + 1, ColAux + 1))//diagonal der inf
            {
               a[FilaAux + 1, ColAux + 1] = borrar;
                ColAux += 1; FilaAux += 1;
            }
        }*/
        public static bool Valides(int[,]a,int fila,int col)//reina=1
        {
            for (int i = 0; i < a.GetLength(1); i++)//fila
            {
                if (a[fila, i] == 1) return false;
            }
            for (int i = 0; i < a.GetLength(0); i++)//col
            {
                if (a[i, col] == 1) return false;
            }
            int FilaAux = fila, ColAux = col;
            while(Valides1(a,FilaAux-1,ColAux-1))//diagonal izq sup
            {
                if (a[FilaAux - 1, ColAux - 1] ==1) return false;
                ColAux -= 1; FilaAux -= 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux + 1, ColAux - 1))//diagonal izq inf
            {
                if (a[FilaAux + 1, ColAux - 1] == 1) return false;
                ColAux -= 1; FilaAux += 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux - 1, ColAux + 1))//diagonal der sup
            {
                if (a[FilaAux - 1, ColAux + 1] == 1) return false;
                ColAux += 1; FilaAux -= 1;
            }
            FilaAux = fila; ColAux = col;
            while (Valides1(a, FilaAux + 1, ColAux + 1))//diagonal der inf
            {
                if (a[FilaAux + 1, ColAux + 1] == 1) return false;
                ColAux += 1; FilaAux += 1;
            }
            a[fila, col] = 1;
           // Relleno1_7(a, fila, col,0);
            return true;
        }

        public static int contReina(int[,] a)
        {
            int cont = 0;
            for(int i=0; i<a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] == 1) cont++;
            }return cont;
        }
        public static bool Disponible(int[,] a,ref int fila,ref int col)
        {
            for (int i = 0; i < a.GetLength(1); i++)//fila
            {
                for (int f = 0; f < a.GetLength(0); f++)//fila
                {
                    if (Valides(a, i, f))//&& a[i, f] != 7)
                    {
                        a[i, f] = 0;
                        fila = i;col = f;

                        return true;
                    }
                }
            }
            return false;
            
        }
       /* public static void DeleteAll_7(int[,] a)
        {
            for (int i = 0; i < a.GetLength(1); i++)//fila
            {
                for (int f = 0; f < a.GetLength(0); f++)//fila
                {
                    if (a[i, f] == 7)
                    {
                        a[i, f] = 0;
                    }
                }
            }
        }*/
        public static void Aletorio(ref int f,ref int c,int cant)
        {
            Random r=new Random();
            f = r.Next(0, cant);
            c = r.Next(0, cant);
        }
        
       
        //def cuando modifica todo y no solo una parte del dato
        public static bool TableroSol(int[,]a,ref int cont)
        {
            if (contReina(a) == a.GetLength(0))
            {
                cont = 4;
               // DeleteAll_7(a);
                return true;
            }
                
            else
            { int f = 0, c = 0;
                if(Disponible(a,ref f,ref c)) 
                {
                    cont++;
                    do
                    {
                        if (cont == 1)
                        {
                            a[f, c] = 0;
                           // Relleno1_7(a, f, c, 1);
                            Aletorio(ref f, ref c, a.GetLength(0));
                        }                    
                    } while (!Valides(a,f,c)||!TableroSol(a,ref cont));
                    if (cont != a.GetLength(0))
                    {
                        a[f, c] = 0;
                        //Relleno1_7(a, f, c, 1);//borra los 7
                        --cont;
                        if (cont != 1) return true;
                        else return false;
                    }
                    else return true;
                }
                else return true;
                
                
            }
        }
    }
}
