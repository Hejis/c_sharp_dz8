// Задайте двумерный массив. Напишите программу, 
//которая упорядочит по убыванию элементы каждой строки двумерного массива.


int[,] GenerateArray(int rowLength, int colLength, int minRange, int maxRange)
{
    var array = new int[rowLength, colLength];
    var rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(minRange, maxRange);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            System.Console.Write($"{array[i, j]}\t");
        }
        System.Console.WriteLine();
    }
    System.Console.WriteLine();
}

int[,] SortedArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        SortMaxToMinInRow(array, i);
       
    }
    return array;
}

void SortMaxToMinInRow(int[,] array, int i)
{
    for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, k] > array[i, j])
                {
                    int temp = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
}

int rowLength =3,  colLength = 4,  minRange = 0, maxRange =10;
int[,] array = GenerateArray(rowLength, colLength, minRange, maxRange);
Console.WriteLine("Исходный массив: ");
PrintArray(array);
int[,] sortedArray = SortedArray(array);
Console.WriteLine("Отсортированный массив: ");
PrintArray(sortedArray);
