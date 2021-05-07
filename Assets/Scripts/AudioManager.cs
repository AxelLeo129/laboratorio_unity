using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip muerte_sfx;
    [SerializeField] private AudioClip punto_sfx;

    private new AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDeathSound()
    {
        audio.PlayOneShot(muerte_sfx);
    }

    public void PlayPointSound()
    {
        audio.PlayOneShot(punto_sfx);
    }

}
