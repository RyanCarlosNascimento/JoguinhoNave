using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float velocidadeY;

    void Start()
    {
        // Se a arma não falar nada, ele atira para frente (cima) como padrão
        DefinirDirecao(this.transform.up); 
        FindObjectOfType<ControladorAudio>().TocarSomLaser();
    }

    // A arma espalhada vai usar isso para mandar o laser para os lados 
    public void DefinirDirecao(Vector2 direcao)
    {
        this.transform.up = direcao; // Gira a imagem do laser
        this.rigidbody.linearVelocity = direcao * this.velocidadeY; // Empurra na direção certa usando a sua variável
    }

    private void Update() {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        
        // Se o laser saiu da tela pela parte superior OU pelas LATERAIS
        // (Isso é importante agora porque o tiro espalhado vai para os lados!)
        if (posicaoNaCamera.y > 1 || posicaoNaCamera.x < 0 || posicaoNaCamera.x > 1) {
            // Destrói o próprio laser
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collider) { //Quando qualquer coisa colidir com laser
        if (collider.CompareTag("Inimigo")) {  // Verifica se o tiro colidiu com um objt com a tag inimigo
            // Destrói o inimigo
            Inimigo inimigo = collider.GetComponent<Inimigo>(); // Se sim vamos buscar a classe inimigo
            inimigo.ReceberDano(); // Destrói o inimigo.
            
            // Destrói o próprio laser:
            Destroy(this.gameObject);
        }
    }
}