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
        WorldTraveller traveller = FindObjectOfType<WorldTraveller>();
        traveller.onEnterEncounterEvent.AddListener(onEnterEncounterHandler);
        traveller.onEnterEncounterEvent.AddListener(onExitEncounterHandler);
        Instance.PlayTrack(TrackID.Overworld);
    }
    private void onEnterEncounterHandler()
    {
        PlayTrack(TrackID.Battle);
    }
    private void onExitEncounterHandler()
    {
        StartCoroutine(FadeInTrackOverDuration(TrackID.Overworld,1.0f));
        
    }
    IEnumerator FadeInTrackOverDuration(TrackID track,float duration)
    {
        PlayTrack(track);
        float timer=0.0f;
        while(timer<duration)
        {
            timer += Time.deltaTime;
            float fadeValue = timer / duration;
            musicSource.volume = Mathf.SmoothStep(0.0f,1.0f, fadeValue);
            yield return new WaitForEndOfFrame();
        }
        
       
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
