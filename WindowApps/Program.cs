using static System.IO.Path;

var countQuestions = 5;
var countDiagnoses = countQuestions + 1;
var countRightAnswers = 0;
var questions = GetQuestions(countQuestions);
var answers = GetAnswers(countQuestions);
var random = new Random();


Console.WriteLine("Введите Ваше имя: ");
var username = Console.ReadLine();
var flag = true;
while (flag)
{
    var indexes = new List<int>();
    for (var i = 0; i < countQuestions; i++)
    {
        Console.WriteLine("Вопрос №" + (i + 1));

        var randomQuestionIndex = random.Next(0, countQuestions);
        for (var j = 0; j < indexes.Count; j++)
        {
            if (indexes[j] == randomQuestionIndex)
            {
                randomQuestionIndex = random.Next(0, countQuestions);
                j = -1;
            }
        }

        indexes.Add(randomQuestionIndex);

        Console.WriteLine(questions[randomQuestionIndex]);

        var userAnswer = GetUserAnswer();

        var rightAnswer = answers[randomQuestionIndex];
        if (userAnswer == rightAnswer)
        {
            countRightAnswers++;
        }
    }

    Console.WriteLine("Количество правильных ответов: " + countRightAnswers);

    var diagnoses = GetDiagnoses(countDiagnoses);
    var asking = true;
    Console.WriteLine(username + ", Ваш диагноз: " + diagnoses[countRightAnswers] +
                      ". Желаете повторить? Для вывода результатов напишите \"Результаты\"");

    var path = Environment.CurrentDirectory;
    var textFile = Combine(path, "Game results.txt");
    File.AppendAllText(textFile, $"{username}#{countRightAnswers}#{diagnoses[countRightAnswers]}\n");

    while (asking)
    {
        var userWish = Console.ReadLine();
        switch (userWish!.ToLower())
        {
            case "да":
                asking = false;
                break;
            case "нет":
                asking = false;
                Console.WriteLine("Что ж, до свидания!");
                flag = false;
                break;
            case "результаты":
                GetResults(textFile);
                break;
            default:
                Console.WriteLine("Да или нет?");
                break;
        }
    }
}

static void GetResults(string textFile)
{
    Console.WriteLine("{0,10} {1,32} {2,16}", "Имя", "Количество правильных ответов", "Диагноз");
    using var textReader = new StreamReader(textFile);
    while (!textReader.EndOfStream)
    {
        var text = textReader.ReadLine();
        var values = text.Split("#");
        var name = values[0];
        var countRightAnswers = Convert.ToInt32(values[1]);
        var diagnose = values[2];
        
        Console.WriteLine("{0,10}{1,20}{2,30}", name, countRightAnswers, diagnose);
    }
}

static int GetUserAnswer()
{
    while (true)
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Введи число");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Введи число от -2*10^9 до 2*10^9");
        }
    }
}

static string[] GetQuestions(int countQuestions)
{
    string[] questions = new string[countQuestions];
    questions[0] = "Сколько будет два плюс два умноженное на два?";
    questions[1] = "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?";
    questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
    questions[3] = "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?";
    questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
    return questions;
}

static int[] GetAnswers(int countAnswers)
{
    var answers = new int[countAnswers];
    answers[0] = 6;
    answers[1] = 9;
    answers[2] = 25;
    answers[3] = 60;
    answers[4] = 2;
    return answers;
}

static string[] GetDiagnoses(int countDiagnoses)
{
    var diagnoses = new string[countDiagnoses];
    for (var i = 0; i < countDiagnoses; i++)
    {
        if (i < countDiagnoses / 6)
        {
            diagnoses[i] = "кретин";
        }

        if (i >= countDiagnoses / 6 && i < countDiagnoses * 2 / 6)
        {
            diagnoses[i] = "идиот";
        }

        if (i >= countDiagnoses * 2 / 6 && i < countDiagnoses * 3 / 6)
        {
            diagnoses[i] = "дурак";
        }

        if (i >= countDiagnoses * 3 / 6 && i < countDiagnoses * 4 / 6)
        {
            diagnoses[i] = "нормальный";
        }

        if (i >= countDiagnoses * 4 / 6 && i < countDiagnoses * 5 / 6)
        {
            diagnoses[i] = "талант";
        }

        if (i >= countDiagnoses * 5 / 6 && i < countDiagnoses * 6 / 6)
        {
            diagnoses[i] = "гений";
        }
    }

    return diagnoses;
}