using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] protected TMP_Text text;
    protected IDataService dataService = new JsonDataService();
    protected bool EncryptionEnable;
    protected long SaveTime;
    protected long Loadtime;

    public void ToogleEncryption(bool EncryptionEnable)
    {
        this.EncryptionEnable = EncryptionEnable;
    }

    public void SerializeJson()
    {
        long StartTime = DateTime.Now.Ticks;
        if (dataService.SaveData("/data.json", text.text, EncryptionEnable))
        {
            SaveTime = DateTime.Now.Ticks - StartTime;
            Debug.Log($"Save time: {(SaveTime / 1000f):N4}ms");
            StartTime = DateTime.Now.Ticks;
            try
            {
                string data = dataService.LoadData<string>("/data.json", EncryptionEnable);
                Loadtime = DateTime.Now.Ticks - StartTime;
                Debug.Log($"Load time: {(Loadtime / 1000f):N4}ms");
                Debug.Log($"Loaded data: {data}");
            }
            catch (Exception e)
            {
                Debug.Log("Could not read file!");
            }
        }
        else
        {
            Debug.Log("Could not save file!");
        }
    }
}
