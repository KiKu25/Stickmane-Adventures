using UnityEngine;
using System.Collections;

public class HouseSpawner : MonoBehaviour {

    public int roofSpawnCoolDown;
    public int roofSpeed;

    public Transform roofTemp;

	// Use this for initialization
	void Start () {
        SpawnRoof();
	}
	
    
	void FixedUpdate () {
	
	}

    //Spawn roof ik pec notiekta laika
    void SpawnRoof(int roofSpawnCoolDown = 20, int roofSpeed = 10)
    {
        Instantiate(roofTemp, new Vector3(0, -11, 0), Quaternion.identity);
    }
}
