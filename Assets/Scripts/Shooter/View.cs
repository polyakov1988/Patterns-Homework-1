using System;
using TMPro;
using UnityEngine;

namespace Shooter
{
    public abstract class View : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        protected void UpdateText(String text)
        {
            _text.text = text;
        }
    }
}
