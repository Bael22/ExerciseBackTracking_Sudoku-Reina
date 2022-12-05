using S10_Backtracking;
using System.Diagnostics.SymbolStore;

int[,] lab = {
    {0,6,0,1,0,4,0,5,0},
    {0,0,8,3,0,5,6,0,0},
    {2,0,0,0,0,0,0,0,1},
    {8,0,0,4,0,7,0,0,6},
    {0,0,6,0,0,0,3,0,0},
    {7,0,0,9,0,1,0,0,4},
    {5,0,0,0,0,0,0,0,2},
    {0,0,7,2,0,6,9,0,0},
    {0,4,0,5,0,8,0,7,0}
};
BackTracking.Resolsudoku(lab);
Console.WriteLine("\n Resultado:\n");
for(int fil=0;fil<lab.GetLength(0);fil++)
{
    if(fil%3==0)
    { for (int i = 0; i < lab.GetLength(0)+10; i++)
        {
            Console.Write("-");
        }
        Console.WriteLine();
    }
    for (int col=0;col<lab.GetLength(1);col++)
    {
        if (col%3==0) {
            Console.Write("|"+lab[fil, col] );
        }
        else
        Console.Write(" "+lab[fil, col]);
    } 
    Console.WriteLine("|");
}