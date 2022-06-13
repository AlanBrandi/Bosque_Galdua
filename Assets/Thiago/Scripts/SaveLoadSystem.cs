using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
    public string SavePath => $"{Application.persistentDataPath}/save.txt";

    private void Update()
    {
        Save();
        load();
    }

    [ContextMenu("Save")]
    void Save()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Saved");
            var state = loadFile();
            saveState(state);
            saveFile(state);
        }
    }

    [ContextMenu("Load")]
    void load()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Loaded");
            var state = loadFile();
            loadState(state);
        }
    }

    public void saveFile(object state)
    {
        using (var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    Dictionary<string, object> loadFile()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("Save file empty");
            return new Dictionary<string, object>();
        }
        using (FileStream stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }

    void saveState(Dictionary<string, object> state)
    {
        foreach(var saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.Id] = saveable.saveState();
        }
    }
    void loadState(Dictionary<string, object> state)
    {
        foreach (var saveable in FindObjectsOfType<SaveableEntity>())
        {
            if(state.TryGetValue(saveable.Id, out object savedState))
            {
                saveable.loadState(savedState);
            }
        }
    }
}
