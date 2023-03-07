using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DattaTransmitter : MonoBehaviour
{
    [SerializeField] private InputController inputController;


    public float GetHorizontalValue()
    {
        return inputController.HorizontalValue;
    }
}
