namespace WindowApps;

public class User
{
    public string _username;
    public int _countRightAnswers = 0;

    public User(string username)
    {
        _username = username;
    }
}