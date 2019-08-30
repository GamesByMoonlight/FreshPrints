using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{ 

    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.ftw";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
       
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.ftw";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void SaveLevelData( Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.ftw";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(player);
        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static LevelData LoadLevels()
    {
        Debug.Log("LoadLevels");

        string path = Application.persistentDataPath + "/level.ftw";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }

    }

    public static void SaveLevelData(LevelData levelData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/level.ftw";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveLevelOptions(LevelOptions levelOptions)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/levelOptions.ftw";
        FileStream stream = new FileStream(path, FileMode.Create);
        LevelData data = new LevelData(levelOptions);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadLevelOptions()
    {
        Debug.Log("LoadLevelOptions");

        string path = Application.persistentDataPath + "/levelOptions.ftw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("save file not found in " + path);
            return null;
        }

    }
}
