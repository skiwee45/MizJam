using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsThatFaceUp : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    float thrust = 4f;

    void Start()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
    }
}
