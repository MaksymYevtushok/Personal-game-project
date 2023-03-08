using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float forwardMovementSpeed;
    private Vector3 screenPoint;
    private Vector3 offset;
    private float minX, maxX;
    public  SpawnManager spawnManager;

    void Start()
    {
        // Set the minimum and maximum X positions for the object
        minX = -2f;
        maxX = 2f;
    }
    
    void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, screenPoint.z));
        }
    }

    void OnMouseDrag()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 cursorScreenPoint = new Vector3(touch.position.x, touch.position.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
            float clampedX = Mathf.Clamp(cursorPosition.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
        }
    }

     void FixedUpdate() 
    {
        SetForwardMovement();
    }

      private void SetForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovementSpeed * Time.fixedDeltaTime);
    }

     private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "SpawnTrigger")
        {
           spawnManager.SpawnTriggerEntered();
        }
    }


}
