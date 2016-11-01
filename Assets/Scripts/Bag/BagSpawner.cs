using UnityEngine;
using System.Collections;

public class BagSpawner : MonoBehaviour {

    public int maxBags;

    float x;
    float y;
    float z;

	// Use this for initialization
	void Start () {
        x = transform.position.x;
        y = transform.position.y;
        z = transform.position.z;

        spawnBags(maxBags);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnBags(int spawnCount = 6)
    {
        
    }
}
