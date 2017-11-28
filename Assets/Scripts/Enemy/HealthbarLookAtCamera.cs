using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarLookAtCamera : MonoBehaviour {

    public GameObject MainCamera;
    public void Start()
    {
        MainCamera = GameObject.FindWithTag("MainCamera");
    }

    private void Update()
    {
        HealthBarLookAtCamera();
    }
    public void HealthBarLookAtCamera()
    {
        transform.LookAt(transform.position + MainCamera.transform.rotation * Vector3.back,
                         MainCamera.transform.rotation * Vector3.up);

    }
}
