using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public static SimpleMove find;
    private void Awake()
    {
        find = this;
    }

    private bool useDoors;

    private bool grounded;
    private float landingBuffer;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetKey(KeyCode.A)) transform.position += new Vector3(-.1f,0f,0f);
            if (Input.GetKey(KeyCode.D)) transform.position += new Vector3(.1f, 0f, 0f);

            if (Input.GetKey(KeyCode.Space)) { if (grounded && landingBuffer < 0) { GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse); grounded = false; } }

            if (Input.GetKey(KeyCode.W)) if (useDoors)
                {
                    DoorManager.find.EnterDoor();
                    //if (DoorManagerScene1.find) { DoorManagerScene1.find.EnterDoor(); Debug.Log("1"); }
                    //if (DoorManagerScene2.find) { DoorManagerScene2.find.EnterDoor(); Debug.Log("2"); }
                    //if (DoorManagerScene3.find) { DoorManagerScene3.find.EnterDoor(); Debug.Log("3"); }
                }
        }
        if (landingBuffer >= 0) landingBuffer -= Time.deltaTime;
    }

    public void SetGrounded(bool set) { grounded = set; landingBuffer = .2f; }

    public void SetDoor (bool set) { useDoors = set; }
}
