using System.Collections.Generic;
using UnityEngine;

public class TestController : Singleton<TestController>
{
    [SerializeField] private TestResults _testResults;
    [SerializeField] private List<TestQuestion> _testQuestions;
    [Range(0, 100)][SerializeField] private int _requiredPercent; 

    private TestQuestion _currentQuestion;
    private int _currentQuestionIndex;
    private int _rightAnswers;

    protected override void Awake()
    {
        base.Awake();
        SetNextQuestion();
    }

    private void SetNextQuestion()
    {
        if (_currentQuestion != null)
            Destroy(_currentQuestion.gameObject);

        if (_currentQuestionIndex < _testQuestions.Count)
            _currentQuestion = Instantiate(_testQuestions[_currentQuestionIndex], transform);
        else
            EndTest();

        _currentQuestionIndex++;
    }

    public void AnsweredRight()
    {
        _rightAnswers++;
    }

    public void Answered()
    {
        SetNextQuestion();
    }

    private void EndTest()
    {
        float completionPercent = (float)_rightAnswers / (float)_testQuestions.Count;
        bool isTestComplete = completionPercent >= _requiredPercent;
        string results = _rightAnswers + "/" + _testQuestions.Count;
        Instantiate(_testResults, transform).SetResults(isTestComplete, results);
    }
}