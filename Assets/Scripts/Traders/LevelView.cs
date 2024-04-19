using TMPro;
using UnityEngine;

namespace Traders
{
    public class LevelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Player _player;

        private void OnEnable()
        {
            _player.LevelUp += UpdateLevel;
        }

        private void OnDisable()
        {
            _player.LevelUp -= UpdateLevel;
        }

        private void UpdateLevel(int level)
        {
            _text.text = level.ToString();
        }
    }
}