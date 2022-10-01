// Задача 3: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int Prompt(string message)
{
    Console.Write(message);
    string strValue = Console.ReadLine() ?? "0";
    bool isNumber = int.TryParse(strValue, out int value);
    if (isNumber)
    {
        return value;
    }
    throw new Exception("Данное значение невозможно преобразовать в число");
}

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

int[,] MultiplicationMatrix(int[,] array1, int[,] array2)
{
    int[,] result = new int[array1.GetLength(0), array2.GetLength(1)];
    if (array1.GetLength(1) == array2.GetLength(0))
    {
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                for (int k = 0; k < array1.GetLength(1); k++)
                {
                    result[i, j] += array1[i, k] * array2[k, j];
                }
            }
        }
    }
    else
    {
        System.Console.WriteLine("Такого произведения матриц не существует, так как число столбцов первой матрицы не совпадает с числом строк второй матрицы");
    }
    return result;
}

Console.WriteLine();

int linesNumber1 = Prompt("Введите число строк 1-ой матрицы: ");

int columnsNumber1 = Prompt("Введите число столбцов 1-ой матрицы: ");
int linesNumber2 = Prompt("Введите число строк 2-ой матрицы: ");

int columnsNumber2 = Prompt("Введите число столбцов 2-ой матрицы: ");

int minRange = 0, maxRange =10;

int[,] array1 = GenerateArray(linesNumber1, columnsNumber1, minRange, maxRange);
Console.WriteLine("Исходная матрица 1: ");
PrintMatrix(array1);
int[,] array2 = GenerateArray(linesNumber2, columnsNumber2, minRange, maxRange);
Console.WriteLine("Исходная матрица 2: ");
PrintMatrix(array2);
Console.WriteLine("Произведение двух матриц: ");
int[,] resultMatrix = MultiplicationMatrix(array1, array2);
PrintMatrix(resultMatrix);