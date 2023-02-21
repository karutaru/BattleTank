using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColor : MonoBehaviour
{
    public void ChangeBackgroundColor(Color newColor)
    {
        Camera.main.backgroundColor = newColor;
    }
}
