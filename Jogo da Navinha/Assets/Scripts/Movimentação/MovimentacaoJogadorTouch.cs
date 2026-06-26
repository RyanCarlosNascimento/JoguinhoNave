using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoJogadorTouch : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb; 
    
    [SerializeField]
    private float velocidadeMovimento;

    private Camera camera;

    void Start()
    {
        // Define a câmera principal do jogo direto no Start (igual ao script do mouse)
        this.camera = Camera.main;
    }

    void Update()
    {
        // Verifica se existe pelo menos um dedo tocando na tela
        if (Input.touchCount > 0) 
        {
            // Pega a referência para o primeiro dedo que tocou na tela (índice 0)
            Touch toque = Input.GetTouch(0);

            // Pega a posição exata desse toque na tela
            Vector2 posicaoToque = toque.position;
            
            // Converte os pixels da tela para metros no mundo 2D
            Vector2 posicaoMundo = this.camera.ScreenToWorldPoint(posicaoToque);

            // Faz o "Lerp" (interpolação) para a nave seguir o dedo suavemente
            Vector2 novaPosicao = Vector2.Lerp(
                this.transform.position, 
                posicaoMundo, 
                this.velocidadeMovimento * Time.deltaTime
            );

            // Aplica a nova posição no Rigidbody
            this.rb.MovePosition(novaPosicao);
        }
    }
}