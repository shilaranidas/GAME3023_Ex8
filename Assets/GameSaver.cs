using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameSaver : MonoBehaviour
{
    public static UnityEvent OnSaveEvent = new UnityEvent();
    public static UnityEvent OnLoadEvent = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    public void Save()
    {
        OnSaveEvent.Invoke();
        PlayerPrefs.Save();
        Debug.Log("Saved!");
    }
    public void Load()
    {
        OnLoadEvent.Invoke();
        Debug.Log("Loaded!");
    }
}
