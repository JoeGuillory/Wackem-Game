using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _followObject;

    [SerializeField]
    private Vector3 _offset;

    private Vector3 _startingPosition;



    private void Start()
    {
        _startingPosition = transform.position;
    }



    private void Update()
    {
        if(_followObject)
        {
            transform.position = _followObject.position + _offset;
        }
    }

}
