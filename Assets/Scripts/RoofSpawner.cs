using UnityEngine;
using System.Collections;

public class RoofSpawner : MonoBehaviour {

    public float roofSpawnInterval;
    float lastSpawnTime;

    //Lai uz dulo izveletos roofs augstumu
    float roofNormalHight = -14f;
    float minRoofY = -14.6f;
    float maxRoofY = -11.6f;

    //Lai uz dulo izvleltos atsparpi starp roofs
    int minRoofOffset = 13;
    int maxRoofOffset = 20;

    int maxRoofs = 14;
    int curentRoofCount;

    public Transform roofTemp;

    Vector3 lastRoofSpawnPosition;

    // Use this for initialization
    void Start () {
        //Spawn pirmo roof uz x = 0, y = -14
        Instantiate(roofTemp, new Vector3(0, roofNormalHight, 0), Quaternion.identity);
        lastRoofSpawnPosition = new Vector3(0, roofNormalHight, 0);
        lastSpawnTime = Time.deltaTime;
    }
	
    
	void Update () {


        //Parbauda roofCount, ja vairak par 15 vai == 15,tad roof netiek spawned
        if (maxRoofs >= curentRoofCount)
        {
            SpawnRoof();
        }  
	}

    //Spawn roof ik pec notiekta laika
    void SpawnRoof(float roofSpawnInterval = 60.0f)
    {
        roofSpawnInterval -= Time.deltaTime;
        Vector3 nextSpawn = new Vector3(lastRoofSpawnPosition.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0);
        if ((Time.deltaTime - lastSpawnTime) < roofSpawnInterval)
        {
            Instantiate(roofTemp, nextSpawn, Quaternion.identity);
            curentRoofCount++;
            lastRoofSpawnPosition = nextSpawn;
        }
    }
}
