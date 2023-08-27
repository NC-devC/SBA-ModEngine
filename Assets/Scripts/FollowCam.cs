using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject target;
    public Camera cam;
    Vector3 offset;

    private void Start() {
        offset = cam.transform.position - target.transform.position;
    }

    private void Update() {
        cam.transform.position = target.transform.position + offset;
    }
}
