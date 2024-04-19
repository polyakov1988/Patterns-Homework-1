using UnityEngine;

namespace Shooter
{
    public class ShootingView : View
    {
        [SerializeField] private WeaponHandler _weaponHandler;
    
        private void OnEnable()
        {
            _weaponHandler.ShootingChanged += UpdateText;
        }

        private void OnDisable()
        {
            _weaponHandler.ShootingChanged -= UpdateText;
        }
    }
}
