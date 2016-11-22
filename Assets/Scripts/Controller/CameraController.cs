using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    //float speed = 2.0f;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        //Parvito kameru
        //transform.position += Vector3.right * speed * Time.deltaTime;
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
	}
}
