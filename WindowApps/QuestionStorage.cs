namespace WindowApps;

public class QuestionStorage
{
    public List<Question> _questions=new();
    public int _countQuestions;
    public int _countDiagnoses;

    public QuestionStorage(int countQuestions)
    {
        _countQuestions = countQuestions;
        _countDiagnoses = countQuestions + 1;
        //_questions = new List<Question>(countQuestions);
    }
    
    public List<Question> GetQuestions()
    {
        _questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
        _questions.Add(new Question( "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",9));
        _questions.Add(new Question( "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",25));
        _questions.Add(new Question( "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",60));
        _questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
        return _questions;
    }
    
    public string[] GetDiagnoses()
    {
        var diagnoses = new string[_countDiagnoses];
        for (var i = 0; i < _countDiagnoses; i++)
        {
            if (i < _countDiagnoses / 6)
            {
                diagnoses[i] = "кретин";
            }

            if (i >= _countDiagnoses / 6 && i < _countDiagnoses * 2 / 6)
            {
                diagnoses[i] = "идиот";
            }

            if (i >= _countDiagnoses * 2 / 6 && i < _countDiagnoses * 3 / 6)
            {
                diagnoses[i] = "дурак";
            }

            if (i >= _countDiagnoses * 3 / 6 && i < _countDiagnoses * 4 / 6)
            {
                diagnoses[i] = "нормальный";
            }

            if (i >= _countDiagnoses * 4 / 6 && i < _countDiagnoses * 5 / 6)
            {
                diagnoses[i] = "талант";
            }

            if (i >= _countDiagnoses * 5 / 6 && i < _countDiagnoses * 6 / 6)
            {
                diagnoses[i] = "гений";
            }
        }

        return diagnoses;
    }
}