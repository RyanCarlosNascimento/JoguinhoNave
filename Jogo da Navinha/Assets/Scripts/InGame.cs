using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{

    public Text textoPontuacao;
    public BarraVida barraVida;
    
    [SerializeField]
    private TelaPause telaPause;

    private NaveJogador jogador;

    private void Start() {
        this.jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<NaveJogador>();
    }
    // Update is called once per frame
    void Update()
    {
        this.barraVida.ExibirVida(this.jogador.Vida);
        this.textoPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
    }

    public void Pausar() {
        this.telaPause.Ativar();
    }
}