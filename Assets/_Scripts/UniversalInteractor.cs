using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class UniversalInteractor : MonoBehaviour
{
    public bool passTasks;
    public GameObject mesh;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (mesh)
            {
                mesh.SetActive(false);
            }
        
            if (!passTasks) return;
            
            FindObjectOfType<TaskManager>().StartNewTaskWait();
            Destroy(this);
        }
    }
}
