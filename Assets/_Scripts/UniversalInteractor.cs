using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class UniversalInteractor : MonoBehaviour
{
    public bool passTasks;
    [FormerlySerializedAs("mesh")] public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            if (anim)
            {
                foreach (var coll in anim.GetComponentsInChildren<Collider>())
                {
                    coll.enabled = false;
                }
                
                anim.SetTrigger("Triggered");
            }
        
            if (!passTasks) return;
            
            FindObjectOfType<TaskManager>().StartNewTaskWait();
            Destroy(this);
        }
    }
}
