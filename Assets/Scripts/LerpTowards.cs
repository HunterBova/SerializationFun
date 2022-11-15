using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTowards : MonoBehaviour
{
    public static LerpTowards find;

    private void Awake()
    {
        //made this a singleton incase enemies want to make the camera shake or change depth
        find = this;
    }

    public Transform PlayerPosition;

    public float Depth = -15;
    // Update is called once per frame
    void Update()
    {
        Vector3 target = new Vector3(PlayerPosition.position.x, PlayerPosition.position.y, PlayerPosition.position.z + Depth);
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * 1.5f);
    }
}
