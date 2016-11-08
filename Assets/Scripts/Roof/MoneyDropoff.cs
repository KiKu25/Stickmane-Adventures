using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyDropoff : MonoBehaviour {

    public int totalMoney { get; protected set; }   //Kopeja nozakta nauda

    //Bag transform
    Transform bag;

    //Player
    Player player;

    //Bag script
    Bag bagScript;

    //Texts
    Text monyFild;

	// Use this for initialization
	void Start () {
        //Atrod player
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();
        //Atdod pareizo text field
        monyFild = GameObject.FindGameObjectWithTag("Money_Ui").GetComponent<Text>();
    }
    
    //Parbauda kad kad ieiet colider
    void OnTriggerEnter2D(Collider2D col)
    {
        //Parbauda vai player ieiet
        if (col.CompareTag("Player"))
        {
            //Parbaud vai player ir soma
            if (player.hasBag == true)
            {
                //Call dropoff bag
                DropoffBag();
            }
        }
    }

    //Parbauda kad kad paliek colider
    void OnTriggerStay2D(Collider2D col)
    {
        //Parbauda vai player ieiet
        if (col.CompareTag("Player"))
        {
            //Parbaud vai player ir soma
            if (player.hasBag == true)
            {
                //Call dropoff bag
                DropoffBag();
            }
        }
    }

    //Lai "nomestu" naudu
    void DropoffBag()
    {
        bag = player.transform.GetChild(0);     //Dabu bag
        bagScript = bag.GetComponent<Bag>();    //Babu bagScript
        totalMoney += bagScript.money;      //Dabu un set naudu
        Destroy(bag.gameObject);        //Iznicina bag

        player.hasBag = false;      //Seto kad player nav soma
        UpdateUi();     //Update Ui
    }

    //Atkjauno Ui
    void UpdateUi()
    {
        monyFild.text = ("Money Stolen: " + totalMoney);        //Lai redzetu cik naudas nozakts
    }
}
