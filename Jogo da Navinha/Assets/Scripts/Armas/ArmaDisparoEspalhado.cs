using UnityEngine;

public class ArmaDisparoEspalhado : ArmaBasica 
{
    [Range(1, 30)]
    [SerializeField] private int quantidadeDisparos = 5;
    
    [Range(0, 30)]
    [SerializeField] private float anguloEntreDisparos = 3f; // O professor usa 3 graus no vídeo 2

    protected override void Atirar()
    {
        for (int i = 0; i < this.quantidadeDisparos; i++)
        {
            // Pega a posição central (índice 0)
            Laser laser = CriarLaser(this.posicoesDisparo[0].position);
            
            // Calcula a direção usando a matemática do professor
            Vector2 direcao = CalcularDirecaoDisparo(i);

            // Manda o laser ir para a direção calculada
            laser.DefinirDirecao(direcao);
        }
    }

    private Vector2 CalcularDirecaoDisparo(int indiceDisparo)
    {
        float indiceDisparoArco;

        // Verifica se a quantidade é PAR ou ÍMPAR
        if (this.quantidadeDisparos % 2 == 0) {
            indiceDisparoArco = indiceDisparo + 1; // Pula o centro se for par
        } else {
            indiceDisparoArco = indiceDisparo; // Usa o centro se for ímpar
        }

        // Arredonda para cima para formar pares (ex: tiro 1 e 2 terão a mesma angulação base)
        float indiceArredondado = Mathf.CeilToInt(indiceDisparoArco / 2f);
        float angulo = this.anguloEntreDisparos * indiceArredondado;

        // Se o índice original for ÍMPAR, joga o ângulo para o lado negativo (inverte)
        if (indiceDisparo % 2 != 0) {
            angulo *= -1; 
        }

        // Converte o ângulo (graus) em uma rotação no eixo Z
        Quaternion rotacao = Quaternion.AngleAxis(angulo, Vector3.forward);

        // Multiplica a rotação pelo vetor "para cima" para obter a direção final
        return rotacao * Vector3.up;
    }
}