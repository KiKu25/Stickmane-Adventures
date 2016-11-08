using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour
{
    //Bag colider
    public Collider2D col1;
    public Collider2D col2;

    //Nauda kas atrodas soma
    public int money;

    //Bag rigidbody
    Rigidbody2D rd2d;

    //Player
    Player player;

    // Use this for initialization
    void Start()
    {
        //Atrod player
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();

        //Dabu rb2d
        rd2d = GetComponent<Rigidbody2D>();
    }

    //Lai zinatu vai player pacel somu
    void OnTriggerEnter2D(Collider2D col)
    {
        //Lai uzzinatu vai saskaras ar player
        if (col.CompareTag("Player"))
        { 
            //Parbauda vai player jau nav bag
            if (player.hasBag == false)
            { 
                transform.SetParent((GameObject.FindGameObjectWithTag("Player")).transform);    //Par vecaku uzliek player
                transform.localPosition = new Vector3(-0.512f, 0.063f, 0);      //Novieto relativi player
                transform.localEulerAngles = new Vector3(0, 0, 87.475f);        //Novito relativi player
                player.hasBag = true;       //Seto kad player ir soma
                col1.enabled = false;       //Seto colider off lai tas "nesaskartos" ar neko
                col2.enabled = false;       //Seto colider off lai neparbauditu visu laiku vai ar kadu colide
                rd2d.isKinematic = true;    //Lai soma nekristu
            }
        }
    }
}
