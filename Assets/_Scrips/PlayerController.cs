using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //pregunto si es el personaje1
    public bool player1;
    //movimiento del player
    public float speed = 3;
    //fisicas del player
    public Rigidbody2D rb;

    private float move;
    //para reiniciar posiciones
    private Vector2 startPos;

    private Touch toque;
    private float velocidad = 0.9f;
    
    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (player1 == true)
        {
            if (Input.touchCount > 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                toque = Input.GetTouch(0);
                if (mousePos.x < 1)
                {
                    if (toque.phase == TouchPhase.Moved)
                    {
                        transform.position = new Vector3
                            (transform.position.x, transform.position.y + toque.deltaPosition.y * velocidad * Time.deltaTime, transform.position.z);
                    }
                }
            }
           // if (Input.GetMouseButton(0))
           // {
           //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           //
           //     if (mousePos.x < 1)
           //     {
           //         if (mousePos.y > 0.05f)
           //         {
           //             transform.Translate(0, moveSpeedTouchControl, 0);
           //         }
           //         else if (mousePos.y < 0.05f)
           //         {
           //             transform.Translate(0, -moveSpeedTouchControl, 0);
           //         }
           //     }
           // }

            move = Input.GetAxisRaw("Vertical2");
        }

        if (player1 == false)
        {
            if (Input.touchCount > 0)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                toque = Input.GetTouch(0);
                if (mousePos.x > 1)
                {
                    if (toque.phase == TouchPhase.Moved)
                    {
                        transform.position = new Vector3
                            (transform.position.x, transform.position.y + toque.deltaPosition.y * velocidad * Time.deltaTime, transform.position.z);
                    }
                }
            }

            //if (Input.GetMouseButton(0))
            //{
            //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //
            //    if (mousePos.x > 1)
            //    {
            //        if (mousePos.y > 0.05f)
            //        {
            //            transform.Translate(0, moveSpeedTouchControl, 0);
            //        }
            //        else if (mousePos.y < 0.05f)
            //        {
            //            transform.Translate(0, -moveSpeedTouchControl, 0);
            //        }
            //    }
            //}

            move = Input.GetAxisRaw("Vertical1");

        }

        rb.velocity = new Vector2(rb.velocity.x, move * speed);
    }


    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
    }
}
