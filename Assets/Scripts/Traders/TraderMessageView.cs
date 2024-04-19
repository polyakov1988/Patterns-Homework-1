using System.Collections;
using TMPro;
using UnityEngine;

namespace Traders
{
    public class TraderMessageView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Trader _trader;

        private WaitForSeconds _messageTimeout = new(3);

        private void OnEnable()
        {
            _trader.TradeAction += UpdateMessage;
        }

        private void OnDisable()
        {
            _trader.TradeAction -= UpdateMessage;
        }

        private void UpdateMessage(string message)
        {
            StartCoroutine(ShowMessage(message));
        }

        private IEnumerator ShowMessage(string message)
        {
            _text.text = message;

            yield return _messageTimeout;
        
            _text.text = "";
        }
    }
}
