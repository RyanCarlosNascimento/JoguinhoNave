using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    [SerializeField] 
    private ArmaBasica armaDisparoAlternado;
    [SerializeField] 
    private ArmaBasica armaDisparoDuplo;
    [SerializeField] 
    private ArmaBasica armaDisparoSimples;
    [SerializeField] 
    private ArmaBasica armaDisparoEspalhado;    private ArmaBasica armaAtual;

    private void Awake()
    {
        // Desliga todas as armas antes do jogo começar.
        this.armaDisparoAlternado.Desativar();
        this.armaDisparoDuplo.Desativar();
        this.armaDisparoSimples.Desativar();
        this.armaDisparoEspalhado.Desativar();
    }

    private void AlterarArmaAtual(ArmaBasica novaArma)
    {
        if (this.armaAtual != null) {
            this.armaAtual.Desativar();
        }

        this.armaAtual = novaArma;
        this.armaAtual.Ativar();
    }

    // MÉTODOS PARA OS POWER-UPS CHAMAREM 
    public void EquiparArmaDisparoAlternado() {
        AlterarArmaAtual(this.armaDisparoAlternado);
    }

    public void EquiparArmaDisparoDuplo() {
        AlterarArmaAtual(this.armaDisparoDuplo);
    }

    public void EquiparArmaDisparoSimples() {
        AlterarArmaAtual(this.armaDisparoSimples);
    }
    public void EquiparArmaDisparoEspalhado() {
        AlterarArmaAtual(this.armaDisparoEspalhado);
    }
}