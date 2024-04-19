using System;
using UnityEngine;

namespace Traders
{
    public class Trader : MonoBehaviour
    {
        private Trading _trading;
        public event Action<string> TradeAction; 

        public void SetTrading(Trading trading)
        {
            _trading = trading;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                _trading.Trade();
                TradeAction?.Invoke(_trading.Message);
            }
        }
    }
}