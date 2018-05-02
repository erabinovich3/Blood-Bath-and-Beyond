using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {
    public static GameController controller;

    public int[] highScores;
    public bool[] unlockedMoms; 
    public bool[] unlockedLevels;
    public int gamesPlayed;


    private int numLevels;
    private int numMoms;
    private gameData dat;
    private BinaryFormatter bf;


    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }


    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Awake () {
        bf = new BinaryFormatter();

        if (controller == null)
        {
            DontDestroyOnLoad(this);
            controller = this;
        } else if(controller != this)
        {
            Destroy(this);
        }


	}

    void Start()
    {
        LockCursor();

        numLevels = 1;
        numMoms = 5;
        
        if (load() != 0)
        {
            unlockedMoms = new bool[numMoms];
            unlockedLevels = new bool[numLevels];
            highScores = new int[numLevels];
            gamesPlayed = 0;

            unlockedLevels[0] = true;
            unlockedMoms[0] = true;
        }
        unlockedMoms = new bool[numMoms];
        unlockedMoms[0] = true;
        unlockedMoms[1] = true;
    }


    private void OnDestroy()
    {
        save();
    }


    //saves persistent data
    //return Key
    //0 = success
    public int save()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/progression.dat", FileMode.OpenOrCreate);
        Debug.Log(Application.persistentDataPath);
        gameData data = new gameData(highScores, unlockedMoms, unlockedLevels, gamesPlayed);
        Debug.Log(data);
        Debug.Log(file);
        Debug.Log(bf);
        bf.Serialize(file, data);
        file.Close();
        return 0;
    }

    //loads persistent data
    //return Key
    //0 = success
    //1 = file Not Found
    public int load()
    {
        if (File.Exists(Application.persistentDataPath + "/progression.dat"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/progression.dat", FileMode.Open);
            gameData data = (gameData)bf.Deserialize(file);
            file.Close();

            unlockedLevels = data.unlockedLevels;
            unlockedMoms = data.unlockedMoms;
            highScores = data.highScores;
            gamesPlayed = data.gamesPlayed;

            return 0;
        } else
        {
            return 1;
        }
        
    }
}

[System.Serializable]
class gameData {
    public gameData(int[] highScores, bool[] unlockedMoms, bool[] unlockedLevels, int gamesPlayed)
    {
        this.highScores = highScores;
        this.unlockedLevels = unlockedLevels;
        this.unlockedMoms = unlockedMoms;
        this.gamesPlayed = gamesPlayed;

    }

    public int[] highScores;
    public bool[] unlockedMoms;
    public bool[] unlockedLevels; 
    public int gamesPlayed;



}