using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Windows.WebCam;

public class CameraController : MonoBehaviour
{


    private Transform cam;

    
    void Start()
    {
        cam = Camera.main.transform;
    }

    void Update()
    {
        float x = cam.position.x + Input.GetAxis("Horizontal");
        Vector3 pos = new Vector3(x, cam.position.y, cam.position.z);
        cam.transform.position = Vector3.Lerp(cam.position, pos, Time.deltaTime * 8.8f);
    }
}
