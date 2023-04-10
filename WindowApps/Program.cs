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

        var userAnswer = 0;
        var isNumericAnswer = false;
        while (!isNumericAnswer)
        {
            Console.WriteLine("Введи число");
            isNumericAnswer = int.TryParse(Console.ReadLine(), out userAnswer);
        }

        var rightAnswer = answers[randomQuestionIndex];

        if (userAnswer == rightAnswer)
        {
            countRightAnswers++;
        }
    }

    Console.WriteLine("Количество правильных ответов: " + countRightAnswers);

    var diagnoses = GetDiagnoses(countDiagnoses);

    Console.WriteLine(username + ", Ваш диагноз: " + diagnoses[countRightAnswers] + ". Желаете повторить?");
    var asking = true;
    while (asking)
    {
        var userWish = Console.ReadLine();
        switch (userWish.ToLower())
        {
            case "да":
                asking = false;
                break;
            case "нет":
                asking = false;
                Console.WriteLine("Что ж, до свидания!");
                flag = false;
                break;
            default:
                Console.WriteLine("Да или нет?");
                break;
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
    diagnoses[0] = "кретин";
    diagnoses[1] = "идиот";
    diagnoses[2] = "дурак";
    diagnoses[3] = "нормальный";
    diagnoses[4] = "талант";
    diagnoses[5] = "гений";
    return diagnoses;
}