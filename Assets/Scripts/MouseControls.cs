using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControls : MonoBehaviour
{
    Vector3 _worldPosition;
   
    void Update()
    {
        _worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.nearClipPlane));
        _worldPosition.z = 0;

        transform.localPosition = _worldPosition;
    }
}
