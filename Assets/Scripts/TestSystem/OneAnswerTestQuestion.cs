using System.Collections;

public class OneAnswerTestQuestion : TestQuestion
{
    protected override IEnumerator ShowAnswers()
    {
        for (int i = 0; i < _answersDatas.Count; i++)
        {
            if (_answersDatas[i].IsRightAnswer)
            {
                if (_spawnedAnswers[i].IsChosen)
                    TestController.Instance.AnsweredRight();

                _spawnedAnswers[i].SetRightColor();
            }
            else
            {
                 _spawnedAnswers[i].SetWrongColor();
            }
        }

        yield return base.ShowAnswers();
    }

    private void UnCheckAnswers(int index)
    {
        for (int i = 0; i < _spawnedAnswers.Count; i++)
        {
            if (i == index)
                continue;

            if (_spawnedAnswers[i].IsChosen)
            {
                _spawnedAnswers[i].ToggleAnswer();
            }
        }
    }

    private void OnEnable()
    {
        EventBus.OnAnswerChosen += UnCheckAnswers;
    }

    private void OnDisable()
    {
        EventBus.OnAnswerChosen -= UnCheckAnswers;
    }
}