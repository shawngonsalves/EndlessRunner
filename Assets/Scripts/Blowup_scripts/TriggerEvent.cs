using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent crateToTrigger;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            crateToTrigger.Invoke();

        }
    }
}