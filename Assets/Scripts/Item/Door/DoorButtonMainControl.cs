using UnityEngine;
using UnityEngine.UI;

public class DoorButtonMainControl : InteractiveObjectModel
{   
    public GameObject door;
    protected string doorBtnName;

    public static ButtonPressEffect previousButton =null ; //紀錄先前按下的按鈕
    public ButtonPressEffect currentButton=null ;

    private void Start()
    {
        //_IClick = new DoorButton();
        door = GameObject.Find("Door");
    }
    public override void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0)&&!PlayerState.Instance.GetPlayerTakeOnHandState())
        {
            ButtonLock();
        }
    }

    public void ButtonLock()
    {
        if (this.GetComponent<ButtonLock>().buttonIsUnlock == 1)
        {
            CanPressOnlyOne();
        }
    }

    public void CanPressOnlyOne() //按鈕只能按下一個的判斷
    {
        currentButton = this.GetComponent<ButtonPressEffect>(); //取得現在的按鈕GameObject

        if (previousButton != null && previousButton!=currentButton) //如果按鈕有被按過
        {
            previousButton.IsPress = false;
            // 將舊按鈕改為false
            previousButton.ChangeButtonStatus();
        }

        if(previousButton != currentButton)
        {
            currentButton.IsPress = true;
            //將新按鈕改為true
            currentButton.ChangeButtonStatus();
        }

        if(previousButton == currentButton)
        {
            currentButton.IsPress = !currentButton.IsPress;
            currentButton.ChangeButtonStatus();
        }

        previousButton =currentButton;
        //當前的按鈕存到先前的按鈕
        //OnClickWithParameter(doorBtnName);


        if (currentButton.IsPress == false)
        {
            DoorMainControl.btnName = string.Empty;
        }
        else
        {
            DoorMainControl.btnName = doorBtnName;
        }
    }
}
