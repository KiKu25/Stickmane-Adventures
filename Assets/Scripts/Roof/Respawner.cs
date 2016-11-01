using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Respawner : MonoBehaviour
{

    GameObject player;
    GameObject playerRespawner;
    GameObject bagRespawner;

    // Use this for initialization
    void Start()
    {

        if (playerRespawner == null)
            playerRespawner = GameObject.FindGameObjectWithTag("Player_Respawn");

        if (bagRespawner == null)
            bagRespawner = GameObject.FindGameObjectWithTag("Bag_Respawn");

        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.transform.position = new Vector3(playerRespawner.transform.position.x, playerRespawner.transform.position.y, playerRespawner.transform.position.z);
        }
        else if (col.CompareTag("Bag"))
        {
            col.gameObject.transform.position = new Vector3(bagRespawner.transform.position.x, bagRespawner.transform.position.y, bagRespawner.transform.position.z);
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            player.transform.position = new Vector3(playerRespawner.transform.position.x, playerRespawner.transform.position.y, playerRespawner.transform.position.z);
        }
        else if (col.CompareTag("Bag"))
        {
            col.gameObject.transform.position = new Vector3(bagRespawner.transform.position.x, bagRespawner.transform.position.y, bagRespawner.transform.position.z);
        }
    }
}
