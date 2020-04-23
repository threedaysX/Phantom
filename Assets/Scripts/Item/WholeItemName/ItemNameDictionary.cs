using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//對應到 場景中物件的名字
public class ItemNameDictionary
{
    /*---------------------------------------- BathRoom ----------------------------------------*/
    /*------------------------------------------------------------------------------------------*/
    #region BathRoom

    #region BathRoom_CollectableItem
    public const string Vase = "花瓶";
    public const string Vase_Water = "加水花瓶";
    public const string ToothMug = "漱口杯";
    public const string ToothMug_Water = "水杯";
    public const string Key = "鑰匙";
    public const string Comb = "梳子";
    public const string Perfume = "香水";
    public const string LeftHalfMask = "左半面具";

    #endregion

    #region BathRoom_InteractiveItem
    public const string Sink = "洗手台";
    public const string Mirror = "鏡子";
    public const string Jewelry = "首飾";
    public const string DeskLock = "櫃子lock(透明)";
    public const string Poster = "公演海報";
    public const string Christine = "人物";
    public const string BreakHole_Memory_1 = "BreakHole_Memory_1";
    public const string BreakHole_Memory_2 = "BreakHole_Memory_2";
    public const string Desk = "櫃子";

    #endregion

    #endregion



    /*-------------------------------------- DressingRoom --------------------------------------*/
    /*------------------------------------------------------------------------------------------*/
    #region DressingRoom

    #region DressingRoom_CollectableItem
    public const string WhiteBlock = "白方塊";
    public const string GoldBlock = "黃方塊";
    public const string Mask = "白眼影";
    #endregion

    #region DressingRoom_InteractiveItem
    public const string PhantomCostume = "魅影戲服(下部用)";
    public const string WorkerClothes = "工人服";
    public const string LeadingLady = "女主戲服";
    public const string OtherCloth = "其他衣服";
    public const string Hammer = "槌子";
    public const string DressingTable = "梳妝台";
    public const string BreakHole_Memory_3 = "BreakHole_Memory_3";
    public const string BreakHole_Memory_4 = "BreakHole_Memory_4";
    #endregion

    #endregion



    /*---------------------------------------- Theater -----------------------------------------*/
    /*------------------------------------------------------------------------------------------*/
    #region Theater

    #region Theater_CollectableItem
    public const string BlackSquare = "黑方塊";
    public const string FountainPen = "鋼筆";
    public const string FeatherPen = "羽毛筆";
    public const string PianoScore = "琴譜";
    public const string RightHalfMask = "右半面具";
    public const string BrokenCostume = "破碎的戲服";
    public const string RMask_wear = "右半面具(穿)";
    #endregion

    #region Theater_InteractiveItem
    public const string Auditorium = "觀眾席";
    public const string AuditoriumFull = "觀眾席(滿)";
    public const string leftStageCurtain = "布幕(左)";
    public const string rightStageCurtain = "布幕(右)";
    public const string UnfinishedScript = "未完成的劇本";
    public const string StageBackground = "舞台背景";
    public const string ScriptScreen = "劇本畫面";
    public const string BreakHole_Memory_5 = "BreakHole_Memory_5";
    #endregion

    #endregion



    /*---------------------------------------- Basement -----------------------------------------*/
    /*------------------------------------------------------------------------------------------*/
    #region Basement
    #region Basement_CollectableItem
    public const string MusicBox = "音樂盒";
    #endregion

    #region Basement_InteractiveItem
    public const string Piano = "鋼琴";
    #endregion

    #endregion



    /*---------------------------------------- Door ---------------------------------------------*/
    /*------------------------------------------------------------------------------------------*/
    #region Door
    public const string BathRoomDoorButton= "BathRoomDoorButton";
    public const string DressingDoorButton = "DressingDoorButton";
    public const string TheaterDoorButton = "TheaterDoorButton";
    public const string BasementDoorButton = "BasementDoorButton";
    #endregion
}
