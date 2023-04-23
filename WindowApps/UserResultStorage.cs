namespace WindowApps;

public class UserResultStorage
{
    public List<User> _users;

    public UserResultStorage(string username)
    {
        _users.Add(new User(username));
    }

    public void GetResults(string textFile)
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
    
    public int GetUserAnswer()
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
}