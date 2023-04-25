namespace WindowApps;

public class UserResultStorage
{
    public List<User> _users = new();

    public UserResultStorage(User user)
    {
        _users.Add(user);
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