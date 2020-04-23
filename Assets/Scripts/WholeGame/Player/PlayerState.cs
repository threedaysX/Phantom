using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : Singleton<PlayerState>
{
    private static mask_state maskState = mask_state.none;

    // 玩家是否正拿著道具
    private static bool takeOn = false;
    // 玩家正拿著什麼道具
    private static string onHandItemName = string.Empty;

    public void TakeOn(string itemName)
    {
        takeOn = true;
        onHandItemName = itemName;
    }

    public void TakeOff()
    {
        takeOn = false;
        onHandItemName = string.Empty;
    }

    // 取得玩家狀態(手上是否拿著道具)
    public bool GetPlayerTakeOnHandState()
    {       
        return takeOn;
    }

    public string GetPlayerTakeOnHandItemName()
    {
        return onHandItemName;
    }

    public mask_state GetPlayermaskState()
    {
        return maskState;
    }
    public void SetPlayermaskState(mask_state setState)
    {
        maskState = setState;
    }
}
public enum mask_state
{
    none = 0,
    onlyLeft = 1,
    onlyRight = 2
}