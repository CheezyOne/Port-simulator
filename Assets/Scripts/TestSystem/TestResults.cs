using UnityEngine;
using UnityEngine.UI;

public class TestResults : MonoBehaviour
{
    [SerializeField] private Text _resultsText;
    [SerializeField] private GameObject _testIsFailedText;
    [SerializeField] private GameObject _testIsCompleteText;

    public void SetResults(bool isComplete, string results)
    {
        if (isComplete)
            _testIsCompleteText.gameObject.SetActive(true);
        else
            _testIsFailedText.gameObject.SetActive(true);

        _resultsText.text = results;
    }
}