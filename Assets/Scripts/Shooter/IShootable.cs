using UnityEngine;

namespace Shooter
{
    public interface IShootable
    { 
        void Shoot(bool spendBullets, Color bulletColor);
    }
}
