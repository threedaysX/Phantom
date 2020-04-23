using UnityEngine;

[CreateAssetMenu(fileName = "New CollectableItem", menuName = "CollectableItem")]
public class CollectableItemState : ItemStateData
{
    public AvailableState isAvailable = AvailableState.Available;
    //其存在是否出現或消失

    public UseableState isUsed = UseableState.UnUse;
    //是否被使用過其功能


    // 道具出現在畫面上，則設為 [可使用] 狀態；反之亦同。
    public bool SwitchAvailable()
    {
        if (isAvailable == AvailableState.UnAvailable)
        {
            isAvailable = AvailableState.Available;
            return true;
        }
        else
        {
            isAvailable = AvailableState.UnAvailable;
            return false;
        }
    }
    
    public override bool Interact()
    {
        if (isUsed == UseableState.UnUse)
        {
            isUsed = UseableState.Used;
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void Reset()
    {
        isUsed = UseableState.UnUse;
    }
}

[System.Serializable]
public enum AvailableState
{
    Available = 0,
    UnAvailable = 1
}

[System.Serializable]
public enum UseableState
{
    UnUse = 0,
    Used = 1
}
