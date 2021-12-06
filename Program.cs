int[,] RandomFillMatrix(int[,] matrix, int leftBound, int rightBound)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = new Random().Next(leftBound, rightBound + 1);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write($"{matrix[i, j]} ");
        }
        System.Console.WriteLine();
    }
}

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        System.Console.Write($"{array[i]} ");
    }
    System.Console.WriteLine();
}

// 57. Написать программу, упорядочивания по убыванию элементы каждой строки двумерной массива.
void OrderAllStrings(int[,] matrix)
{
    int maxOfString;
    int maxIndex = 0;
    int buffer;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            maxOfString = matrix[i, k];
            maxIndex = k;
            for (int j = k; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > maxOfString)
                {
                    maxOfString = matrix[i, j];
                    maxIndex = j;
                }
            }
            if (maxIndex != k)
            {
                buffer = matrix[i, k];
                matrix[i, k] = matrix[i, maxIndex];
                matrix[i, maxIndex] = buffer;
            }
        }
    }
}

// 58. Написать программу, которая в двумерном массиве заменяет строки на столбцы или сообщить что числа
// столбцов и строк не равны.
void TranspositionOfMatrix(int[,] matrix)
{
    if (matrix.GetLength(0) != matrix.GetLength(1))
    {
        System.Console.WriteLine("Числа стобцов и строк не равны.");
    }
    else
    {
        int buffer;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = i; j < matrix.GetLength(0); j++)
            {
                if (i != j)
                {
                    buffer = matrix[i, j];
                    matrix[i, j] = matrix[j, i];
                    matrix[j, i] = buffer;
                }
            }
        }
    }
}

// 59. В прямоугольной матрице найти строку с наименьшей суммой элементов.
int[] MinimumLineOfMatrix(int[,] matrix)
{
    int[] sumsOfLines = new int[matrix.GetLength(0)];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            sumsOfLines[i] = sumsOfLines[i] + matrix[i, j];
        }
    }
    int minOfSums = sumsOfLines[0];
    int indexOfMin = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (sumsOfLines[i] < minOfSums)
        {
            minOfSums = sumsOfLines[i];
            indexOfMin = i;
        }
    }
    int[] minimumLine = new int[matrix.GetLength(1)];
    for (int i = 0; i < matrix.GetLength(1); i++)
    {
        minimumLine[i] = matrix[indexOfMin, i];
    }
    return minimumLine;
}

// 60. Составить частотный словарь элементов двумерного массива
int[,] FrequencyDictionary(int[,] matrix)
{
    int countOfAll = matrix.GetLength(0) * matrix.GetLength(1);
    int[] allElements = new int[countOfAll];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            allElements[i * matrix.GetLength(1) + j] = matrix[i, j];
        }
    }
    int buffer = 0;
    int maxIndex;
    int max;
    for (int k = 0; k < countOfAll; k++)
    {
        maxIndex = k;
        max = allElements[k];
        for (int i = k; i < countOfAll; i++)
        {
            if (allElements[i] > max)
            {
                max = allElements[i];
                maxIndex = i;
            }
        }
        if (maxIndex != k)
        {
            buffer = allElements[maxIndex];
            allElements[maxIndex] = allElements[k];
            allElements[k] = buffer;
        }
    }
    int countOfUnique = 1;
    buffer = allElements[0];
    for (int i = 1; i < countOfAll; i++)
    {
        if (allElements[i] != buffer)
        {
            buffer = allElements[i];
            countOfUnique++;
        }
    }
    int[,] freqDict = new int[2, countOfUnique];
    freqDict[0, 0] = allElements[0];
    freqDict[1, 0] = 1;
    int indexOfCurrent = 0;
    for (int i = 1; i < countOfAll; i++)
    {
        if (allElements[i] != freqDict[0, indexOfCurrent])
        {
            indexOfCurrent++;
            freqDict[1, indexOfCurrent] = 1;
            freqDict[0, indexOfCurrent] = allElements[i];
        }
        else
        {
            freqDict[1, indexOfCurrent]++;
        }
    }
    return freqDict;
}

// 61. Найти произведение двух матриц
int[,] ProductMatrix(int[,] matrix1, int[,] matrix2)
{
    if (matrix1.GetLength(1) != matrix2.GetLength(0))
    {
        System.Console.WriteLine("Матрицы невозможно перемножить в таком порядке!");
        return matrix1;
    }
    int[,] matrix3 = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i < matrix1.GetLength(0); i++)
    {
        for (int j = 0; j < matrix2.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                matrix3[i, j] = matrix3[i, j] + matrix1[i, k] * matrix2[k, j];
            }
        }
    }
    return matrix3;
}

// 62. В двумерном массиве целых чисел. Удалить строку и столбец, на пересечении которых расположен наименьший элемент.
int[,] CutLeastElementCross(int[,] matrix)
{
    if (matrix.GetLength(0) < 2 || matrix.GetLength(1) < 2)
    {
        int[,] emptyMatrix = {{0}};
        return emptyMatrix;
    }
    int indexI = 0;
    int indexJ = 0;
    int min = matrix[0, 0];
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i, j] < min)
            {
                min = matrix[i, j];
                indexI = i;
                indexJ = j;
            }
        }
    }
    int flagI = 0;
    int flagJ = 0;
    int[,] resultMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    for (int i = 0; i < matrix.GetLength(0) - 1; i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            if (i >= indexI) { flagI = 1; }
            else { flagI = 0; }
            if (j >= indexJ) { flagJ = 1; }
            else { flagJ = 0; }
            resultMatrix[i, j] = matrix[i + flagI, j + flagJ];
        }
    }
    return resultMatrix;
}


int[,] matrix = new int[5, 5];
matrix = RandomFillMatrix(matrix, 1, 9);
PrintMatrix(matrix);
System.Console.WriteLine();
int[,] matrix2 = CutLeastElementCross(matrix);
PrintMatrix(matrix2);