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

    public static void SaveLevelData(int level, int nut)
    {
        level--;   /// always remeber zero indexed

        int[] savedNuts = GetNuts();


        if( nut > savedNuts[level] )
        {
            savedNuts[level] = nut;

            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/nuts.ftw";
            FileStream stream = new FileStream(path, FileMode.Create);

            // PlayerData data = new PlayerData(player);
            //formatter.Serialize(stream, data);

            formatter.Serialize(stream, savedNuts);
            stream.Close();

        }


    }

    public static int[] GetNuts()
    {
        int[] nuts = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        string path = Application.persistentDataPath + "/nuts.ftw";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            nuts = formatter.Deserialize(stream) as int[];
            stream.Close();

            return nuts;

        }
        else
        {
        //    Debug.LogError("Save file not found in " + path);
            return nuts;
        }


    }

    public static int GetNutByLevel(int level)
    {
        level--; // zero indexed;
        int[] savedNuts = new int[10];

        savedNuts = GetNuts();
        return savedNuts[level];

    }

    public static LevelData LoadLevels()
    {
        Debug.Log("LoadLevels");

        int totalLevels = 10;
        int[] nuts = new int[totalLevels];


        for (int i = 0; i < totalLevels ; i++)
        {
            nuts[i] = 0;
        }


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
