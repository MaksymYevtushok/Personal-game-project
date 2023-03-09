using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisableObjectOnUI : MonoBehaviour
{
    public GameObject objectToDisable;
    public GameObject uiElement;


    void Update()
    {
        if (uiElement.activeSelf)
        {
            objectToDisable.SetActive(false);
        }
        else
        {
            objectToDisable.SetActive(true);
        }
    }

    
}
