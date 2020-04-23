using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArrowClick : SceneController, IPointerDownHandler, IPointerUpHandler
{

    #region 點擊後，切換場景事件
    // 按鈕切換小場景，需要先用這個來註冊事件。
    protected void SetArrowBtnListener()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnArrowClick);
    }

    private void OnArrowClick()
    {
        ArrowClickEffect();
        ChangeSceneSideInSingleSceneWithLoop();
        Invoke("ArrowClickEffect", 0.06f);
    }
    #endregion

    #region 點擊後，視覺效果
    bool flag = false;
    private void ArrowClickEffect()
    {
        if (!flag)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(-25f, 0f, 0f);
            flag = true;
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            flag = false;
            CancelInvoke("ArrowClickEffect");
        }
    }
    #endregion

    #region 善惡值改變，視覺效果改變(ArrowWithKarma)
    private bool pointerDown;
    private float pointerDownTimer;

    [SerializeField]
    private float requiredHoldTime = 1;

    [SerializeField]
    private Image fillImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                Reset();
            }
            fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
            
        }
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
    }
    #endregion
}
