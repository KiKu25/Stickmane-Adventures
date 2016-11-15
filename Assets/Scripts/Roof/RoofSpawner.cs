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
    public int maxBackgrounds;      //Lai zinatu cik maxBackrounds 

    float spriteWidthNextSpawn;

    public Transform roof_1;      //Pagaidu roofPrefab
    public Transform lastRoofTransform;      //Pedejais roof ar dropoff
    public Transform background;        //Backround

    SpriteRenderer backgroundSprite;    //Lai varetu uzinat sprite size

    // Use this for initialization
    void Start()
    {
        SpawnRoofs(maxRoofs);   //Call spawnRoof

        if (background != null)     //Parbauda vai backround nav null
        {
            backgroundSprite = background.GetComponent<SpriteRenderer>();   //Dabu backround sprite
            spriteWidthNextSpawn = backgroundSprite.sprite.rect.width / 28.926f;    //Uzina background makoso spawn offset
            SpawnBackground(maxBackgrounds);    //Call spawnBackground
        }
    }

    //Spawn roof ik pec notiekta offset
    void SpawnRoofs(int maxRoofs = 10)
    {
        Vector3 spawn = new Vector3(18, roofNormalHight, 0);    //Lai zinatu kura soawnRoofs

        for (int i = 0; i < maxRoofs; i++)  //SpawnRoofs noteikut skaitu
        {
            Instantiate(roof_1, spawn, Quaternion.identity);  //spawnRoof 
            spawn = new Vector3(spawn.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0);     //Saglaba nakoso Vector3
        }

        Instantiate(lastRoofTransform, spawn, Quaternion.identity);  //spawnLast roof
    }

    //Spawn backround ik pec notiekta offset
    void SpawnBackground(int maxBackground = 6)
    {
        Vector3 spawn = new Vector3(0, 0, 0);   //Pirma backround Vector3

        for (int i = 0; i < maxBackground; i++)     //SpawnBackground notiektu skaitu
        { 
            Instantiate(background, spawn, Quaternion.identity);    //SpanwBackround
            spawn = new Vector3(spawn.x + spriteWidthNextSpawn, 0, 0);      //Saglaba nakos spawn Vector3
        }
    }
}
