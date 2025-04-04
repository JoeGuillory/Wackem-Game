using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    private bool _isHit = false;

    public bool IsHit { get{ return _isHit; } }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Bat")
            _isHit = true;
    }
}
