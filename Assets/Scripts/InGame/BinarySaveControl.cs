using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

namespace GUI1
{
    [AddComponentMenu("GUI/Save Player Data")]
    public class BinarySaveControl : MonoBehaviour
    {
        public static void SavePlayer(PlayerControl player)
        {
            BinaryFormatter formatter = new BinaryFormatter(); //make formatter

            string path = Application.dataPath + "kittens.jpg"; //give file secret name

            FileStream stream = new FileStream(path, FileMode.Create); //make file

            PlayerData data = new PlayerData(player); //get data to save

            formatter.Serialize(stream, data); //put data in file and encrypt

            stream.Close(); //close it up
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.dataPath + "kittens.jpg"; //secret location code

            if (File.Exists(path)) //if exists
            {
                BinaryFormatter formatter = new BinaryFormatter(); //make formatter

                FileStream stream = new FileStream(path, FileMode.Open); //open file

                PlayerData data = (PlayerData)formatter.Deserialize(stream); //take data from file and convert to usable

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