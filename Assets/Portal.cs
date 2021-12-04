using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WorldTraveller player = collision.GetComponent<WorldTraveller>();
        if (player)
        {
            player.spawnLocation = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(tag);
        }
    }
}
