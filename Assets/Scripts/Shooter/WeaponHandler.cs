using System;
using UnityEngine;

namespace Shooter
{
    public class WeaponHandler : MonoBehaviour
    {
        [SerializeField] private Weapon _weapon;

        public event Action<String> ShootingChanged;

        private void Start()
        {
            SetLimitedSingleShooting();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                SetLimitedSingleShooting();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                SetUnlimitedSingleShooting();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                SetLimitedTripleShooting();
            }
        }

        private void SetLimitedSingleShooting()
        {
            _weapon.SetShooting(new LimitedSingleShooting());
            ShootingChanged?.Invoke("Одиночные выстрелы (-1 пуля)");
        }
    
        private void SetUnlimitedSingleShooting()
        {
            _weapon.SetShooting(new UnlimitedSingleShooting());
            ShootingChanged?.Invoke("Одиночные выстрелы (пули не тратятся)");
        }
    
        private void SetLimitedTripleShooting()
        {
            _weapon.SetShooting(new LimitedTripleShooting());
            ShootingChanged?.Invoke("Тройные выстрелы (-3 пули)");
        }
    }
}
