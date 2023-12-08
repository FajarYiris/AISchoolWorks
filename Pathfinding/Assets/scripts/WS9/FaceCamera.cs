using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
  void LateUpdate()
  {
    Vector3 cameraPosition = Camera.main.transform.position;
    transform.LookAt(cameraPosition);
  }
}
