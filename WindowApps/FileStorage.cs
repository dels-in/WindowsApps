using System.Text;
using static System.IO.Path;

namespace WindowApps;

public static class FileStorage
{
    public static string GetResults(string fileName)
    {
        using var textReader = new StreamReader(Combine(Environment.CurrentDirectory, fileName), Encoding.UTF8);
        return textReader.ReadToEnd();
    }

    public static void SaveResults(User user, string[] diagnoses, string fileName)
    {
        File.AppendAllText(Combine(Environment.CurrentDirectory, fileName),
            $"{user._username}#{user._countRightAnswers}#{diagnoses[user._countRightAnswers]}\n");
    }

    public static bool Exists(string fileName)
    {
        return File.Exists(Combine(Environment.CurrentDirectory, fileName));
    }

    public static void Clear(string fileName)
    {
        File.WriteAllText(Combine(Environment.CurrentDirectory, fileName), string.Empty);
    }
}