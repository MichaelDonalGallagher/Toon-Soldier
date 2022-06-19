using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{

    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        Animator animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move Player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical * speed;

        CharacterController characterController = GetComponent<CharacterController>();

        characterController.SimpleMove(movement);


        //Animation change
        float movementMag = Vector3.Magnitude(movement);

        GetComponentInChildren<Animator>().SetFloat("Speed", vertical);

        //Rotate Player
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        transform.Rotate(Vector3.up,1,Space.Self);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(Vector3.down, 1, Space.Self);
    }
}
