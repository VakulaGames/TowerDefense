using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private GameObject _frame;
    
    public bool IsEnable { get; private set; }

    private void Start()
    {
        Enable(true);
    }

    public void Enable(bool enable)
    {
        if (enable)
        {
            IsEnable = true;
            _frame.SetActive(false);
        }
        else
        {
            IsEnable = false;
            _frame.SetActive(true);
        }
    }
}
