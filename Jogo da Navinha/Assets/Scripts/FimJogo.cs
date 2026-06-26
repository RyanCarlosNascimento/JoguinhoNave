using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Biblioteca para gerenciamento de cena
public class FimJogo : MonoBehaviour
{

    public Text textoPontuacao;
    public Text textoMelhorPontuacao;

    public void Exibir() {
        this.gameObject.SetActive(true); // Estamos ativando o game object dessa tela.
        this.textoPontuacao.text = (ControladorPontuacao.Pontuacao + "x");
        this.textoMelhorPontuacao.text = ControladorPontuacao.MelhorPontuacao.ToString();

        Time.timeScale = 0; // Pausar totalemente o jogo!
    }

    public void Esconder() {
        this.gameObject.SetActive(false);
    }
    
    public void TentarNovamente() {
        Time.timeScale = 1; // "Despausar" o jogo!
        SceneManager.LoadScene("Fase01"); // Vai ser carregada quando esse método TENTAR NOVAMENTE for chamado.
    }
}
