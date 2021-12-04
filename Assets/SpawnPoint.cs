using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    static PlayerBehaviour player = null;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            GameObject newPlayerSpawned = Instantiate(playerPrefab, transform.position, transform.rotation);
            player = newPlayerSpawned.GetComponent<PlayerBehaviour>();
        }
    }
}
