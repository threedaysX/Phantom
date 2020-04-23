using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour
{
    #region Model Parameters
    public string ItemName;
    private string _ItemTag;
    public string ItemTag 
    {
        get 
        {
            return _ItemTag;
        }
        set
        {
            _ItemTag = value;
            gameObject.tag = _ItemTag;
        }
    }
    public Sprite sprite;
    #endregion   
    
    #region Interface Of Click
    protected IClick _IClick { get; set; }

    public ItemModel(IClick click = null)
    {
        _IClick = click ?? new DoNothing();
    }
    #endregion

    #region ClickEvent

    /// 左鍵按下後。
    public void OnClick()
    {
        _IClick.OnClick();
    }

    /// 左鍵按下後，傳入一個參數來運作。
    /// 存檔
    public void OnClickWithParameter<T>(T item_obj)
    {
        _IClick.OnClick(item_obj);
    }

    /// 當玩家點擊右鍵觸發，切換到放大檢視模式。
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ViewItemManager.Instance.OpenViewItemMode(this.gameObject);
        }
    }
    #endregion

    #region Common Method

    //讀取tag、name
    public string GetTag()
    {
        return this.ItemTag;
    }
    public string GetName()
    {
        return this.ItemName;
    }
    public Sprite GetSprite()
    {
        return this.sprite;
    }
    
    //給一個itemName，由這個名字顯示對應名字的圖片
    public void LoadResourceImage(string itemName)
    {
        Sprite sp = Resources.Load<Sprite>("Item/" + itemName);
        if (sp != null)
        {
            var tempScale = gameObject.transform.localScale;
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sp;
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            
            gameObject.transform.localScale = tempScale;

            sprite = spriteRenderer.sprite;
        }

        //從場景名稱的資料夾下中尋找，並以此為優先顯示
        Scene scene = SceneManager.GetActiveScene();
        string[] frontName = (scene.name).Split('_');
        sp = Resources.Load<Sprite>("Item/" + frontName[0] + "/"+ itemName);
        if (sp != null)
        {
            // var tempScale = gameObject.transform.localScale;
            SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sp;
            // spriteRenderer.drawMode = SpriteDrawMode.Sliced;

            // gameObject.transform.localScale = tempScale;

            sprite = spriteRenderer.sprite;
        }

    }

    public void Copy(ItemModel temp)
    {
        ItemName = temp.ItemName;
        ItemTag = temp.ItemTag;
        sprite = temp.sprite;
    }

    private void InitItemName()
    {
        ItemName = gameObject.name;       
    }

    private void Init_ItemTag()
    {
        _ItemTag = gameObject.tag;       
    }
    #endregion

    void Awake()
    {
        InitItemName();
        Init_ItemTag();
        LoadResourceImage(GetName());
    }


}
