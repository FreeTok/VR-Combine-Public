using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void StartFirstTruck()
    {
        SceneManager.LoadScene(1);
    }

    public void StartSecondTruck()
    {
        SceneManager.LoadScene(2);
    }
}
