using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorMouse : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; 
    
    [SerializeField]
    private float velocidadeMovimento;

    private Camera camera;

    void Start()
    {
        this.camera = Camera.main;
    }

    void Update()
    {
        Vector2 posicaoMouse = Input.mousePosition;
        Vector2 posicaoMundo = this.camera.ScreenToWorldPoint(posicaoMouse);

        Vector2 novaPosicao = Vector2.Lerp(
            this.transform.position, 
            posicaoMundo, 
            this.velocidadeMovimento * Time.deltaTime
        );

        this.rb.MovePosition(novaPosicao);
    }
}