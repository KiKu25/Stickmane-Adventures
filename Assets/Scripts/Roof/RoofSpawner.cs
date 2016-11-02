using UnityEngine;
using System.Collections;

public class RoofSpawner : MonoBehaviour
{

    //Lai uz dulo izveletos roofs augstumu
    float roofNormalHight = -14f;
    public float minRoofY = -14.6f;
    public float maxRoofY = -11.6f;

    //Lai uz dulo izvleltos atsparpi starp roofs
    public int minRoofOffset = 13;
    public int maxRoofOffset = 20;

    public int maxRoofs;      //Lai zinatu maxRoofs

    public Transform roofTemp;      //Pagaidu roofPrefab
    public Transform lastRoofTemp;

    Vector3 lastRoofSpawnPosition;      //Lai zinatu kur spaned last roof

    // Use this for initialization
    void Start()
    {
        Instantiate(roofTemp, new Vector3(18, roofNormalHight, 0), Quaternion.identity);     //Spawn pirmo roof uz x = 18, y = -14
        lastRoofSpawnPosition = new Vector3(18, roofNormalHight, 0);     //Saglaba pedeja roof 
        SpawnRoofs(maxRoofs);
    }


    void Update()
    {

    }

    //Spawn roof ik pec notiekta laika
    void SpawnRoofs(int maxRoofs = 15)
    {
        for (int i = 0; i <= maxRoofs; i++)
        {
            Vector3 nextSpawn = new Vector3(lastRoofSpawnPosition.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0);     //Izvelas rangom position, notiktos ierobezojumos, lai zintu kur spawn roof
            Instantiate(roofTemp, nextSpawn, Quaternion.identity);      //Spawn roof uz random position, notiktos ierobezojumos
            lastRoofSpawnPosition = nextSpawn;
        }
        Instantiate(lastRoofTemp, new Vector3(lastRoofSpawnPosition.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0), Quaternion.identity);
    }
}
