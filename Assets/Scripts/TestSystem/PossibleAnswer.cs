using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PossibleAnswer : MonoBehaviour
{
    [SerializeField] private GameObject _answerCheck;
    [SerializeField] private Color _wrongAnswerColor;
    [SerializeField] private Color _rightAnswerColor;
    [SerializeField] private float _colorChangeTime;
    [SerializeField] private Image _answerImage;
    [SerializeField] private Text _answerText;

    private int _index;
    private bool _isChosen;

    public bool IsChosen => _isChosen;

    public void ToggleAnswer()
    {
        if (_isChosen)
        {
            _isChosen = false;
            _answerCheck.SetActive(false);
        }
        else
        {
            _answerCheck.SetActive(true);
            _isChosen = true;
            EventBus.OnAnswerChosen?.Invoke(_index);
        }
    }

    public void SetAnswerData(string answer, int index)
    {
        _answerText.text = answer;
        _index = index;
    }

    public void SetWrongColor()
    {
        _answerImage.DOColor(_wrongAnswerColor, _colorChangeTime);
    }

    public void SetRightColor()
    {
        _answerImage.DOColor(_rightAnswerColor, _colorChangeTime);
    }
}