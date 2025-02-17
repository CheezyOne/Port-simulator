using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class OneAnswerPossibleAnswer : MonoBehaviour
{
    [SerializeField] private Color _wrongAnswerColor;
    [SerializeField] private Color _rightAnswerColor;
    [SerializeField] private float _colorChangeTime;
    [SerializeField] private Image _answerImage;
    [SerializeField] private Text _answerText;
    private bool _isRightAnswer;

    public void SetAnswerData(string answer, bool isRightAnswer)
    {
        _answerText.text = answer;
        _isRightAnswer = isRightAnswer;
    }

    public void SetWrongColor()
    {
        _answerImage.DOColor(_wrongAnswerColor, _colorChangeTime);
    }

    public void SetRightColor()
    {
        _answerImage.DOColor(_rightAnswerColor, _colorChangeTime);
    }

    public void ChoseAnswer()
    {
        EventBus.OnAnswerChosen?.Invoke(_isRightAnswer);
    }
}