using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
   private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public Touch touch;
    public  SpawnManager spawnManager;
    private float movefinger;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        movefinger = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * movefinger,
                    transform.position.y,
                    transform.position.z);
            }

        }


    }

    private void FixedUpdate()
    {
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        spawnManager.SpawnTriggerEntered();
    }
}
