using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Data
{
    public const string FileName = "Data.save";

    public static void SaveData<T>(T data)
    {
        var binaryFormatter = new BinaryFormatter();
        var dataFile = File.Create(Application.persistentDataPath + "/" + FileName);

        binaryFormatter.Serialize(dataFile, data);
        dataFile.Close();
    }

    public static void ResetData<T>(T data)
    {
        File.Delete(Application.persistentDataPath + "/" + FileName);
        SaveData(data);
    }

    public static T LoadData<T>()
    {
        try
        {
            var binaryFormatter = new BinaryFormatter();
            var file = File.Open(
                Application.persistentDataPath + "/" + FileName,
                FileMode.Open);

            var data = (T)binaryFormatter.Deserialize(file);
            file.Close();

            return data;
        }
        catch
        {
            return (T)System.Activator.CreateInstance(typeof(T));
        }
    }
}
