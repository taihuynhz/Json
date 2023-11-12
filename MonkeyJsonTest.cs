using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MonkeyJsonTest : MonoBehaviour
{
    protected void Start()
    {
        //PlayerData playerData = new PlayerData();
        //playerData.name = "Kyo";
        //playerData.health = 100;
        //playerData.level = 2;
        //playerData.position = new Vector3(0, 5, 0);

        //string json = JsonUtility.ToJson(playerData);
        //Debug.Log(json);

        //File.WriteAllText(Application.persistentDataPath + "/saveFile.json", json);

        string json = File.ReadAllText(Application.persistentDataPath + "/saveFile.json");
        PlayerData loadedPlayerData = JsonUtility.FromJson<PlayerData>(json);

        Debug.Log(loadedPlayerData.name);
        Debug.Log(loadedPlayerData.health);
        Debug.Log(loadedPlayerData.level);
        Debug.Log(loadedPlayerData.position);
    }

    private class PlayerData
    {
        public string name;
        public int health;
        public int level;
        public Vector3 position;
    }
}
