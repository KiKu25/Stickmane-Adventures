using UnityEngine;
using System.Collections;

public class BagSpawner : MonoBehaviour {

    public int maxBags;

    public float minX;
    public float maxX;

    public Transform bag;

    GameObject bags;
    
	// Use this for initialization
	void Start () {
        bags = new GameObject("Bags");

        spawnBags(maxBags);  
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnBags(int spawnCount = 6)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Transform bagTran;
             
            bagTran = (Transform)Instantiate(bag, new Vector3(transform.position.x + Random.Range(minX, maxX), transform.position.y + 0.5f, transform.position.z), Quaternion.identity);

            bagTran.SetParent(bags.transform);
        }
    }
}


