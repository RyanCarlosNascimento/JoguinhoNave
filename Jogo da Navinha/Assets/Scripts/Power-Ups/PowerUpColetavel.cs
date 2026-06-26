using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class PowerUpColetavel : MonoBehaviour
{
    // Movimento
    public Rigidbody2D rb;
    public float velocidadeQueda; 

    //Efeito Visual
    public ParticleSystem particulaColetaPrefab; // A caixinha para o seu efeito!

    public abstract EfeitoPowerUp EfeitoPowerUp { get; }

    void Start()
    {
        this.rb.linearVelocity = new Vector2(0, -this.velocidadeQueda);
    }

    void Update()
    {
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        
        if (posicaoNaCamera.y < 0) {
            Destroy(this.gameObject);
        }
    }

    public void Coletar() 
    {
        // Cria a partícula na posição do item sem rotacionar
        ParticleSystem particula = Instantiate(this.particulaColetaPrefab, this.transform.position, Quaternion.identity);
        
        // Destrói a partícula da memória depois de 1 segundo (igualzinho no Inimigo)
        Destroy(particula.gameObject, 1f); 

        // Destrói o item
        FindObjectOfType<ControladorAudio>().TocarSomPowerUpColetado();
        Destroy(this.gameObject); 
    }
}