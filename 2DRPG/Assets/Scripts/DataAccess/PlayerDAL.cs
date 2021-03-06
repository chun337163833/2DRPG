using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;


public class PlayerDAL
{
    public PlayerDTO LoadPlayerData()
    {
        PlayerDTO playerObject = new PlayerDTO();
        string filepath = Application.dataPath + @"/Data/Player.xml";
        XmlDocument xmlDoc = new XmlDocument();
        try
        {
            if (File.Exists(filepath))
            {
                Debug.Log("1.File exist!");

                xmlDoc.Load(filepath);
                Debug.Log("2.File Loaded!");

                XmlNodeList playerStats = xmlDoc.GetElementsByTagName("Stats");
                Debug.Log("3.Stats Found");

                foreach (XmlNode playerInfo in playerStats)
                {
                    XmlNodeList playerContent = playerInfo.ChildNodes;
                    
                    foreach (XmlNode playerItems in playerContent)
                    {
                        if (playerItems.Name == "HP")
                        {
                            playerObject.HP = int.Parse(playerItems.InnerText); 
                        }
                        if (playerItems.Name == "Level")
                        {
                            playerObject.Level = playerItems.InnerText; 
                        }
                    }
                }
                
            }
            Debug.Log("4.Loops Ended!");

           
        } 
        catch (System.Exception ex)
        {
            
            Debug.Log(ex.Message);
            //TODO: Add LOGGING
        }

        return playerObject;
       
    }


     

}

