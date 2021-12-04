using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSounds : MonoBehaviour
{
    [SerializeField]
    private List<AudioClip> footstepSoundClips;
    [SerializeField]
    private AudioSource soundSource;
    [SerializeField]
    private float pitchVariance = 0.15f;
    void PlayRandomFootstep()
    {
        soundSource.clip = footstepSoundClips[Random.Range(0, footstepSoundClips.Count)];
        soundSource.pitch = 1.0f + Random.Range(-pitchVariance, pitchVariance);
        soundSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
