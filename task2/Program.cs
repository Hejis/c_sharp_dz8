// Задайте прямоугольный двумерный массив. Напишите программу, 
//которая будет находить строку с наименьшей суммой элементов.

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

void PrintMatrix(int[,] array)
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

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.WriteLine($"Сумма {i + 1} строки = {array[i]}\t");
    }
    System.Console.WriteLine();
}

int[] SumOfRow(int[,] array)
{
    int[] sum = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum[i] += array[i, j];
        }
    }
    return sum;
}

void MinSumOfRow(int[] sum)
{
    int indexMin = 0;
    for (int i = 1; i < sum.Length; i++)
    {
        if (sum[i] < sum[indexMin])
        {
            indexMin = i;
        }
    }
    System.Console.WriteLine($"Строка с наименьшей суммой элементов {sum[indexMin]} - строка № {indexMin + 1}");
    System.Console.WriteLine();
}
int rowLength =3,  colLength = 4,  minRange = 0, maxRange =10;
int[,] array = GenerateArray(rowLength, colLength, minRange, maxRange);
Console.WriteLine("Исходный массив: ");
PrintMatrix(array);
int[] sum = SumOfRow(array);
PrintArray(sum);
MinSumOfRow(sum);
