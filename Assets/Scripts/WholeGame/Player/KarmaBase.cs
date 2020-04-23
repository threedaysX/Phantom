using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarmaBase : MonoBehaviour
{  
    // 善惡值，等級越高(1~4)，代表能承受的壓力越大(5~20)。
    private static Dictionary<float, float> karma =  new Dictionary<float, float>()
        {
            { 1, 10},
            { 2, 20},
            { 3, 35},
            { 4, 50}
        };

    // 最大Karma上限值(會根據當前Karma階級變化)
    private static float maxKarmaValue = 10;

    private static float _currentKarmaLevel = 1;
    // 當前的Karma階級
    public static float currentKarmaLevel
    {
        get { return _currentKarmaLevel; }
        set
        {
            _currentKarmaLevel = value;
            if (currentKarmaLevel < 0)
            {
                currentKarmaLevel = 0;
            }
            else if (currentKarmaLevel > 4)
            {
                currentKarmaLevel = 4;
            }
            foreach (var item in karma.Where(x => x.Key.Equals(currentKarmaLevel)))
            {
                maxKarmaValue = item.Value;
            }
        }
    }

    private static bool flag1 = false;
    private static bool flag2 = false;
    private static bool flag3 = false;
    private static bool flag4 = false;
    private static float _currentKarmaValue = 0;
    // 當前的Karma值
    public static float currentKarmaValue
    {
        get { return _currentKarmaValue; }
        set
        {
            if(_currentKarmaValue < maxKarmaValue)
            {
                _currentKarmaValue = value;
            }
            if (_currentKarmaValue > 0)
            {
                karmaEffect = maxKarmaValue - _currentKarmaValue;
            }
            #region 關卡道具控制
            if (_currentKarmaValue > 45)
            {
                if (!flag4)
                {
                    KarmaItemControl.Instance.Karma_Item_Appear_4();
                    flag4 = true;
                }
            }
            else if (_currentKarmaValue > 32)
            {
                if (!flag3)
                {
                    KarmaItemControl.Instance.Karma_Item_Appear_3();
                    flag3 = true;
                }
            }
            else if (_currentKarmaValue > 20)
            {
                if (!flag2)
                {
                    KarmaItemControl.Instance.Karma_Item_Appear_2();
                    flag2 = true;
                }
            }
            else if (_currentKarmaValue > 8)
            {
                if (!flag1)
                {
                    KarmaItemControl.Instance.Karma_Item_Appear_1();
                    flag1 = true;
                }
            }
            #endregion
            Debug.Log(_currentKarmaValue);
        }
    }

    private static float _karmaEffect;
    // Karma階段變化，達到幾個階段後，會使場景發生變化(會根據當前Karma值變化)
    private static float karmaEffect
    {
        get { return _karmaEffect; }
        set
        {
            _karmaEffect = value;
            #region 場景第一階變化 (當前的Karma值與最大值差值，小於壓力的20%)
            if (_karmaEffect <= maxKarmaValue * 0.2)
            {
                FrostEffect.Instance.FrostAmount = 0.2f;
                FrostEffect.Instance.seethroughness = 0.6f;
            }
            #endregion
            #region 場景第二階變化 (當前的Karma值與最大值差值，小於壓力的50%)
            else if (_karmaEffect <= maxKarmaValue * 0.5)
            {
                FrostEffect.Instance.FrostAmount = 0.15f;
                FrostEffect.Instance.seethroughness = 0.7f;
            }
            #endregion
            #region 場景第三階變化 (當前的Karma值與最大值差值，小於壓力的80%)
            else if (_karmaEffect <= maxKarmaValue * 0.8)
            {
                FrostEffect.Instance.FrostAmount = 0.1f;
                FrostEffect.Instance.seethroughness = 1f;
            }
            #endregion
        }
    }
}
