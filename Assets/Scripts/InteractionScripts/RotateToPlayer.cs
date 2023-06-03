using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform MainCamera;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(new Vector3(MainCamera.position.x, transform.position.y, MainCamera.position.z));
    }

}