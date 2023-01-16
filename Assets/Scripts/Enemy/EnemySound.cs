using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    private AudioSource _source;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    public void PlayHit()
    {
        _source.clip = _clips[0];
        _source.Play();
    }

    public void PlayDeath()
    {
        _source.clip = _clips[1];
        _source.Play();
    }
}
