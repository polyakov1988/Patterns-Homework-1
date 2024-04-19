using System;
using UnityEngine;

namespace Shooter
{
    public abstract class Shooting
    {
        private event Action<bool, Color> Shoot;
        private bool _isShooting;
    
        private bool IsShooting => _isShooting;
        public void StartShoot() => _isShooting = true;
        public void StopShoot() => _isShooting = false;

        public void Update()
        {
            if (IsShooting == false)
                return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                MakeShoot();
            }
        }
    
        public void Subscribe(Action<bool, Color> weaponAction)
        {
            Shoot += weaponAction;
        }
    
        public void Unsubscribe(Action<bool, Color> weaponAction)
        {
            Shoot -= weaponAction;
        }
    
        protected abstract void MakeShoot();

        protected void InvokeWeaponShoot(bool spendBullets, Color color)
        {
            Shoot?.Invoke(spendBullets, color);
        }
    }
}
