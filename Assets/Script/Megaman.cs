using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Megaman : MonoBehaviour
{
    public GameObject Bala1;
    public GameObject Bala2;
    public GameObject Bala3;

    public GameObject Bala1I;
    public GameObject Bala2I;
    public GameObject Bala3I;

    private float switchColorDelay = .05f;
    private float switchColorTime = 0f;
    private float tiempo = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Transform _transform;
    private Animator animator;
    private Color originalColor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        originalColor = sr.color;
    }
    void Update()
    {
        sr.color = originalColor;
        rb.velocity = new Vector2(0, rb.velocity.y);
        Quieto();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            Correr();
            sr.flipX = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            Correr();
            sr.flipX = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(new Vector2(rb.velocity.x, 0.05f), ForceMode2D.Impulse);
            Salto();
        }
        if (Input.GetKey("x"))
        {
            Parpadear();
            tiempo += Time.deltaTime;
            Debug.Log(tiempo);
        }
        if (Input.GetKeyUp("x"))
        {
            if (tiempo >= 1 && tiempo < 3)
            {
                if (!sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala1, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala1I, BulletPosition, Quaternion.identity);
                }
            }
            if (tiempo >= 3 && tiempo < 5)
            {
                if (!sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala2, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala2I, BulletPosition, Quaternion.identity);
                }
            }
            if (tiempo >= 5 )
            {
                if (!sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x + 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala3, BulletPosition, Quaternion.identity);
                }
                if (sr.flipX)
                {
                    Ataca();
                    var BulletPosition = new Vector3(_transform.position.x - 0.1f, _transform.position.y, _transform.position.z);
                    Instantiate(Bala3I, BulletPosition, Quaternion.identity);
                }
            }
            tiempo = 1;
        }

    }

    private void Quieto()
    {
        animator.SetInteger("Estado", 0);
    }
    private void Correr()
    {
        animator.SetInteger("Estado", 1);
    }
    private void Salto()
    {
        animator.SetInteger("Estado", 2);
    }
    private void Ataca()
    {
        animator.SetInteger("Estado", 3);
    }
    private void Parpadear()
    {
        switchColorTime += Time.deltaTime;
        if (switchColorTime > switchColorDelay)
        {
            if (sr.color == originalColor)
                sr.color = Color.green;
            else
                sr.color = originalColor;
            switchColorTime = 0;
        }
    }
}
