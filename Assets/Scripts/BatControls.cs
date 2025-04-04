using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class BatControls : MonoBehaviour
{

    [SerializeField]
    private float _forceScaler;

    [SerializeField]
    private GameObject _ball;

    [SerializeField]
    private float _batPower = 30;
    public float BatPower { get { return _batPower; } }


    private float _batPowerMultiplier = 1;
    private float _maxRotationSpeed = 80;
    private float _maxRotation = 80;
    private float _maxBatPowerDistance = 3;
    private float _maxBatPowerSpeed = 4;
    private bool _rotationSet = false;
    private bool _powerSet = false;
    private Rigidbody _rigidbody;
    private float _direction = 1;
    private float _amountMoved;
    private bool _mouseClicked;
    private bool _isSwung = false;

    private Vector3 _startPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();


    }


    private void Update()
    {
        _mouseClicked = false;
        if(!_rotationSet)
            BatRotation();

        if(_rotationSet && !_powerSet && !_mouseClicked)
        {
            BatMultiplier();
            if (Input.GetMouseButtonDown(0))
                _powerSet = true;
        }

        if (_powerSet && _rotationSet && !_isSwung)
        {
            Invoke("SwingBat", 2);
            _isSwung = true;
        }
    }

    private void FixedUpdate()
    {

        if (_rotationSet && !_powerSet)
            BatPowerMovement();

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            transform.DOKill();
            other.attachedRigidbody.isKinematic = false;

            Vector3 attackAngle = (other.transform.localPosition - transform.position).normalized;
            other.attachedRigidbody.AddForce(( attackAngle * _batPower) * _batPowerMultiplier, ForceMode.Impulse);

        }


    }


    private void BatRotation()
    {
        
        _amountMoved += _maxRotationSpeed * Time.deltaTime;
        if(_amountMoved >= _maxRotation)
        {
            if (_direction == 1)
                _direction = -1;
            else
                _direction = 1;

            _amountMoved = 0;
        }
            
        transform.RotateAround(_ball.transform.position, new Vector3(0, 0, 1), _maxRotationSpeed * _direction * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            _rotationSet = true;
            _amountMoved = 0;
            _direction = -1;
            _mouseClicked = true;
            _startPosition = transform.localPosition;
        }
    }

    private void BatPowerMovement()
    {
        _amountMoved += _maxBatPowerSpeed * Time.fixedDeltaTime;

        if(_amountMoved >= _maxBatPowerDistance)
        {
            if (_direction == -1)
                _direction = 1;
            else
                _direction = -1;
            _amountMoved = 0;
        }

        _rigidbody.MovePosition(transform.position + ((_ball.transform.position - transform.position).normalized * _maxBatPowerSpeed * _direction * Time.fixedDeltaTime));
 
    }

    private void SwingBat()
    {
        transform.DOMove(_ball.transform.position, 0.5f).SetEase(Ease.InOutCirc);
    }

    private void BatMultiplier()
    {
        Vector3 difference = -1 * (transform.localPosition - _startPosition);

        if(difference.x == 0)
        {
            _batPowerMultiplier = 1;
        }
        else
        {
            _batPowerMultiplier = difference.x;
        }

    }
}
