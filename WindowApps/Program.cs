using WindowApps;
using static System.IO.Path;

var fileStorage = new FileStorage(Environment.CurrentDirectory);
Console.WriteLine("Сколько вопросов?");
var questionStorage = new QuestionStorage(Int32.Parse(Console.ReadLine()));
var questions = questionStorage.GetQuestions();
var random = new Random();

Console.WriteLine("Введите Ваше имя: ");
var user = new User(Console.ReadLine()!);
var userResultStorage = new UserResultStorage(user);
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

        var userAnswer = userResultStorage.GetUserAnswer();

        var rightAnswer = questions[randomQuestionIndex]._answer;
        if (userAnswer == rightAnswer)
        {
            user._countRightAnswers++;
        }
    }

    Console.WriteLine("Количество правильных ответов: " + user._countRightAnswers);

    var diagnoses = questionStorage.GetDiagnoses();
    var asking = true;
    Console.WriteLine(user._username + ", Ваш диагноз: " + diagnoses[user._countRightAnswers] +
                      ". Желаете повторить? Для вывода результатов напишите \"Результаты\"");

    fileStorage.SaveResults(user, diagnoses);
   
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
                fileStorage.GetResults();
                break;
            default:
                Console.WriteLine("Да или нет?");
                break;
        }
    }
}