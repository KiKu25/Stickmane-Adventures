using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player player;

    public float maxRunSpeed = 6f;     //Player max run speed
    public float speed = 50f;   //Paatrinajaums
    public float jumpPower = 150f;  //Leksanas speks

    public bool grounded;   //Lai zinatu vai player ir uz zemes
    public bool hasBag { get; set; } //Lai ainatu vai player ir bag
    public bool facingRight { get; protected set; } //Lai zinatu uz kuru pusi player skatas

    public string animationName;

    Rigidbody2D rb2d;   //Player rigedbody

    Animator anim;  //Player animation controller

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();     //Dabu player rigedbody
        anim = GetComponent<Animator>();    //Dabu animation controller
        hasBag = false;     //Player nav soma

        animationName = GameControl.control.playerAnimationName;

        anim.runtimeAnimatorController = Resources.Load("Animations/Player/" + animationName) as RuntimeAnimatorController;
	}

    void Update()
    {
        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
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
        if (col.CompareTag("Roof") || col.CompareTag("Bank") || col.CompareTag("Bag"))
        {
            grounded = true;
        }
    }
    //Parbuda vai player ir uz zemi
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Roof") || col.CompareTag("Bank") || col.CompareTag("Bag"))
        {
            grounded = true;
        }
    }
    //Parbuda vai player ir uz zemi
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Roof") || col.CompareTag("Bank") || col.CompareTag("Bag"))
        {
            grounded = false;
        }
    }
}
