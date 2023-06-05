using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform MainCamera;
    private bool isReverse = true;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update() {
        if (Camera.main)
        {
            var cameraTransform = Camera.main.gameObject.transform;
            transform.LookAt(cameraTransform);
            if (isReverse) transform.forward *= -1;
        }
    }

}