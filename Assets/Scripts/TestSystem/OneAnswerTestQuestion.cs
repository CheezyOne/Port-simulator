using System;
using System.Collections.Generic;
using UnityEngine;

public class OneAnswerTestQuestion : MonoBehaviour
{
    [SerializeField] private OneAnswerPossibleAnswer _possibleAnswer;
    [SerializeField] private List<AnswerData> _answers;
    [SerializeField] private Transform _answersHolder;
    private List<OneAnswerPossibleAnswer> _spawnedAnswers = new();

    private void Awake()
    {
        for (int i=0;i<_answers.Count;i++)
        {
            OneAnswerPossibleAnswer newAnswer = Instantiate(_possibleAnswer, _answersHolder);
            newAnswer.SetAnswerData(_answers[i].AnswerText, _answers[i].IsRightAnswer);
            _spawnedAnswers.Add(newAnswer);
        }
    }

    private void ShowAnswers(bool isRightAnswer)
    {
        for (int i = 0; i < _answers.Count; i++)
        {
            if (_answers[i].IsRightAnswer)
                _spawnedAnswers[i].SetRightColor();
            else
                _spawnedAnswers[i].SetWrongColor();
        }
    }

    private void OnEnable()
    {
        EventBus.OnAnswerChosen += ShowAnswers;
    }

    private void OnDisable()
    {
        EventBus.OnAnswerChosen -= ShowAnswers;
    }
}

[Serializable]
public struct AnswerData
{
    public bool IsRightAnswer;
    public string AnswerText;
}