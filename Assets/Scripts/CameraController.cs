using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    float speed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Parvito kameru
        transform.position += Vector3.right * speed * Time.deltaTime;
	}
}
