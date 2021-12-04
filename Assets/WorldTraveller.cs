using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldTraveller : MonoBehaviour
{
    public string spawnLocation = null;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoadedAction;
    }

    void OnSceneLoadedAction(Scene scene, LoadSceneMode loadmode)
    {
        if (spawnLocation != null)
        {
            SpawnPoint[] spawns = FindObjectsOfType<SpawnPoint>();
            foreach (SpawnPoint spawnPoint in spawns)
            {
                if(spawnPoint.tag == spawnLocation)
                {
                    transform.position = spawnPoint.transform.position;
                    break;
                }
            }
        }

#if UNITY_EDITOR
        //Find all other bobs and destroy them... 
        //Hacky way to allow you the convenience of having a Bob in every scene
        WorldTraveller[] impostors = FindObjectsOfType<WorldTraveller>();
        foreach(WorldTraveller impostor in impostors)
        {
            if(impostor != this)
            {
                Destroy(impostor);
            }
        }
#endif
    }
    public void EnterEncounter()
    {
        SceneManager.LoadScene("EncounterScene");
    }
    public void ExitEncounter()
    {
        SceneManager.LoadScene("Overworld");
    }
}
