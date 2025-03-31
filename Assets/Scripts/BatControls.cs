using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class BatControls : MonoBehaviour
{

    [SerializeField]
    private float _forceScaler;

    private Rigidbody _rigidbody;
    private HingeJoint _mouseJoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _mouseJoint = GetComponent<HingeJoint>();

    }


    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if (_rigidbody)
                _rigidbody.AddForce(transform.forward * _forceScaler);

            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
