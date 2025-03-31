using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartScript : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnStart;

   
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            OnStart.Invoke();
        }
    }
}
