using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Vou fazer uma classe estática
public class ControladorPontuacao
{
    private static int pontuacao; // Variavel para armazenar esse valor
    public static int Pontuacao {
        get { // Get para retornar esse valor
            return pontuacao;        
        }
        set { // Set para alterar esse valor quando precisar
            pontuacao = value;
            if (pontuacao < 0){
                pontuacao = 0; // Volto para zero para impedir valores negativos.
            }

            if (pontuacao > MelhorPontuacao) {
                MelhorPontuacao = pontuacao;
            }    
        }
    }
    public static int MelhorPontuacao {
        get {
            int MelhorPontuacao = PlayerPrefs.GetInt("melhorPontuacao", 0);
            return MelhorPontuacao;
        }
        set {
            if (value > MelhorPontuacao) {
                PlayerPrefs.SetInt("melhorPontuacao", value);
            }   
        }
    }
}