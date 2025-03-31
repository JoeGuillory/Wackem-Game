using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGround : MonoBehaviour
{

    [SerializeField]
    private GameObject _groundobject;

    private bool _created;


    private void Start()
    {
        _created = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!_created)
        {
            if (_groundobject)
            {
                Instantiate(_groundobject, transform.position + new Vector3(120, 0, 0), transform.rotation);
                _created = true;
            }
            else
                Debug.LogError("CreateGround: No Gameobject was selected!");
        }
    }
   

}
