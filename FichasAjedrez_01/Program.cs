using FichasAjedrez_01;

int[,] tabla = {
    {0,0,0,0},
    {0,0,0,0},
    {0,0,0,0},
    {0,0,0,0},
};
Console.WriteLine("Resultado\n");
int a = 0;
Console.WriteLine(Reina.TableroSol(tabla,ref a)+"\n");
for(int i=0;i<tabla.GetLength(0); i++)
{
    for(int j=0;j<tabla.GetLength(1);j++)
        Console.Write(tabla[i,j]+",");
    Console.WriteLine();
}