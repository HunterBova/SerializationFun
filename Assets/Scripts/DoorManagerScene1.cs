﻿public class DoorManagerScene1 : DoorManager
{ 
    public override void EnterDoor()
    {
        SceneSerializer.find.Save();
        //This section of code would need to written with the Level design and doors to load at for each scene to 
        //change the PlayerPrefs for that specific scene to set the player spawn point
        foreach (SetUseDoors door in SceneDoors)
        {
            if (door.here)
            {
                switch (door.DoorNumber)
                {
                    
                    case 0: SceneSerializer.find.ModifyTargetScene(1,0); UnityEngine.SceneManagement.SceneManager.LoadScene(1); break;
                    case 1: SceneSerializer.find.ModifyTargetScene(0, 0); UnityEngine.SceneManagement.SceneManager.LoadScene(0); break;
                    default: break;
                }
            }
        }
    }
}
