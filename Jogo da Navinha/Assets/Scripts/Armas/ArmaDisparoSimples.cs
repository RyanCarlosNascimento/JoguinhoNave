using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaDisparoSimples : ArmaBasica
{
    protected override void Atirar()
    {
        CriarLaser(this.posicoesDisparo[0].position);
    }
}