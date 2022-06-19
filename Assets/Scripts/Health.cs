using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float amountOfRed = 0;
    
    public void takeDamage()
    {
        amountOfRed += 1f;
        if(amountOfRed >= 10f)
        {
            Destroy(this.gameObject);
        }
    }
}
