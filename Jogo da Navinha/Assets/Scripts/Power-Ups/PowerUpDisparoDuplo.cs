using UnityEngine;

public class PowerUpDisparoDuplo : PowerUpColetavel
{
    public override EfeitoPowerUp EfeitoPowerUp {
        get { 
            return new EfeitoPowerUpDisparoDuplo(); 
        }
    }
}