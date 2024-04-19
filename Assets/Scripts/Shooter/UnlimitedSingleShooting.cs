using UnityEngine;

namespace Shooter
{
    public class UnlimitedSingleShooting : Shooting
    {
        protected override void MakeShoot()
        {
            InvokeWeaponShoot(false, Color.red);
        }
    }
}
