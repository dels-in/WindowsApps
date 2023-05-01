using WindowApps;
using static System.IO.Path;

var userChoice = GetUserChoice("Хотите добавить новый вопрос?");
if (userChoice)
    AddNewQuestion();

var questions = QuestionStorage.GetQuestions();
var random = new Random();

userChoice = GetUserChoice("Хотите удалить существующий вопрос?");
if (userChoice)
    RemoveQuestion();

Console.WriteLine("Введите Ваше имя: ");
var user = new User(Console.ReadLine()!);

var flag = true;
while (flag)
{
    var indexes = new List<int>();
    for (var i = 0; i < questions.Count; i++)
    {
        Console.WriteLine("Вопрос №" + (i + 1));

        var randomQuestionIndex = random.Next(0, questions.Count);
        for (var j = 0; j < indexes.Count; j++)
        {
            if (indexes[j] == randomQuestionIndex)
            {
                randomQuestionIndex = random.Next(0, questions.Count);
                j = -1;
            }
        }

        indexes.Add(randomQuestionIndex);

        Console.WriteLine(questions[randomQuestionIndex]._text);

        var userAnswer = UserResultStorage.GetNumber();

        var rightAnswer = questions[randomQuestionIndex]._answer;
        if (userAnswer == rightAnswer)
        {
            user.AddCountRightAnswers();
        }
    }

    Console.WriteLine("Количество правильных ответов: " + user._countRightAnswers);

    var diagnoses = QuestionStorage.GetDiagnoses();
    var asking = true;
    Console.WriteLine(user._username + ", Ваш диагноз: " + diagnoses[user._countRightAnswers] +
                      ". Желаете повторить? Для вывода результатов напишите \"Результаты\"");

    FileStorage.SaveResults(user, diagnoses, "Game results.txt");

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
                ShowResults();
                break;
            default:
                Console.WriteLine("Да или нет?");
                break;
        }
    }
}

static bool GetUserChoice(string question)
{
    while (true)
    {
        Console.WriteLine(question);
        var userChoice = Console.ReadLine();

        switch (userChoice.ToLower())
        {
            case "да":
                return true;
            case "нет":
                return false;
        }
    }
}

static void AddNewQuestion()
{
    Console.WriteLine("Введите текст вопроса:");
    var textToAdd = Console.ReadLine();
    Console.WriteLine("Введите ответ на вопрос:");
    var answerToAdd = UserResultStorage.GetNumber();

    var newQuestion = new Question(textToAdd, answerToAdd);

    QuestionStorage.Add(newQuestion);
    var userChoice = GetUserChoice("Хотите добавить еще?");
    if (userChoice)
        AddNewQuestion();
}

void RemoveQuestion()
{
    //questions = QuestionStorage._questions;
    for (var i = 0; i < questions.Count; i++)
    {
        Console.WriteLine($"{(i + 1)}. {questions[i]._text}");
    }
    Console.WriteLine("Введите номер вопроса для удаления.");

    var removeQuestionNumber = UserResultStorage.GetNumber();
    while (removeQuestionNumber < 1 || removeQuestionNumber > questions.Count)
    {
        Console.WriteLine("Введите число от 1 до  " + questions.Count);
        removeQuestionNumber = UserResultStorage.GetNumber();
    }

    var removeQuestion = questions[removeQuestionNumber - 1];
    QuestionStorage.Remove(removeQuestion);
    userChoice = GetUserChoice("Хотите удалить еще?");
    if (userChoice)
        RemoveQuestion();
}

static void ShowResults()
{
    Console.WriteLine("{0,10} {1,32} {2,16}", "Имя", "Количество правильных ответов", "Диагноз");
    var text = FileStorage.GetResults("Game results.txt");
    var lines = text.Split("\n", StringSplitOptions.RemoveEmptyEntries);
    foreach (var line in lines)
    {
        var values = line.Split("#");
        var name = values[0];
        var countRightAnswers = Convert.ToInt32(values[1]);
        var diagnose = values[2];
        Console.WriteLine("{0,10}{1,20}{2,30}", name, countRightAnswers, diagnose);
    }
}