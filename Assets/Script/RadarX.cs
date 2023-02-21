using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarX : MonoBehaviour
{
    private GameObject target;
    private float dis;

    void Start()
    {
        target = GameObject.Find("Tank");
    }

    void Update()
    {
        if(target)
        {
            dis = Vector3.Distance(transform.position, target.transform.position);

            if(dis < 9)
            {
                transform.LookAt(target.transform);
            }
        }
    }
}
