using UnityEngine;
using TMPro;
using DG.Tweening;

[RequireComponent(typeof(TMP_Text))]
public class ErrorMessage : MonoBehaviour
{
    private TMP_Text _text;
    private Sequence _sequence;

    private void OnDisable()
    {
        if (_sequence != null) _sequence.Kill();
    }

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    public void ShowMessage(string message)
    {
        if (_sequence != null) _sequence.Kill();

        _sequence = DOTween.Sequence();

        _text.text = message;
        _text.color = Color.red;

        Color targetColor = new Color(0, 0, 0, 0);

        _sequence.Append(_text.DOColor(targetColor, 1.5f));
    }
}
