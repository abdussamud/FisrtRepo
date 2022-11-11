using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class rotate : MonoBehaviour
{
    public FixedTouchField TouchField;
    public float CameraAngleY;

    private void Start()
    {
        CameraAngleY = 0;
    }
    // Update is called once per frame
    void Update()
    {
        //CameraAngleY +=transform.rotation.y;
        transform.rotation = Quaternion.AngleAxis(CameraAngleY  + Vector3.SignedAngle(Vector3.forward,Vector3.forward * 0.001f, Vector3.up), Vector3.up);
        CameraAngleY += TouchField.TouchDist.x* 0.1f;
        //transform.Rotate(0, CameraAngleY, 0);
    }
}