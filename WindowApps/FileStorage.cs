using static System.IO.Path;

namespace WindowApps;

public class FileStorage
{
    public string _path;
    public string _textFile;

    public FileStorage(string path)
    {
        _path = path;
        _textFile = Combine(path, "Game results.txt");
    }
    
    public void GetResults()
    {
        Console.WriteLine("{0,10} {1,32} {2,16}", "Имя", "Количество правильных ответов", "Диагноз");
        using var textReader = new StreamReader(_textFile);
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

    public void SaveResults(User user, string[] diagnoses)
    {
        var textFile = Combine(_path, "Game results.txt");
        File.AppendAllText(textFile, $"{user._username}#{user._countRightAnswers}#{diagnoses[user._countRightAnswers]}\n");
    }
}