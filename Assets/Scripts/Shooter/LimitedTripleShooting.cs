using UnityEngine;

namespace Shooter
{
    public class LimitedTripleShooting : Shooting
    {
        private readonly int _shootCount = 3;
    
        protected override void MakeShoot()
        {
            for (int i = 0; i < _shootCount; i++)
            {
                InvokeWeaponShoot(true, Color.green);
            }
        }
    }
}
