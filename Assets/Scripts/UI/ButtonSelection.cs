using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Zenject;

[RequireComponent(typeof(Outline))]
public class ButtonSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Outline _outline;
    private Sound _sound;

    [Inject]
    private void Construct(Sound sound)
    {
        _sound = sound;
    }

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.effectColor = Color.black;
        _outline.effectDistance = new Vector2(8, 8);
        _outline.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _outline.enabled = true;
        _sound.Select();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _outline.enabled = false;
    }
}
