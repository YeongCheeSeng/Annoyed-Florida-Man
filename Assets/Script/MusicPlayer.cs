using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource _AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        PlaySoundEffect();
    }

    public void PlaySoundEffect()
    {
        if (_AudioSource == null)
            _AudioSource.Play();
    }
}
