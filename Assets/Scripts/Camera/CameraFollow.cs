using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class CameraFollow : Singleton<CameraFollow>
{
    private Func<Vector3> GetCameraFollowPositionFunc;
    public Vector3 cameraFollowPosition;
    public Vector3 mousePos;
    public Vector3 mousePosOfCenter;
    private Vector3 centerPos;

    private Camera mainCamera;

    public Vector3 cameraVelocity = Vector3.zero; // 當前速度
    public float smoothTime = 0.001f; // 到達目標處的時間
    public float maxScreenPoint = 0.02f; // 縮放比例(滑鼠距離中心點的縮放)。越小代表畫面移動的範圍越小。
    float cameraMoveSpeed = 50f;

    static CameraFollow instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;            
        }
        else if (this != instance)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            Destroy(gameObject);
        }
        mainCamera = Camera.main;
    }

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc)
    {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    // Update is called once per frame
    void Update()
    {
        // 是否要隨時讓Camera移動? 待討論
        // if (!EventSystem.current.IsPointerOverGameObject())
        // {
            mousePos = Input.mousePosition * maxScreenPoint + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
            mousePosOfCenter = (GetCameraFollowPositionFunc() + Camera.main.ScreenToWorldPoint(mousePos)) / 2f;

            cameraFollowPosition = mousePosOfCenter;
            cameraFollowPosition.z = transform.position.z;

            Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
            float distance = Vector3.Distance(cameraFollowPosition, transform.position);

            if (distance > 0)
            {
                Vector3 newCameraPosition = transform.position + cameraMoveDir * cameraMoveSpeed * Time.deltaTime;

                float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

                if (distanceAfterMoving > distance)
                {
                    newCameraPosition = cameraFollowPosition;
                }

                transform.position = Vector3.SmoothDamp(transform.position, newCameraPosition, ref cameraVelocity, smoothTime);
            }
        // }
    }
}
