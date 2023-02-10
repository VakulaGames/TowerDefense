using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private Button _soundButton;
    [SerializeField] private SoundButton _soundSB;

    [SerializeField] private Button _musicButton;
    [SerializeField] private SoundButton _musicSB;

    private Sound _sound;

    [Inject]
    private void Construct(Sound sound)
    {
        _sound = sound;
    }

    private void OnEnable()
    {
        _soundButton.onClick.AddListener(OnSound);
        _musicButton.onClick.AddListener(OnMusic);
    }

    private void OnDisable()
    {
        _soundButton.onClick.RemoveListener(OnSound);
        _musicButton.onClick.RemoveListener(OnMusic);
    }

    private void OnMusic()
    {
        if (_musicSB.IsEnable == true)
        {
            _musicSB.Enable(false);
            _sound.EnableMusic(false);
        }
        else
        {
            _musicSB.Enable(true);
            _sound.EnableMusic(true);
        }
    }

    private void OnSound()
    {
        if (_soundSB.IsEnable == true)
        {
            _soundSB.Enable(false);
            _sound.EnableSound(false);
        }
        else
        {
            _soundSB.Enable(true);
            _sound.EnableSound(true);
        }
    }
}
