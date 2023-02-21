using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera fpsCamera;

    private int num = -1;

    private void Start()
    {
        fpsCamera.depth = num;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            num *= -1;

            fpsCamera.depth = num;
        }
    }
}
