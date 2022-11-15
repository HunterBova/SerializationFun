using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUseDoors : MonoBehaviour
{
    public bool here;

    public int DoorNumber;

    public Transform Player;

    public BoxCollider door;

    private void Start()
    {
        Player = SimpleMove.find.transform;
        door = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (door.bounds.Contains(Player.position)) here = true;
        else here = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        SimpleMove temp = other.gameObject.GetComponent<SimpleMove>();
        if (temp) temp.SetDoor(true);
    }

    private void OnTriggerExit(Collider other)
    {
        SimpleMove temp = other.gameObject.GetComponent<SimpleMove>();
        if (temp) temp.SetDoor(false);
    }
}
