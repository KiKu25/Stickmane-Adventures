using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyDropoff : MonoBehaviour {

    public int totalMoney { get; protected set; }

    Transform bag;

    Player player;

    Bag bagScript;

    Text monyFild;

	// Use this for initialization
	void Start () {

        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();
        monyFild = GameObject.FindGameObjectWithTag("Money_Ui").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Why you no work");
        if (col.CompareTag("Player"))
        {
            Debug.Log("Darbauda player hasBag");
            if (player.hasBag == true)
            {
                DropoffBag();
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("Darbauda player hasBag");
            if (player.hasBag == true)
            {
                DropoffBag();
            }
        }
    }

    void DropoffBag()
    {
        Debug.Log("Doing stuff");
        bag = player.transform.GetChild(0);
        bagScript = bag.GetComponent<Bag>();
        totalMoney += bagScript.money;
        Destroy(bag.gameObject);

        player.hasBag = false;
        UpdateUi();
    }

    void UpdateUi()
    {
        monyFild.text = ("Money Stolen: " + totalMoney);
    }
}
