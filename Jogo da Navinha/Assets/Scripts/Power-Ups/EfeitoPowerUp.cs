using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// OBS: Não herda de MonoBehaviour!
public abstract class EfeitoPowerUp
{
    // Todo efeito precisa saber como se aplicar ao jogador
    public abstract void Aplicar(NaveJogador jogador);
}