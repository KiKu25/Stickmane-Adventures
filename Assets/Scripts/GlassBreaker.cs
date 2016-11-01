using UnityEngine;
using System.Collections;

public class GlassBreaker : MonoBehaviour
{

    SpriteRenderer spriteRenderer;

    public Collider2D collider;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("Bank/Glass_Broken");
        DisableCollider();
    }

    void OnStayEnter2D(Collider2D col)
    {
        spriteRenderer.sprite = Resources.Load<Sprite>("Bank/Glass_Broken");
        DisableCollider();
    }

    void DisableCollider()
    {
        collider.enabled = false;
    }
}
