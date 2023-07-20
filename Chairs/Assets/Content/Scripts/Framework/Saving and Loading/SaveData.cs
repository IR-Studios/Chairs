using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    //Player Data
    public Vector3 playerPosition;
    public Quaternion playerRotation;
    public int playerHealth;
    public bool hasFlashlight;
    public bool hasPistol;
    public bool hasShotgun;
    public bool hasFuse;
    public bool hasRope; 
    public int shotgunShells;

    //Key Data
    public List<KeyData> keyDataList;

    //Door Data
    public List<DoorData> doorDataList;

    // Fuse box data
    public List<FuseBoxData> fuseBoxDataList;

    // Keypad data
    public List<KeypadData> keypadDataList;

    public SaveData() 
    {
        keyDataList = new List<KeyData>();
        doorDataList = new List<DoorData>();
        fuseBoxDataList = new List<FuseBoxData>();
        keypadDataList = new List<KeypadData>();
    }
}

[System.Serializable]
public class KeyData
{
    public bool keyAcquired;
    public int keyNum;

    public KeyData(bool acquired, int number) 
    {
        keyAcquired = acquired;
        keyNum = number;
    }
}

[System.Serializable]
public class DoorData 
{
    public bool requiresKey;
    public int keyNum;
    public bool doorLocked;

    public DoorData(bool requiresKey, int keyNum, bool doorLocked) 
    {
        this.requiresKey = requiresKey;
        this.keyNum = keyNum;
        this.doorLocked = doorLocked;
    }
}

[System.Serializable]
public class FuseBoxData
{
    public bool fuseInserted;
    // Add any other relevant data for the fuse box here

    public FuseBoxData(bool inserted)
    {
        fuseInserted = inserted;
    }
}

[System.Serializable]
public class KeypadData
{
    public int code;
    public bool isPowered;
    public bool codeCorrect;
    // Add any other relevant data for the keypad here

    public KeypadData(int code, bool isPowered, bool codeCorrect)
    {
        this.code = code;
        this.isPowered = isPowered;
        this.codeCorrect = codeCorrect;
    }
}
