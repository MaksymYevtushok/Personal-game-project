using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputController inputController;

    [SerializeField] private float forwardMovementSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;
    private float newPositionX;
    public Touch touch;
    public  SpawnManager spawnManager;

    void FixedUpdate() 
    {
        SetForwardMovement();
        SetHorizontalMovement();
    }

    private void SetForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }

    private void SetHorizontalMovement()
    {
        newPositionX = transform.position.x + inputController.HorizontalValue * horizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -horizontalLimitValue, horizontalLimitValue);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "SpawnTrigger")
        {
           spawnManager.SpawnTriggerEntered();
        }
    }
}
