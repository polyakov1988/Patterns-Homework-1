using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Traders
{
    public class TradingHandler : MonoBehaviour
    {
        [SerializeField] private Trader _trader;
        [SerializeField] private Player _player;
    
        private const int NoTradingPatternMinLevel = 1;
        private const int TradingFruitPatternMinLevel = 5;
        private const int TradingArmorPatternMinLevel = 10;
        
        private Dictionary<int, Trading> _tradingByPlayerLevel;
    
        private int _nextTradingLevel;
    
        private void OnEnable()
        {
            _player.LevelUp += CheckTradingPattern;
            Debug.Log("subs");
        }
        
        private void OnDisable()
        {
            _player.LevelUp += CheckTradingPattern;
        }
    
        private void Awake()
        {
            _tradingByPlayerLevel = new Dictionary<int, Trading>()
            {
                {NoTradingPatternMinLevel, new NoTradingPattern()}, 
                {TradingFruitPatternMinLevel, new TradingFruitPattern()},
                {TradingArmorPatternMinLevel, new TradingArmorPattern()}
            };
    
            _nextTradingLevel = NoTradingPatternMinLevel;
        }
    
        private void CheckTradingPattern(int level)
        {
            if (level >= _nextTradingLevel)
            {
                _trader.SetTrading(_tradingByPlayerLevel[_nextTradingLevel]);
    
                _nextTradingLevel = FindNextTradingLevel();
            }
        }
    
        private int FindNextTradingLevel()
        {
            List<int> tradingLevels = _tradingByPlayerLevel.Keys.ToList();
            
            tradingLevels.Sort();
    
            if (_nextTradingLevel == tradingLevels[^1])
            {
                return _nextTradingLevel;
            }
    
            int currentIndex = tradingLevels.IndexOf(_nextTradingLevel);
    
            return tradingLevels[currentIndex + 1];
        }
    }
}

