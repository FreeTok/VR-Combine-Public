using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace _Scripts
{
    [Serializable]
    public struct TaskComponents
    {
        [HideInInspector]
        public GameObject ticket;
        public Outline[] highlights;
        public GameObject[] triggers;
        public XRGrabInteractable[] grabs;

        public void SelectDeselect(bool isSelecting = true, bool isCleaning = false)
        {
            if (ticket && !isSelecting && !isCleaning)
            {
                ticket.SetActive(true);
            }
            
            if (highlights.Length > 0)
            {
                foreach (var highlight in highlights)
                {
                    highlight.enabled = isSelecting;
                }
            }
            
            if (triggers.Length > 0)
            {
                foreach (var trigger in triggers)
                {
                    trigger.SetActive(isSelecting);
                }
            }

            if (grabs.Length > 0 && !isCleaning)
            {
                foreach (var grab in grabs)
                {
                    if (!isSelecting)
                    {
                        grab.selectEntered = new SelectEnterEvent();
                    }
                }
            }
        }
    }

    public class TaskManager : MonoBehaviour
    {
        public TaskComponents[] comps;
        private int lastTicket = -1;

        public float timeToWaitBeforeStartNewTask = 5;

        public GameObject canvasCompleted;
        public GameObject[] tickets;


        private void Start()
        {
            Initiate();
            StartNewTaskWait();
            StartNewTaskWait();
            StartNewTaskWait();
        }

        private void Initiate()
        {
            for (int i = 0; i < comps.Length; i++)
            {
                comps[i].ticket = tickets[i];
                comps[i].SelectDeselect(false, true);
            }
            //foreach (var comp in comps)
            //{
            //    comp.SelectDeselect(false, true);
            //}
            
            lastTicket++;
            comps[lastTicket].SelectDeselect();
        }

        private void StartNewTask()
        {
            if (lastTicket >= comps.Length) return;

            var canvas = Instantiate(canvasCompleted);
            canvas.SetActive(true);
            Destroy(canvas, 5f);

            if (lastTicket >= 0)
            {
                comps[lastTicket].SelectDeselect(false);
            }

            lastTicket++;
            if (lastTicket < comps.Length)
            {
                comps[lastTicket].SelectDeselect();
            }
        }

        public void StartNewTaskWait()
        {
            Invoke(nameof(StartNewTask), timeToWaitBeforeStartNewTask);
        }
    }
}