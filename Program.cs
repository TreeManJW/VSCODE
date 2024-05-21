while (true)
{
    var rand = new Random();
    Console.WriteLine("Enter amount of numbers to randomise: ");
    if (!int.TryParse(Console.ReadLine(), out int amountToRandomise) && amountToRandomise < 1)
    {
        Console.WriteLine("Please enter a valid amount.");
        continue;
    }
    var numbers = new int[amountToRandomise];
    for (int i = 0; i < amountToRandomise; i++)
    {
        numbers[i] = rand.Next(1, 1001);
        Console.Write($"{numbers[i]} ");
    }
    Console.WriteLine("\nStarting bubbel sorter...");
    var sortedNumbers = BubbelSorter(numbers);
    for (int i = 0; i < amountToRandomise; i++)
    {
        Console.Write($"{sortedNumbers[i]} ");
    }
    int numberToSearchFor = 0;
    while (!numbers.Contains(numberToSearchFor))
    {
        numberToSearchFor = rand.Next(1, 1001);
    }
    Console.WriteLine("\nThe program will now search for the number: " + numberToSearchFor);
    (int index, int linearItterations) = LinearSearch(sortedNumbers, numberToSearchFor);
    if (index == -1)
    {
        Console.WriteLine("Something went wrong with the linear search. Or the search number is absent from the list. Try again later.");
        break;
    }
    Console.WriteLine($"Found instance of the number at position {index} using linear search with {linearItterations} itterations. Searching binary.");
    (index, int binaryItterations) = BinarySearch(sortedNumbers, numberToSearchFor);
    if (index == -1)
    {
        Console.WriteLine("Something went wrong with the binary search. Or the search number is absent from the list. Try again later.");
        break;
    }
    Console.WriteLine($"Found instance of the number at position {index} using binary search with {binaryItterations} itterations.");
}

static int[] BubbelSorter(int[] numbers)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        for (int j = 0; j < numbers.Length - 1; j++)
        {
            if (numbers[j] > numbers[j + 1])
            {
                int save1 = numbers[j];
                int save2 = numbers[j + 1];
                numbers[j] = save2;
                numbers[j + 1] = save1;
            }
        }
    }
    return numbers;
}
static (int, int) LinearSearch(int[] numbers, int searchNumber)
{
    int itterations = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        itterations++;
        if (numbers[i] == searchNumber)
        {
            return (i, itterations);
        }
    }
    return (-1, itterations);
}
static (int, int) BinarySearch(int[] numbers, int searchNumber)
{
    int indexMax = numbers.Length;
    int indexMin = 0;
    int itterations = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
        itterations++;
        if (numbers[(indexMax+indexMin)/2] == searchNumber)
        {
            return ((indexMax+indexMin)/2, itterations);
        }
        else if (numbers[(indexMax+indexMin)/2] > searchNumber)
        {
            indexMax = (indexMax+indexMin)/2;
        }
        else if (numbers[(indexMax+indexMin)/2] < searchNumber)
        {
            indexMin = (indexMax+indexMin)/2;
        }
        else
        {
            return (-1, itterations);
        }
    }
    return (-1, itterations);
}