using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorTeclado : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidadeMovimento;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");     

        float velocidadeX = horizontal * this.velocidadeMovimento;
        float velocidadeY = vertical * this.velocidadeMovimento;

        this.rb.linearVelocity = new Vector2(velocidadeX, velocidadeY);
    }
}