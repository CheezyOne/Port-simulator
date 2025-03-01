using System.Collections;

public class MultipleAnswersTestQuestion : TestQuestion
{
    protected override IEnumerator ShowAnswers()
    {
        bool isRightAnswer = true;

        for (int i = 0; i < _answersDatas.Count; i++)
        {
            if (_answersDatas[i].IsRightAnswer)
            {
                if (!_spawnedAnswers[i].IsChosen)
                    isRightAnswer = false;

                _spawnedAnswers[i].SetRightColor();
            }
            else
            {
                if (_spawnedAnswers[i].IsChosen)
                    isRightAnswer = false;

                _spawnedAnswers[i].SetWrongColor();
            }
        }

        if (isRightAnswer)
            TestController.Instance.AnsweredRight();

        yield return base.ShowAnswers();
    }
}