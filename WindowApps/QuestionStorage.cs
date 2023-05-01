using static System.IO.Path;
using System.IO;

namespace WindowApps;

public static class QuestionStorage
{
    public static List<Question> _questions = new();
    public static List<Question> GetQuestions()
    {
        if (FileStorage.Exists("Questions.txt"))
        {
            var value = FileStorage.GetResults("Questions.txt");
            var lines = value.Split("\n", StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                var values = line.Split("#");
                var text = values[0];
                var answer = Convert.ToInt32(values[1]);
                _questions.Add(new Question(text, answer));
            }
        }
        else
        {
            _questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            _questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
            _questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
            _questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            _questions.Add(
                new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            _questions.Add(new Question("Три яблока висели на дереве. Два упало, сколько осталось?", 1));
        }

        SaveQuestions(_questions);

        return _questions;
    }

    private static void SaveQuestions(List<Question> questions)
    {
        FileStorage.Clear("Questions.txt");
        foreach (var question in questions)
        {
            Add(question);
        }
    }

    public static string[] GetDiagnoses()
    {
        var diagnoses = new string[(_questions.Count+1)];
        var percent = 1 / (double)(_questions.Count+1);
        for (var i = 0; i < (_questions.Count+1); i++)
        {
            if (i < (_questions.Count+1) * percent)
            {
                diagnoses[i] = "кретин";
            }

            if (i >= (_questions.Count+1) * percent && i < (_questions.Count+1) * 2 * percent)
            {
                diagnoses[i] = "идиот";
            }

            if (i >= (_questions.Count+1) * 2 * percent && i < (_questions.Count+1) * 3 * percent)
            {
                diagnoses[i] = "дурак";
            }

            if (i >= (_questions.Count+1) * 3 * percent && i < (_questions.Count+1) * 4 * percent)
            {
                diagnoses[i] = "нормальный";
            }

            if (i >= (_questions.Count+1) * 4 * percent && i < (_questions.Count+1) * 5 * percent)
            {
                diagnoses[i] = "талант";
            }

            if (i >= (_questions.Count+1) * 5 * percent && i < (_questions.Count+1) * 6 * percent)
            {
                diagnoses[i] = "гений";
            }
        }

        return diagnoses;
    }

    public static void Add(Question newQuestion)
    {
        var textFile = Combine(Environment.CurrentDirectory, "Questions.txt");
        File.AppendAllText(textFile, $"{newQuestion._text}#{newQuestion._answer}\n");
    }

    public static void Remove(Question removeQuestion)
    {
        var questions = _questions;
        questions.Remove(removeQuestion);
        FileStorage.Clear("Questions.txt");
        SaveQuestions(questions);
    }
}