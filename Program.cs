namespace IJunior;

class Program
{
    #region Consts
    private const int StartingPoints = 25;
    private const int StatLimit = 10;

    private const char HasPointSymbol = '#';
    private const char DoesNotHavePointSymbol = '_';
    #endregion
    
    #region Fields;
    private static int _points = StartingPoints;
    private static int _age;
    private static Dictionary<string, int> _stats = new Dictionary<string, int>
    {
        { "сила", 0 },
        { "ловкость", 0 },
        { "интеллект", 0 },
    };
    
    private static readonly string[] _validOperations = new[] { "+", "-" };
    #endregion
    
    public static void Main(string[] args)
    {
        Intro();
        StartPointAssignmentLoop();
        AssignAge();
        ShowResultingCharacter();
    }

    #region Gameplay
    private static void Intro()
    {
        Console.WriteLine("Добро пожаловать в меню выбора создания персонажа!");
        Console.WriteLine($"У вас есть {StartingPoints} очков, которые вы можете распределить по умениям");
        Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
        Console.ReadKey();
    }
    private static void StartPointAssignmentLoop()
    {
        while (_points > 0)
        {            
            Console.Clear();
            PrintPoints();
            PrintStats();

            AssignPoints();        
        }
    }
    private static void AssignPoints()
    {
        string statToChange = ReadLineToLower("Какую характеристику вы хотите изменить?");
        string operation = ReadOperation($"Что вы хотите сделать? {string.Join(@"\", _validOperations)}");
        int pointsInvested = ReadInt("Количество поинтов которое следует " + (operation == "+" ? "прибавить" : "отнять"));

        if (operation == "+")
            _points = BuyStat(statToChange, pointsInvested);
        else if (operation == "-")
            _points = BuyStat(statToChange, -pointsInvested);
        else
            throw new InvalidOperationException();
    }
    private static void AssignAge()
    {
        _age = ReadInt("Вы распределили все очки. Введите возраст персонажа:");
    }
    private static void ShowResultingCharacter()
    {
        Console.Clear();
        PrintAge();
        PrintStats();
    }
    #endregion

    #region Stat buying
    private static int BuyStat(string statName, int pointsInvested)
    {
        pointsInvested -= CalculateOverhead(pointsInvested, _stats[statName]);
        int actualPointsInvested = pointsInvested < _points ? pointsInvested : _points;

        _stats[statName] += actualPointsInvested;
        return _points - actualPointsInvested;
    }
    private static int CalculateOverhead(int pointsInvested, int currentStatValue)
    {
        int overhead = pointsInvested - (StatLimit - currentStatValue);
        return overhead < 0 ? 0 : overhead;
    }
    #endregion 
    
    #region Console input
    private static int ReadInt(string message)
    {
        Console.WriteLine(message);
        return ReadInt();
    }
    private static int ReadInt()
    {
        int result;
        while (!int.TryParse(ReadLine(), out result)) { }
        return result;
    }
    private static string ReadOperation(string message)
    {
        Console.WriteLine(message);
        return ReadOperation();
    }
    private static string ReadOperation()
    {
        string result;
        do 
            result = ReadLine();
        while (!_validOperations.Contains(result));
        return result;
    }
    private static string ReadLineToLower(string message)
    {
        Console.WriteLine(message);
        return ReadLineToLower();
    }
    private static string ReadLineToLower()
    {
        return ReadLine().ToLower();
    }
    private static string ReadLine()
    {
        return Console.ReadLine() ?? string.Empty;
    }
    #endregion

    #region Console output
    private static void PrintStats()
    {
        foreach (var pair in _stats)
            PrintStat(pair.Key, pair.Value);
    }
    private static void PrintStat(string statName, int statValue)
    {
        string statVisual =
            new string(HasPointSymbol, statValue).
            PadRight(StatLimit, DoesNotHavePointSymbol);
        PrintFormatted(statName.ToUpper(), statVisual);
    }
    private static void PrintAge()
    {
        PrintFormatted("Возраст", _age.ToString());
    }
    private static void PrintPoints()
    {
        PrintFormatted("Поинтов", _points.ToString());
    }
    private static void PrintFormatted(string name, string value)
    {
        Console.WriteLine("{0} - {1}", name, value);
    }
    #endregion
} 