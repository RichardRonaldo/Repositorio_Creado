using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D rb;
    private float velocidad = 0.1f;
    private int vidaBala1 = 5;
    private int vidaBala2 = 3;
    private bool bala1 = false;
    private bool bala2 = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        if (bala1)
        {
            if (vidaBala1 == 0)
                Destroy(this.gameObject);
            bala1 = false;
        }
        if (bala2)
        {
            if (vidaBala2 == 0)
                Destroy(this.gameObject);
            bala2 = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.layer == 6)
        {
            vidaBala1--;
            bala1 = true;
            Destroy(collision2D.gameObject);
        }
        if (collision2D.gameObject.layer == 7)
        {
            vidaBala2--;
            bala2 = true;
            Destroy(collision2D.gameObject);
        }
        if (collision2D.gameObject.layer == 3)
        {
            Destroy(collision2D.gameObject);
            Destroy(this.gameObject);
        }
    }
}
