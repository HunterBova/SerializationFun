using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGrounded : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SimpleMove temp = other.gameObject.GetComponent<SimpleMove>();
        if (temp) temp.SetGrounded(true); 
    }

    private void OnTriggerExit(Collider other)
    {
        SimpleMove temp = other.gameObject.GetComponent<SimpleMove>();
        if (temp) temp.SetGrounded(false);
    }
}
