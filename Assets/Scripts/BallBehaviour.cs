using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private Rigidbody _ballRigidbody;

    private bool _onHit;


   

    private void Start()
    {
        _ballRigidbody = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_ballRigidbody)
            _ballRigidbody.isKinematic = false;

        

        _onHit = true;
    }

    
}
