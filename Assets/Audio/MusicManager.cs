using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hide constructor, add a static instance, a public getter, and no setter
public class MusicManager : MonoBehaviour
{
    private MusicManager() { }
    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            { 
                instance = FindObjectOfType<MusicManager>();
                DontDestroyOnLoad(Instance.transform.root);
            }
            return instance;
        }
        private set { instance = value; }
    }
    [SerializeField]
    List<AudioClip> musicTracks;
    [SerializeField]
    AudioSource musicSource;
    public enum TrackID
    {
        Overworld=0,
        Battle=1
    }
    public void PlayTrack(TrackID id)
    {
        musicSource.clip = musicTracks[(int)id];
        musicSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        Instance.PlayTrack(TrackID.Overworld);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
