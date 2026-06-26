using UnityEngine;

public class EfeitoPowerUpEscudo : EfeitoPowerUp
{
    public override void Aplicar(NaveJogador jogador)
    {
        jogador.AtivarEscudo(); // Chama aquele método que criei na nave Jogador!
    }
}