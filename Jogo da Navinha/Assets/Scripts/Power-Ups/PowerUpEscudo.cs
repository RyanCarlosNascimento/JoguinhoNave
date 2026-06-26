using UnityEngine;

public class PowerUpEscudo : PowerUpColetavel
{
    public override EfeitoPowerUp EfeitoPowerUp {
        get { 
            return new EfeitoPowerUpEscudo(); 
        }
    }
}