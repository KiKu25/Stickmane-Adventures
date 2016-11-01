using UnityEngine;
using System.Collections;

public class Bag : MonoBehaviour
{
    public Collider2D col1;

    public int money { get; set; }

    Rigidbody2D rd2d;

    Player player;

    // Use this for initialization
    void Start()
    {
        player = (GameObject.FindGameObjectWithTag("Player")).GetComponent<Player>();

        rd2d = GetComponent<Rigidbody2D>();
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
                Debug.Log("Setting parent");
                transform.SetParent((GameObject.FindGameObjectWithTag("Player")).transform);
                transform.localPosition = new Vector3(-0.512f, 0.063f, 0);
                transform.localEulerAngles = new Vector3(0, 0, 87.475f);
                col1.enabled = false;
            }
        }
    }
}
