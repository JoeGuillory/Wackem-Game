using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private Rigidbody _ballRigidbody;

    [SerializeField]
    private float _startPower = 10;


   

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>(); 
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ballRigidbody)
            _ballRigidbody.isKinematic = false;

        if(collision.gameObject.tag == "Bat")
            _ballRigidbody.AddForce((transform.right + (transform.up / 2)) * _startPower);

        
    }

    
}
