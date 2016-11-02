using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour
{
    public Collider2D col1;
    public Collider2D col2;

    public int money { get; set; }

    Rigidbody2D rd2d;

    Player player;

    // Use this for initialization
    void Start()
    {
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();

        rd2d = GetComponent<Rigidbody2D>();

        money = 45000;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        { 
            if (player.hasBag == false)
            {
                transform.SetParent((GameObject.FindGameObjectWithTag("Player")).transform);
                transform.localPosition = new Vector3(-0.512f, 0.063f, 0);
                transform.localEulerAngles = new Vector3(0, 0, 87.475f);
                player.hasBag = true;
                col1.enabled = false;
                col2.enabled = false;
                rd2d.isKinematic = true;
            }
        }
    }
}
