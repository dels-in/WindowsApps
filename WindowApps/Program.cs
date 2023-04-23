using WindowApps;
using static System.IO.Path;

var questionStorage = new QuestionStorage(5);
var questions = questionStorage.GetQuestions();
var random = new Random();

Console.WriteLine("Введите Ваше имя: ");
var username = new UserResultStorage(Console.ReadLine()!);
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

        Console.WriteLine(questions[randomQuestionIndex]);

        var userAnswer = GetUserAnswer();

        var rightAnswer = questions[randomQuestionIndex]._answer;
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

