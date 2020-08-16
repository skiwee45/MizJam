using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Time.timeScale = 0;
    }

    void OnTriggerExit(Collider other) {
        //Add to the current score
    }
}
