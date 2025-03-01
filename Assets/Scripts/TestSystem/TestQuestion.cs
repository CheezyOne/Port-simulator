using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestQuestion : MonoBehaviour
{
    [SerializeField] private Text _questionText;
    [SerializeField] private Image _questionImage;
    [SerializeField] private Sprite _questionSprite;
    [SerializeField] private string _question;
    [SerializeField] private PossibleAnswer _possibleAnswer;
    [SerializeField] private Transform _answersHolder;

    [SerializeField] protected List<AnswerData> _answersDatas;

    protected List<PossibleAnswer> _spawnedAnswers = new();

    private WaitForSeconds _waitTillNextQuestion = new (2f);

    private void Awake()
    {
        for (int i = 0; i < _answersDatas.Count; i++)
        {
            PossibleAnswer newAnswer = Instantiate(_possibleAnswer, _answersHolder);
            newAnswer.SetAnswerData(_answersDatas[i].AnswerText, i);
            _spawnedAnswers.Add(newAnswer);
        }

        if (_questionSprite != null)
        {
            _questionImage.sprite = _questionSprite;
            _questionImage.gameObject.SetActive(true);
        }

        _questionText.text = _question;
    }

    public void ShowAnswersButton()
    {
        StartCoroutine(ShowAnswers());
    }

    protected virtual IEnumerator ShowAnswers()
    {
        yield return _waitTillNextQuestion;
        TestController.Instance.Answered();
    }
}

[Serializable]
public struct AnswerData
{
    public bool IsRightAnswer;
    public string AnswerText;
}