using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollisionGameObject : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        if (collision.gameObject.name == "Player")
        {
            GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
            Debug.Log("Detected!");
        }
    }
}
