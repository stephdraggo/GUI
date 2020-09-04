using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


namespace Gui
{
    [AddComponentMenu("GUI/Save Player Data")]
    public class SaveControl : MonoBehaviour
    {
        public static void SavePlayer(PlayerControl player)
        {
            BinaryFormatter formatter = new BinaryFormatter(); //make formatter

            string path = Application.dataPath + "kittens.jpg"; //give file secret name

            FileStream stream = new FileStream(path, FileMode.Create); //make file

            PlayerData data = new PlayerData(player); //get data to save

            formatter.Serialize(stream, data); //put data in file

            stream.Close(); //close it up
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.dataPath + "kittens.jpg"; //secret location code

            if (File.Exists(path)) //if exists
            {
                BinaryFormatter formatter = new BinaryFormatter(); //make formatter

                FileStream stream = new FileStream(path, FileMode.Open); //open file

                PlayerData data = formatter.Deserialize(stream) as PlayerData; //take data from file

                stream.Close(); //close file

                return data; //give data
            }
            else
            {
                Debug.Log("No save file found.");
                return null;
            }
        }
    }
}