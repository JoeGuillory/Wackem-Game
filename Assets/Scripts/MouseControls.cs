using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseControls : MonoBehaviour
{

    [SerializeField]
    private Camera _camera;

    Vector3 _worldPosition;
   
   
    void Update()
    {
        if (_camera)
        {
            _worldPosition = _camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(_camera.transform.position.z)));
            transform.position = _worldPosition;
        }
        else
            Debug.LogWarning("MouseControls: No camera assigned!");
    }
}
