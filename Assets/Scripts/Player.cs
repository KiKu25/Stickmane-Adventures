using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float maxRunSpeed = 6f;     //Player max run speed
    public float speed = 50f;   //Paatrinajaums
    public float jumpPower = 150f;  //Leksanas speks

    public bool grounded;   //Lai zinatu vai player ir uz zemes
    public bool hasBag { get; set; } 

    Rigidbody2D rb2d;   //Player rigedbody

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();     //Dabu player rigedbody
        hasBag = false;
	}

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        //Ja uz zemes tad var lekt
        if (grounded) 
        {
            rb2d.drag = 10;
            if (Input.GetButtonDown("Jump"))
            {
                rb2d.AddForce(Vector2.up * jumpPower);
            }
        } else
        {
            rb2d.drag = 0;
        }
    }
	
	void FixedUpdate () {

        float horizontal = Input.GetAxis("Horizontal");

        //Player parvietosana
        rb2d.AddForce((Vector2.right * speed) * horizontal);

        //Parbauda vai player parvietojas parak atri
        if (rb2d.velocity.x > maxRunSpeed)
        {
            rb2d.velocity = new Vector2(maxRunSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxRunSpeed)
        {
            rb2d.velocity = new Vector2(-maxRunSpeed, rb2d.velocity.y);
        }
	}

    //Parbuda vai player ir uz zemi
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Roof") || col.CompareTag("Bank"))
        {
            grounded = true;
        }
    }
    //Parbuda vai player ir uz zemi
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Roof") || col.CompareTag("Bank"))
        {
            grounded = true;
        }
    }
    //Parbuda vai player ir uz zemi
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Roof") || col.CompareTag("Bank"))
        {
            grounded = false;
        }
    }
}
