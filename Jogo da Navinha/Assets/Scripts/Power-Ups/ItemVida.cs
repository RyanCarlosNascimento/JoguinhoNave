using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour
{
    // Configurações de Cura
    [SerializeField] 
    private int quantidadeVidas;
    [SerializeField] 
    private ParticleSystem particulaPrefab;

    // Movimento
    public Rigidbody2D rb; // Uso para fazer o item cair
    public float velocidadeQueda; // O quão rápido a vida cai

    public int QuantidadeVidas {
        get { 
            return this.quantidadeVidas; 
        }
    }

    void Start()
    {
        // Aplica uma velocidade contínua para baixo (Y negativo para descer)
        this.rb.linearVelocity = new Vector2(0, -this.velocidadeQueda);
    }

    void Update()
    {
        // LÓGICA DE SUMIR QUANDO TOCAR NA BORDA INFERIOR 
        Camera camera = Camera.main;
        // Converte a posição do item no mundo para a posição na tela (0 a 1)
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        
        // Se o Y for menor que 0, significa que ele passou do limite da tela (borda inferior)
        if (posicaoNaCamera.y < 0) {
            Destroy(this.gameObject); // Apaga o item 
        }
    }

    public void Coletar() 
    {
        ParticleSystem particula = Instantiate(this.particulaPrefab, this.transform.position, Quaternion.identity);
        Destroy(particula.gameObject, 1f); // Destrói o efeito de particula executado após 1 segundo 
        
        FindObjectOfType<ControladorAudio>().TocarSomVidaColetada();
        Destroy(this.gameObject); // Destrói o item ao ser coletado
    }
}