using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movimiento
    public float speed;
    private Vector2 movimiento;
    private Rigidbody2D rb2D;

    void Start()
    { //asignamos el rigigbody del player
        rb2D = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Capturamos la entrada del jugador usando inputs preestablecidos
        movimiento = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        //la normalizamos para que  la diagonal no sea mas rapida que el movimiento vertical y horizontal
    }
    private void FixedUpdate()
    {
        //hacemos que el rigidbody cambie de posicion y que sea un movimiento más suave
        rb2D.MovePosition(rb2D.position + movimiento * speed * Time.fixedDeltaTime);
        
    }
}
