using System;
using UnityEngine;

namespace Shooter
{
    public class Weapon : MonoBehaviour, IShootable
    {
        [SerializeField] private int _bullets;
        [SerializeField] private Bullet _bulletPrefab;

        private const int BulletPerShoot = 1;
        private Shooting _shooting;
    
        public event Action<bool, Color> ShootAction;
        public event Action<String> UpdateBullets;
    
    

        private bool HasBullets => _bullets > 0;
    
        private void Awake()
        {
            ShootAction = Shoot;
        }

        private void Start()
        {
            UpdateBullets?.Invoke(_bullets.ToString());
        }

        private void Update()
        {
            _shooting.Update();
        }
    
        public void SetShooting(Shooting shooting)
        {
            _shooting?.Unsubscribe(ShootAction);
            _shooting?.StopShoot();
            _shooting = shooting;
            _shooting.Subscribe(ShootAction);
            _shooting.StartShoot();
        }
    
        public void Shoot(bool spendBullets, Color bulletColor)
        {
            if (spendBullets && HasBullets == false)
            {
                return;
            }
        
            if (spendBullets)
            {
                _bullets-= BulletPerShoot;
                UpdateBullets?.Invoke(_bullets.ToString());
            }
        
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.SetColor(bulletColor);
            bullet.AddForce();
        }
    }
}