using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Stornaway
{
    public static class SaveSystem
    {
        private static string m_path = Application.persistentDataPath + "/" + Application.productName + ".sav";

        public static string m_currentVariant;
        public static string[] m_variantHistory;


        public static void Save(string _currentVariant, string[] _variantHistory)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(m_path, FileMode.Create);

            SaveData saveData = new SaveData(_currentVariant, _variantHistory);

            formatter.Serialize(stream, saveData);
            stream.Close();
        }

        public static void ClearSave()
        {
            m_currentVariant = null;
            m_variantHistory = null;
        }

        public static SaveData Load()
        {
            if(File.Exists(m_path)) 
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(m_path, FileMode.Open);

                SaveData saveData = formatter.Deserialize(stream) as SaveData;
                stream.Close();

                m_currentVariant = saveData.currentVariant;
                m_variantHistory = saveData.variantHistory;

                return saveData;
            }
            else
            {
                Debug.Log("Save data not found");
                return null; 
            }
        }
    }
}