using UnityEngine;

public class EfeitoPowerUpDisparoDuplo : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoDuplo();
    }
}