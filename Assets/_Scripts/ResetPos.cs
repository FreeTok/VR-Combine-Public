using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour
{
    private Vector3 startPos;
    private Quaternion startRot;

    private void Start()
    {
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public void ResetPosition()
    {
        transform.position = startPos;
        transform.rotation = startRot;
    }
}
