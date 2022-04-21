using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadGameManager
{
    public static void SavePlayerStats(CardHUD player) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerstats.kof";
        FileStream stream = new FileStream(path, FileMode.Create);
        HUDCotroller playerStats = new HUDCotroller(player);
        formatter.Serialize(stream, playerStats);
        stream.Close();
    }

    public static HUDCotroller LoadPlayerStats() {
        string path = Application.persistentDataPath + "/playerstats.kof";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            HUDCotroller player = formatter.Deserialize(stream) as HUDCotroller;
            stream.Close();
            return player;
        }
        else {
            Debug.Log("The slot does not exist in this o path:" + path);
            return null;
        }
    }
}
