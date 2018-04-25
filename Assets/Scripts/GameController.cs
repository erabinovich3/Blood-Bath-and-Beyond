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


	void Awake () {
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
        
        bf = new BinaryFormatter();
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
        gameData data = new gameData(highScores, unlockedMoms, unlockedLevels, gamesPlayed);
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