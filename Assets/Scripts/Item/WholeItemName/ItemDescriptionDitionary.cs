using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptionDitionary
{
    // 建立字典
    public static Dictionary<string, string> ItemDescription = new Dictionary<string, string>()
    {
        /*---------------------------------------- BathRoom ----------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        #region BathRoom

        #region BathRoom_CollectableItem
        {ItemNameDictionary.Vase, "這是一個"+ItemNameDictionary.Vase},
        {ItemNameDictionary.Vase_Water, "這是一個"+ItemNameDictionary.Vase_Water},
        {ItemNameDictionary.ToothMug, ItemNameDictionary.ToothMug + "，好像可以裝水"},
        {ItemNameDictionary.ToothMug_Water, ItemNameDictionary.ToothMug_Water + "，好像可以澆花"},
        {ItemNameDictionary.Key, ItemNameDictionary.Key + "，好像可以用來開鎖"},
        {ItemNameDictionary.Comb, ItemNameDictionary.Comb + "，可以用來梳頭髮"},
        {ItemNameDictionary.Perfume, ItemNameDictionary.Perfume + "，是Christine喜歡的香味"},
        {ItemNameDictionary.LeftHalfMask, "這是一個"+ItemNameDictionary.LeftHalfMask},
        #endregion

        #region BathRoom_InteractiveItem
        {ItemNameDictionary.Sink, "這是一個"+ItemNameDictionary.Sink},
        {ItemNameDictionary.Mirror, "這是一個"+ItemNameDictionary.Mirror},
        {ItemNameDictionary.Jewelry, "這是一個"+ItemNameDictionary.Jewelry},
        {ItemNameDictionary.DeskLock, "這是一個"+ItemNameDictionary.DeskLock},
        {ItemNameDictionary.Poster, "這是一個"+ItemNameDictionary.Poster},
        {ItemNameDictionary.Christine, "這是一個"+ItemNameDictionary.Christine},
        {ItemNameDictionary.BreakHole_Memory_1, "這是一個"+ItemNameDictionary.BreakHole_Memory_1},
        {ItemNameDictionary.BreakHole_Memory_2, "這是一個"+ItemNameDictionary.BreakHole_Memory_2},
        {ItemNameDictionary.Desk, "這是一個"+ItemNameDictionary.Desk},
        #endregion

        #endregion

        /*-------------------------------------- DressingRoom --------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        #region DressingRoom

        #region DressingRoom_CollectableItem
        {ItemNameDictionary.WhiteBlock, ItemNameDictionary.WhiteBlock + "，可以放在門上"},
        {ItemNameDictionary.GoldBlock, ItemNameDictionary.GoldBlock + "，可以放在門上"},
        {ItemNameDictionary.Mask, "這是一個"+ItemNameDictionary.Mask},
        #endregion

        #region DressingRoom_InteractiveItem
        {ItemNameDictionary.PhantomCostume, "這是一個"+ItemNameDictionary.PhantomCostume},
        {ItemNameDictionary.WorkerClothes, "這是一個"+ItemNameDictionary.WorkerClothes},
        {ItemNameDictionary.LeadingLady, "這是一個"+ItemNameDictionary.LeadingLady},
        {ItemNameDictionary.OtherCloth, "這是一個"+ItemNameDictionary.OtherCloth},
        {ItemNameDictionary.Hammer, ItemNameDictionary.Hammer + "，似乎可以拿來破壞櫃子"},
        {ItemNameDictionary.DressingTable, "這是一個"+ItemNameDictionary.DressingTable},
        {ItemNameDictionary.BreakHole_Memory_3, "這是一個"+ItemNameDictionary.BreakHole_Memory_3},
        {ItemNameDictionary.BreakHole_Memory_4, "這是一個"+ItemNameDictionary.BreakHole_Memory_4},
        #endregion

        #endregion

        /*---------------------------------------- Theater -----------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        #region Theater
    
        #region Theater_CollectableItem
        {ItemNameDictionary.BlackSquare, ItemNameDictionary.BlackSquare + "，可以放在門上"},
        {ItemNameDictionary.FountainPen, ItemNameDictionary.FountainPen + "，可以用來書寫"},
        {ItemNameDictionary.FeatherPen, ItemNameDictionary.FeatherPen + "，可以用來書寫"},
        {ItemNameDictionary.PianoScore, ItemNameDictionary.PianoScore + "，裡面好像有五線譜"},
        {ItemNameDictionary.RightHalfMask, "這是一個"+ItemNameDictionary.RightHalfMask},
        {ItemNameDictionary.BrokenCostume, "這是一個"+ItemNameDictionary.BrokenCostume},
        {ItemNameDictionary.RMask_wear, "這是一個"+ItemNameDictionary.RMask_wear},
        #endregion

        #region Theater_InteractiveItem
        {ItemNameDictionary.Auditorium, "這是一個"+ItemNameDictionary.Auditorium},
        {ItemNameDictionary.AuditoriumFull, "這是一個"+ItemNameDictionary.AuditoriumFull},
        {ItemNameDictionary.leftStageCurtain, "這是一個"+ItemNameDictionary.leftStageCurtain},
        {ItemNameDictionary.rightStageCurtain, "這是一個"+ItemNameDictionary.rightStageCurtain},
        {ItemNameDictionary.UnfinishedScript, "這是一個"+ItemNameDictionary.UnfinishedScript},
        {ItemNameDictionary.StageBackground, "這是一個"+ItemNameDictionary.StageBackground},
        {ItemNameDictionary.ScriptScreen, "這是一個"+ItemNameDictionary.ScriptScreen},
        {ItemNameDictionary.BreakHole_Memory_5, "這是一個"+ItemNameDictionary.BreakHole_Memory_5},
        #endregion

        #endregion

        /*---------------------------------------- Basement -----------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        #region Basement

        #region Basement_CollectableItem
        {ItemNameDictionary.MusicBox, ItemNameDictionary.MusicBox + "，好像壞掉了"},
        #endregion

        #region Basement_InteractiveItem
        {ItemNameDictionary.Piano, "這是一個"+ItemNameDictionary.Piano},
        #endregion

        #endregion

        /*---------------------------------------- Door ---------------------------------------------*/
        /*------------------------------------------------------------------------------------------*/
        #region Door
        {ItemNameDictionary.BathRoomDoorButton, "這是一個"+ItemNameDictionary.BathRoomDoorButton},
        {ItemNameDictionary.DressingDoorButton, "這是一個"+ItemNameDictionary.DressingDoorButton},
        {ItemNameDictionary.TheaterDoorButton, "這是一個"+ItemNameDictionary.TheaterDoorButton},
        {ItemNameDictionary.BasementDoorButton, "這是一個"+ItemNameDictionary.BasementDoorButton}
        #endregion

    };

    // 查字典
    public static string FindInDictionary(string FindMe)
    {
        if (true == (ItemDescription.ContainsKey(FindMe)))
        {
            return ItemDescription[FindMe];
        }
        else
        {
            return "Not Found";
        }
    }
}
