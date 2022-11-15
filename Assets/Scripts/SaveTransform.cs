using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTransform : MonoBehaviour
{
    public Vector3 GetTransform() { return transform.position; }
    public void SetPosition(Vector3 input) { transform.position = input; }
}
