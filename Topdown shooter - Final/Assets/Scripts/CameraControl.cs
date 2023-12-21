using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject Player; 
    public Vector3 offset; 

    void Start() { 
        offset = transform.position - Player.transform.position; 
    } 
    
    void LateUpdate() {
        if (Player != null)
        {
            transform.position = Player.transform.position + offset;
        }
    } 
}

