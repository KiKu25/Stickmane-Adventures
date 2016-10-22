using UnityEngine;
using System.Collections;

public class RoofSpawner : MonoBehaviour {
  
    public float roofSpawnInterval;     //Lai zinatu pec cik ilga laika jaspawno jauns roof
    float lastSpawnTime;    //Lai zinatu, kad spawned pedejo roof

    //Lai uz dulo izveletos roofs augstumu
    float roofNormalHight = -14f;
    public float minRoofY = -14.6f;
    public float maxRoofY = -11.6f;

    //Lai uz dulo izvleltos atsparpi starp roofs
    public int minRoofOffset = 13;
    public int maxRoofOffset = 20;

    int maxRoofs = 14;      //Lai zinatu maxRoofs
    int curentRoofCount;    //Lai zinatu cik roof ir kopa

    public Transform roofTemp;      //Pagaidu roofPrefab

    Vector3 lastRoofSpawnPosition;      //Lai zinatu kur spaned last roof

    // Use this for initialization
    void Start () {     
        Instantiate(roofTemp, new Vector3(0, roofNormalHight, 0), Quaternion.identity);     //Spawn pirmo roof uz x = 0, y = -14
        lastRoofSpawnPosition = new Vector3(0, roofNormalHight, 0);     //Saglaba pedeja roof position
        lastSpawnTime = Time.deltaTime;     //Saglaba laiku kad spawnes last roof 
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
        if ((Time.deltaTime - lastSpawnTime) < roofSpawnInterval)   //Parbauda vai var spawn jaunu roof
        {
            Vector3 nextSpawn = new Vector3(lastRoofSpawnPosition.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0);     //Izvelas rangom position, notiktos ierobezojumos, lai zintu kur spawn roof
            Instantiate(roofTemp, nextSpawn, Quaternion.identity);      //Spawn roof uz rangom position, notiktos ierobezojumos
            curentRoofCount++;      //Palielina roofCount
            lastRoofSpawnPosition = nextSpawn;      
        }
    }  
}
