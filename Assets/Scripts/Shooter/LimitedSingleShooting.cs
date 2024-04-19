using UnityEngine;

namespace Shooter
{
    public class LimitedSingleShooting : Shooting
    {
        protected override void MakeShoot()
        {
            InvokeWeaponShoot(true, Color.blue);
        }

    
    }
}
