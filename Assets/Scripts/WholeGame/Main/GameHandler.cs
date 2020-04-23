using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Vector3 centerPos;
    float distanceFromCamera = 10f;

    static GameHandler instance;
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
    }

    // Start is called before the first frame update
    void Start()
    {       
        if (cameraFollow == null)
        {
            cameraFollow = CameraFollow.Instance;
        }
        centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distanceFromCamera));
        GetAndSetCenterPos();
    }

    private void Update()
    {
        if (cameraFollow == null)
        {
            cameraFollow = CameraFollow.Instance;
        }
    }

    private void GetAndSetCenterPos()
    {
        cameraFollow.Setup(() => centerPos);
    }
}
