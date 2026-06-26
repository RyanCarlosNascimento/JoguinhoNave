using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Rigidbody2D rigidbody;
    public float velocidadeMinima;
    public float velocidadeMaxima;
    public int vidas;
    public ParticleSystem particulaExplosaoPrefab;
    
    [SerializeField]
    [Range(0,100)]
    private float chanceSoltarItemVida;
    
    [SerializeField]
    private ItemVida itemVidPrefab;

    // Drop de Power-Up
    [Header("Drop de Power-Up")]
    [SerializeField] private float chanceSoltarPowerUp; 
    [SerializeField] private PowerUpColetavel[] powerUpPrefabs; 

    private float velocidadeY; 
    
    void Start() {
        Vector2 posicaoAtual = this.transform.position;
        float metadeLargura = Largura / 2f;

        float pontoReferenciaEsquerda = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireita = posicaoAtual.x + metadeLargura; 

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); 
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); 

        if (pontoReferenciaEsquerda < limiteInferiorEsquerdo.x) {
            float posicaoX = limiteInferiorEsquerdo.x + metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y); 
        } else if (pontoReferenciaDireita > limiteSuperiorDireito.x) {
            float posicaoX = limiteSuperiorDireito.x - metadeLargura;
            this.transform.position = new Vector2(posicaoX, posicaoAtual.y); 
        }
        
        this.velocidadeY = Random.Range(this.velocidadeMinima, this.velocidadeMaxima); 
    }

    void Update()
    {
        this.rigidbody.linearVelocity = new Vector2(0, -this.velocidadeY); 
        
        Camera camera = Camera.main;
        Vector3 posicaoNaCamera = camera.WorldToViewportPoint(this.transform.position);
        
        if (posicaoNaCamera.y < 0) { 
            NaveJogador jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>(); 
            jogador.Vida--; 
            Destruir(false); 
        }
    }
    
    public void ReceberDano() {
        this.vidas--;
        if (this.vidas <= 0) {
            FindObjectOfType<ControladorAudio>().TocarSomExplosaoInimigo();
            Destruir(true);
        }
    }

    private float Largura {
        get {
            Bounds bounds = this.spriteRenderer.bounds;
            Vector3 tamanho = bounds.size;
            return tamanho.x;
        }
    }

    private void Destruir(bool derrotado) { 
        if (derrotado) {
            ControladorPontuacao.Pontuacao++; 
            SoltarItemVida();
            SoltarPowerUp(); // OBS: Agora ele chama o método de soltar a arma ao ser derrotado!
        }

        ParticleSystem particulaExplosao = Instantiate(this.particulaExplosaoPrefab, this.transform.position, Quaternion.identity);
        Destroy(particulaExplosao.gameObject, 1f); 
        Destroy(this.gameObject); 
    }

    private void SoltarItemVida() {
        float chanceAleatoria = Random.Range(0,100);
        if (chanceAleatoria <= this.chanceSoltarItemVida) {
            Instantiate(this.itemVidPrefab, this.transform.position, Quaternion.identity);
        }
    } 

    // OBS: Novo método adicionado para gerenciar a lógica do Power-Up
    private void SoltarPowerUp()
    {
        float chanceAleatoria = Random.Range(0f, 100f);

        if (chanceAleatoria <= this.chanceSoltarPowerUp)
        {
            // Sorteia entre o Duplo e o Alternado (ou quantos você colocar na lista)
            int indiceAleatorio = Random.Range(0, this.powerUpPrefabs.Length);
            PowerUpColetavel prefabEscolhido = this.powerUpPrefabs[indiceAleatorio];

            Instantiate(prefabEscolhido, this.transform.position, Quaternion.identity);
        }
    }
}