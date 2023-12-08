using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color newColor;

    void Start()
    {
        // Get the object's material
        Material material = GetComponent<Renderer>().material;

        // Set the material's color to the newColor
        material.color = newColor;
    }
}
