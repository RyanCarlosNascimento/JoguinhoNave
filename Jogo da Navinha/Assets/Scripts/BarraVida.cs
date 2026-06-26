using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BarraVida : MonoBehaviour
{

    public GameObject[] barrasVerdes;


    public void ExibirVida(int vidas) {
        for (int i = 0; i < this.barrasVerdes.Length; i++) {
            if (i < vidas) {
                // Ativar barra verde
                this.barrasVerdes[i].SetActive(true);
            } else {
                // Desativar barra verde
                this.barrasVerdes[i].SetActive(false);
            }
        }
    }
}