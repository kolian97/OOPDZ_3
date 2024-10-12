//з задание Доработайте приложение поиска пути в лабиринте,
//но на этот раз вам нужно определить сколько всего выходов имеется
//в лабиринте:


int[,] labirynth1 = new int[,]
{
{1, 1, 1, 1, 1, 1, 1 },
{0, 0, 0, 0, 0, 0, 1 },
{1, 0, 1, 1, 1, 0, 1 },
{0, 0, 0, 0, 1, 0, 0 },
{1, 1, 0, 0, 1, 1, 1 },
{1, 1, 1, 1, 1, 1, 1 },
{1, 1, 1, 1, 1, 1, 1 }
};

HasExit(1, 0, labirynth1);


static int HasExit(int startI, int startJ, int[,] l)
{
    Stack<Tuple<int, int>> _path = new Stack<Tuple<int, int>>();
    Console.WriteLine(l[startI, startJ]);
    if (l[startI, startJ] == 0) _path.Push(new(startI, startJ));
    int NumberOfOutputs = 0;
    while (_path.Count > 0)
    {

        var current = _path.Pop();

        Console.WriteLine($"{current.Item1},{current.Item2} ");
        if (current.Item1 + 1 == l.GetLength(0) || current.Item2 + 1 == l.GetLength(1)
            || current.Item1 == 0 || current.Item2 == 0)
        {
            NumberOfOutputs++;
            Console.WriteLine($"Выход найден {current.Item1},{current.Item2} ");
        }

        l[current.Item1, current.Item2] = 1;

        if (current.Item1 + 1 < l.GetLength(0)
        && l[current.Item1 + 1, current.Item2] != 1)
            _path.Push(new(current.Item1 + 1, current.Item2));

        if (current.Item2 + 1 < l.GetLength(1) &&
       l[current.Item1, current.Item2 + 1] != 1)
            _path.Push(new(current.Item1, current.Item2 + 1));

        if (current.Item1 > 0 && l[current.Item1 - 1, current.Item2] != 1)
            _path.Push(new(current.Item1 - 1, current.Item2));

        if (current.Item2 > 0 && l[current.Item1, current.Item2 - 1] != 1)
            _path.Push(new(current.Item1, current.Item2 - 1));
    }

    Console.WriteLine($"Количество выходов = {NumberOfOutputs}");
    return 0;
}
