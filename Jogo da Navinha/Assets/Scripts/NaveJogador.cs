using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJogador : MonoBehaviour
{
    private const int QuantidadeMaximaVidas = 7;

    public SpriteRenderer spriteRenderer;

    // Status
    private int vidas;
    private FimJogo telaFimJogo;

    // Armas
    [SerializeField] 
    private ControladorArma controladorArma; 

    // === VARIÁVEIS DO CRONÔMETRO ===
    // Tempo do Power-Up
    [SerializeField] 
    private float tempoDuracaoPowerUp = 5f; 
    private Coroutine cronometroAtual; 

    // Defesa
    [SerializeField] 
    private Escudo escudo;

    // Referência para o áudio
    private ControladorAudio controladorAudio;

    public int Vida {
        get { return this.vidas; }
        set {
            this.vidas = value;
            
            if (this.vidas > QuantidadeMaximaVidas) {
                this.vidas = QuantidadeMaximaVidas;
            } 
            else if (this.vidas <= 0) {
                this.vidas = 0;
                this.gameObject.SetActive(false); 
                telaFimJogo.Exibir(); 
                
                // === NOVO: Toca o som de derrota quando a vida chega a zero ===
                this.controladorAudio.TocarSomDerrotaJogador(); 
            }
        }
    }

    private float Largura { 
        get { 
            return this.spriteRenderer.bounds.size.x; 
        } 
    }
    private float Altura { 
        get { 
            return this.spriteRenderer.bounds.size.y; 
        } 
    }

    void Start()
    {
        this.Vida = 7; 
        ControladorPontuacao.Pontuacao = 0; 
    
        GameObject fimJogoGameObject = GameObject.FindGameObjectWithTag("TelaFimJogo");
        this.telaFimJogo = fimJogoGameObject.GetComponent<FimJogo>();
        this.telaFimJogo.Esconder();

        EquiparArmaDisparoSimples(); 

        // Guarda a referência do controlador de áudio assim que o jogo começa
        this.controladorAudio = FindObjectOfType<ControladorAudio>();
    }

    void Update()
    {
        VerificarLimiteTela(); 
    }

    private void VerificarLimiteTela() 
    {
        Vector2 posicaoAtual = this.transform.position; 
        float metadeLargura = Largura / 2f;
        float metadeAltura = Altura / 2f;

        Camera camera = Camera.main;
        Vector2 limiteInferiorEsquerdo = camera.ViewportToWorldPoint(Vector2.zero); 
        Vector2 limiteSuperiorDireito = camera.ViewportToWorldPoint(Vector2.one); 

        float pontoReferenciaEsquerdo = posicaoAtual.x - metadeLargura;
        float pontoReferenciaDireito = posicaoAtual.x + metadeLargura;

        if (pontoReferenciaEsquerdo < limiteInferiorEsquerdo.x) { 
            this.transform.position = new Vector2(limiteInferiorEsquerdo.x + metadeLargura, posicaoAtual.y);
        } else if (pontoReferenciaDireito > limiteSuperiorDireito.x){
            this.transform.position = new Vector2(limiteSuperiorDireito.x - metadeLargura, posicaoAtual.y);
        }

        posicaoAtual = this.transform.position;

        float pontoReferenciaSuperior = posicaoAtual.y + metadeAltura;
        float pontoReferenciaInferior= posicaoAtual.y - metadeAltura;

        if (pontoReferenciaSuperior > limiteSuperiorDireito.y) { 
            this.transform.position = new Vector2(posicaoAtual.x, limiteSuperiorDireito.y - metadeAltura);
        } else if (pontoReferenciaInferior < limiteInferiorEsquerdo.y) {
            this.transform.position = new Vector2(posicaoAtual.x, limiteInferiorEsquerdo.y + metadeAltura);
        }
    } 

    public void EquiparArmaDisparoAlternado() {
        this.controladorArma.EquiparArmaDisparoAlternado();
        ResetarCronometroPowerUp(); 
    }

    public void EquiparArmaDisparoDuplo() {
        this.controladorArma.EquiparArmaDisparoDuplo();
        ResetarCronometroPowerUp(); 
    }

    public void EquiparArmaDisparoSimples() {
        this.controladorArma.EquiparArmaDisparoSimples();
        
        if (this.cronometroAtual != null) {
            StopCoroutine(this.cronometroAtual);
        }
    }

    public void EquiparArmaDisparoEspalhado() {
        this.controladorArma.EquiparArmaDisparoEspalhado(); 
        ResetarCronometroPowerUp(); 
    }

    private void ResetarCronometroPowerUp() {
        if (this.cronometroAtual != null) {
            StopCoroutine(this.cronometroAtual);
        }
        
        this.cronometroAtual = StartCoroutine(ContagemRegressivaPowerUp());
    }

    private IEnumerator ContagemRegressivaPowerUp() {
        yield return new WaitForSeconds(this.tempoDuracaoPowerUp);
        EquiparArmaDisparoSimples();
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.CompareTag("Inimigo")) {
            
            if (this.escudo.Ativo) {
                this.escudo.ReceberDano();
                // === NOVO: Toca o som do escudo recebendo impacto ===
                this.controladorAudio.TocarSomDanoEscudo();
            } else {
                Vida--; 
                // === NOVO: Toca o som da nave levando dano ===
                this.controladorAudio.TocarSomDanoJogador();
            }
            
            collider.GetComponent<Inimigo>().ReceberDano(); 
        } 
        else if (collider.CompareTag("ItemVida")) {
            ItemVida itemVida = collider.GetComponent<ItemVida>();
            Vida += itemVida.QuantidadeVidas; 
            itemVida.Coletar(); 
        }
        else if (collider.CompareTag("PowerUp")) {
            PowerUpColetavel powerUp = collider.GetComponent<PowerUpColetavel>();
            ColetarPowerUp(powerUp);
        }
    }

    private void ColetarPowerUp(PowerUpColetavel powerUp)
    {
        EfeitoPowerUp efeito = powerUp.EfeitoPowerUp;
        efeito.Aplicar(this); 
        powerUp.Coletar(); 
    }

    public void AtivarEscudo() 
    {
        this.escudo.Ativar();
    }
}