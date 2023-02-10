using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioClip[] _clips;

    public void Select()
    {
        _soundSource.clip = _clips[0];
        _soundSource.Play();
    }
    
    public void Click()
    {
        _soundSource.clip = _clips[1];
        _soundSource.Play();
    }

    public void EnableMusic(bool enable)
    {
        Debug.Log(enable);

        if (enable)
            _mixer.SetFloat("MusicVolume", 1);
        else
            _mixer.SetFloat("MusicVolume", 0);
    }
    
    public void EnableSound(bool enable)
    {
        if (enable)
            _mixer.SetFloat("SoundVolume", 1);
        else
            _mixer.SetFloat("SoundVolume", 0);
    }
}
