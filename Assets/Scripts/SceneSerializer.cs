using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSerializer : MonoBehaviour
{
    public static SceneSerializer find;

    private int sceneIndex;

    private void Awake()
    {
        find = this;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Scene" + sceneIndex)) Load();
    }

    public void Save()
    {
        TransformData save = new TransformData(FindObjectsOfType<SaveTransform>());
        string mySavedCollection = JsonUtility.ToJson(save);
        PlayerPrefs.SetString("Scene" + sceneIndex, mySavedCollection);
    }

    public void ModifyTargetScene(int SceneIndexTarget,int DoorToLoadAt)
    {
        if (PlayerPrefs.HasKey("Scene" + SceneIndexTarget))
        {
            string myLoadedCollection = PlayerPrefs.GetString("Scene" + SceneIndexTarget);
            TransformData loadedSave = JsonUtility.FromJson<TransformData>(myLoadedCollection);
            loadedSave.DoorToLoadAt = DoorToLoadAt;
            myLoadedCollection = JsonUtility.ToJson(loadedSave);
            PlayerPrefs.SetString("Scene" + SceneIndexTarget,myLoadedCollection);
        }
        else
        {
            TransformData save = new TransformData(DoorToLoadAt);
            string mySavedCollection = JsonUtility.ToJson(save);
            PlayerPrefs.SetString("Scene" + SceneIndexTarget, mySavedCollection);
        }
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Scene" + sceneIndex))
        {
            SaveTransform[] objects = FindObjectsOfType<SaveTransform>();
            string myLoadedCollection = PlayerPrefs.GetString("Scene" + sceneIndex);
            TransformData loadedSave = JsonUtility.FromJson<TransformData>(myLoadedCollection);
            if (loadedSave.positions.Length > 0)
            {
                int counter = 0;
                foreach (SaveTransform obj in objects)
                {
                    obj.SetPosition(loadedSave.positions[counter]);
                    counter++;
                }
            }
            Vector3 temp = DoorManager.find.GetPlayerPosition(loadedSave.DoorToLoadAt);
            SimpleMove.find.transform.position = new Vector3(temp.x, temp.y, temp.z -.5f);
            LerpTowards.find.transform.position = temp;
        }
    }

    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}

[System.Serializable]
public class TransformData
{
    public int DoorToLoadAt;

    public Vector3[] positions;
    private SaveTransform[] objectsToSave;

    public TransformData(int Spawn)
    {
        objectsToSave = new SaveTransform[] { };
        positions = new Vector3[] { };
        DoorToLoadAt = Spawn;
    }

    public TransformData(SaveTransform[] sceneObjects)
    {
        objectsToSave = sceneObjects;
        GetTransforms();
    }

    private void GetTransforms()
    {
        objectsToSave = GameObject.FindObjectsOfType<SaveTransform>();
        positions = new Vector3[objectsToSave.Length];
        int counter = 0;
        foreach (SaveTransform obj in objectsToSave)
        {
            positions[counter] = obj.GetTransform();
            counter++;
        }
    }
}
