using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    public static DoorManager find;

    public SetUseDoors[] SceneDoors;

    private void Awake()
    {
        find = this;
        for (int i = 0; i < SceneDoors.Length; i++)
        {
            SceneDoors[i].DoorNumber = i;
        }
    }

    public virtual void EnterDoor()
    {

    }

    public Vector3 GetPlayerPosition(int door)
    {
        return SceneDoors[door].transform.position;
    }
}
