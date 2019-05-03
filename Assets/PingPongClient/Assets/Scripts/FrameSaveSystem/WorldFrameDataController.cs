﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameSaveSystem
{
    public class WorldFrameDataController : IWorldFrameDataController
    {

       Dictionary<string,IPlayerDataController> playerDataControllers = new Dictionary<string,IPlayerDataController>();
       Dictionary<string,IBulletDataController> bulletDataControllers = new Dictionary<string,IBulletDataController>();

        public void Execute()
        {
            List<string> playerKeys = new List<string>();
            playerKeys = playerDataControllers.Keys.ToList();
            List<string> bulletKeys = new List<string>();
            bulletKeys = playerDataControllers.Keys.ToList();
            for (int i = 0; i < playerKeys.Count; i++)
            {
                playerDataControllers[playerKeys[i]].Execute();
            }
            for (int j = 0; j < bulletKeys.Count; j++)
            {
                bulletDataControllers[bulletKeys[j]].Execute();
            }
        }  

        public void SetupControllerData(JSONObject data)
        {
            string playerID = "";
            data.GetField(ref playerID,"playerID");

            if (playerDataControllers.ContainsKey(playerID))
            {
                playerDataControllers[playerID].SetupDataToExecute(data);
            }
            else
            {
                IPlayerDataController playerDataController = new PlayerDataController();
                playerDataControllers.Add(playerID, playerDataController);
                playerDataController.SetupDataToExecute(data);
            }
        }
    }
}