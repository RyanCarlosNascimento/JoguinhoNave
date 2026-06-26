using UnityEngine;

public class PowerUpDisparoAlternado : PowerUpColetavel
{
    public override EfeitoPowerUp EfeitoPowerUp {
        get { 
            return new EfeitoPowerUpDisparoAlternado(); 
        }
    }
}