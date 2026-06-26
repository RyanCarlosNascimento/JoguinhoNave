using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    [SerializeField]
    private int protecaoTotal = 3; // Quantos tiros o escudo aguenta (Posso mudar no Unity!)
    
    private int protecaoAtual;

    public void Ativar()
    {
        this.protecaoAtual = this.protecaoTotal; // Recarrega a vida do escudo
        this.gameObject.SetActive(true); // Liga o visual
    }

    public void Desativar()
    {
        this.gameObject.SetActive(false); // Desliga o visual
    }

    public bool Ativo 
    {
        get { 
            return this.gameObject.activeSelf; 
        } 
    }

    public void ReceberDano()
    {
        this.protecaoAtual--; // Escudo leva o dano
        
        if (this.protecaoAtual <= 0)
        {
            this.Desativar(); // Quebra o escudo
        }
    }
}