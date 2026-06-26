using UnityEngine;

public class ControladorAudio : MonoBehaviour
{
    // Efeitos Sonoros
    [SerializeField] 
    private AudioClip danoEscudo;
    [SerializeField] 
    private AudioClip danoJogador;
    [SerializeField] 
    private AudioClip derrotaJogador;
    [SerializeField] 
    private AudioClip explosaoInimigo;
    [SerializeField] 
    private AudioClip laser;
    [SerializeField] 
    private AudioClip powerUpColetado;
    [SerializeField] 
    private AudioClip vidaColetada;

    // Componentes
    [SerializeField] 
    private AudioSource audioSource;

    // Método principal que toca o som de uma vez só (PlayOneShot), ele permite sons simultâneos
    private void TocarSom(AudioClip clip, float volume = 1f) {
        this.audioSource.PlayOneShot(clip, volume);
    }

    // Métodos públicos que os outros scripts vão chamar:
    public void TocarSomLaser() { 
        // Reduzir o volume do laser para 0.15f para não ficar ensurdecedor
        TocarSom(this.laser, 0.15f); 
    }
    public void TocarSomDanoEscudo() { 
        TocarSom(this.danoEscudo); 
    }
    public void TocarSomDanoJogador() {
         TocarSom(this.danoJogador); 
    }
    public void TocarSomDerrotaJogador() { 
        TocarSom(this.derrotaJogador); 
    }
    public void TocarSomExplosaoInimigo() { 
        TocarSom(this.explosaoInimigo); 
    }
    public void TocarSomPowerUpColetado() { 
        TocarSom(this.powerUpColetado); 
    }
    public void TocarSomVidaColetada() { 
        TocarSom(this.vidaColetada); 
    }
}