using System;
using UnityEngine;

namespace Traders
{
    public abstract class Trading
    {
        private readonly String _message;

        protected Trading(string message)
        {
            _message = message;
        }

        public String Message => _message;

        public void Trade()
        {
            Debug.Log(_message);
        }
    }
}
