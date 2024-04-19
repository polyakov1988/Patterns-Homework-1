using UnityEngine;

namespace Shooter
{
    public class WeaponView : View
    {
        [SerializeField] private Weapon _weapon;

        private void OnEnable()
        {
            _weapon.UpdateBullets += UpdateText;
        }

        private void OnDisable()
        {
            _weapon.UpdateBullets -= UpdateText;
        }
    }
}