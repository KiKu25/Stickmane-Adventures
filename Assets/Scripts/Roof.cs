using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Roof : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.tag);
        if (col.CompareTag("Player"))
        {

            SceneManager.LoadScene("_SCENE");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("_SCENE");
        }
    }
}
