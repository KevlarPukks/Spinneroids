using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBehaviour : MonoBehaviour {

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(transform.up * Random.Range(-50.0f, 150.0f));
        rb.angularVelocity = Random.Range(-1000f, 1000f);
    }
   


}
