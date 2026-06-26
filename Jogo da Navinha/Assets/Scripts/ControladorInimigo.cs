using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorInimigo : MonoBehaviour
{
    public Inimigo inimigoGarrafaPrefab; // Referência para as cópias
    public Inimigo inimigoAlienigenaPrefab;
    private float tempoDecorrido;
    void Start()
    {
        this.tempoDecorrido = 0;
    }

    void Update()
    {
        this.tempoDecorrido += Time.deltaTime;
    if (this.tempoDecorrido >= 1f) {
        this.tempoDecorrido = 0;

        // ViewportToWorldPoint transforma (0,0) em baixo-esquerda e (1,1) em cima-direita no MUNDO
        Vector2 posicaoMaxima = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 posicaoMinima = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        float posicaoX = Random.Range(posicaoMinima.x, posicaoMaxima.x);
        
        // Adicionamos um pequeno offset no Y para ele nascer um pouco acima da borda
        Vector2 posicaoInimigo = new Vector2(posicaoX, posicaoMaxima.y + 1f);

        Inimigo prefabInimigo;

        float chance = Random.Range(0f,100f);
        if (chance <= 20) { // 20% de chance de criar o inimigo grande
            prefabInimigo = this.inimigoAlienigenaPrefab;
        } else {
            prefabInimigo = this.inimigoGarrafaPrefab;        
        }


        Instantiate(prefabInimigo, posicaoInimigo, Quaternion.identity);
        }
    }
}