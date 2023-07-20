using System.IO;
using UnityEngine;

public class SaveGameManager : MonoBehaviour
{
    PlayerInventory playerInventory;
    Player player;
    Transform playerTransform;
    KeyManager keyManager;
    //DoorManager
    //KeypadManager
    //FuseboxManager


    public void SaveGame()
    {
        // Gather relevant data for saving
        SaveData saveData = GatherSaveData();

        // Serialize the SaveData instance into JSON
        string serializedData = JsonUtility.ToJson(saveData);

        // Save the serialized data to a file
        string savePath = GetSavePath(); // Define the save path based on your project's needs
        File.WriteAllText(savePath, serializedData);

        Debug.Log("Game saved successfully!");
    }

    private SaveData GatherSaveData()
    {
        // Implement the logic to gather and populate the relevant data
        // Return an instance of SaveData populated with the collected data

        SaveData saveData = new SaveData();

        // Gather player data
        saveData.hasFlashlight = playerInventory.hasFlashlight;
        saveData.hasFuse = playerInventory.hasFuse;
        saveData.hasPistol = playerInventory.hasPistol;
        saveData.hasRope = playerInventory.hasRope;
        saveData.hasShotgun = playerInventory.hasShotgun;
        saveData.shotgunShells = playerInventory.shotgunShells;

        // Gather player position and rotation
        saveData.playerPosition = playerTransform.position;
        saveData.playerRotation = playerTransform.rotation;

        // Gather key data
        

        return saveData;
    }

    private string GetSavePath()
    {
        // Implement the logic to define the save path
        // Return the path as a string

        return "test";
    }
}

