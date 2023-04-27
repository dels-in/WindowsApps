namespace WindowApps;

public class QuestionStorage
{
    public List<Question> _questions = new();
    public int _countQuestions;
    public int _countDiagnoses;

    public QuestionStorage(int countQuestions)
    {
        _countQuestions = countQuestions;
        _countDiagnoses = countQuestions + 1;
    }

    public List<Question> GetQuestions()
    {
        for (var i = 0; i < _countQuestions; i++)
        {
            //для удаления существующего вопроса 
            // if (i==6)
            //     continue;
            switch (i)
            {
                case 0:
                    _questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
                    break;
                case 1:
                    _questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
                    break;
                case 2:
                    _questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
                        9));
                    break;
                case 3:
                    _questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
                    break;
                case 4:
                    _questions.Add(
                        new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
                    break;
                case 5:
                    _questions.Add(new Question("Три яблока висели на дереве. Два упало, сколько осталось?", 1));
                    break;
            }
        }

        return _questions;
    }

    public string[] GetDiagnoses()
    {
        var diagnoses = new string[_countDiagnoses];
        var percent = 1 / (double)_countDiagnoses;
        for (var i = 0; i < _countDiagnoses; i++)
        {
            if (i < _countDiagnoses * percent)
            {
                diagnoses[i] = "кретин";
            }

            if (i >= _countDiagnoses * percent && i < _countDiagnoses * 2 * percent)
            {
                diagnoses[i] = "идиот";
            }

            if (i >= _countDiagnoses * 2 * percent && i < _countDiagnoses * 3 * percent)
            {
                diagnoses[i] = "дурак";
            }

            if (i >= _countDiagnoses * 3 * percent && i < _countDiagnoses * 4 * percent)
            {
                diagnoses[i] = "нормальный";
            }

            if (i >= _countDiagnoses * 4 * percent && i < _countDiagnoses * 5 * percent)
            {
                diagnoses[i] = "талант";
            }

            if (i >= _countDiagnoses * 5 * percent && i < _countDiagnoses * 6 * percent)
            {
                diagnoses[i] = "гений";
            }
        }

        return diagnoses;
    }
}