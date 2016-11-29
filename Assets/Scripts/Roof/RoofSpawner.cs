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

    GameObject roofs; //Lai butu kam uzlikt bernu
    GameObject backgrounds; //  Lai butu kam uzlikt bernu

    // Use this for initialization
    void Start()
    {
        roofs = new GameObject("Roofs");
        backgrounds = new GameObject("Backgrounds");

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
        Transform roof;

        Vector3 spawn = new Vector3(18, roofNormalHight, 0);    //Lai zinatu kura soawnRoofs

        for (int i = 0; i < maxRoofs; i++)  //SpawnRoofs noteikut skaitu
        {
            roof = (Transform)Instantiate(roof_1, spawn, Quaternion.identity);  //spawnRoof 
            spawn = new Vector3(spawn.x + Random.Range(minRoofOffset, maxRoofOffset), Random.Range(minRoofY, maxRoofY), 0);     //Saglaba nakoso Vector3
            roof.SetParent(roofs.transform);
        }

        roof = (Transform)Instantiate(lastRoofTransform, spawn, Quaternion.identity);  //spawnLast roof
        roof.SetParent(roofs.transform);
    }

    //Spawn backround ik pec notiekta offset
    void SpawnBackground(int maxBackground = 6)
    {
        Transform backgroundTran;

        Vector3 spawn = new Vector3(0, 0, 0);   //Pirma backround Vector3

        for (int i = 0; i < maxBackground; i++)     //SpawnBackground notiektu skaitu
        { 
            backgroundTran = (Transform)Instantiate(background, spawn, Quaternion.identity);    //SpanwBackround
            spawn = new Vector3(spawn.x + spriteWidthNextSpawn, 0, 0);      //Saglaba nakos spawn Vector3
            backgroundTran.SetParent(backgrounds.transform);
        }
    }
}
