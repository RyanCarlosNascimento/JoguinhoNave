using UnityEngine;

public class EfeitoPowerUpDisparoEspalhado : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        jogador.EquiparArmaDisparoEspalhado(); 
    }
}