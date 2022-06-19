using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        Animator animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        //Move Player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        CharacterController characterController = GetComponent<CharacterController>();

        characterController.SimpleMove(movement);


        //Animation change
        float movementMag = Vector3.Magnitude(movement);

        GetComponentInChildren<Animator>().SetFloat("Speed", movementMag);

        //Rotate Player
        if (movementMag >= .01)
        {
            //transform.rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.1f);
        }
    }
}
