using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmaBasica : MonoBehaviour
{
    // Configurações Base
    public Laser laserPrefab;
    public float tempoEsperaTiro;
    private float intervaloTiro;

    public Transform[] posicoesDisparo; 

    public virtual void Start()
    {
        this.intervaloTiro = 0;
    }

    void Update()
    {
        this.intervaloTiro += Time.deltaTime;
        
        if (this.intervaloTiro >= this.tempoEsperaTiro) {
            this.intervaloTiro = 0;
            Atirar(); 
        }
    }

    protected Laser CriarLaser(Vector2 posicao) 
    {
        return Instantiate(this.laserPrefab, posicao, Quaternion.identity);
    }

    protected abstract void Atirar();

    public void Ativar() {
        this.gameObject.SetActive(true);
    }

    public void Desativar() {
        this.gameObject.SetActive(false);
    }
}