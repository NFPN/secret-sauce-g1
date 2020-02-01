using Sauce.Character;
using Sauce.Enums;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Sauce.Manager
{
    public class PlayerManager : ManagerBase
    {
        private static readonly string SavePath = $@"{Application.persistentDataPath}\save.dat";

        public GameObject PlayerObj { get; private set; }

        public override void Start()
        {
            if (PlayerObj == null)
                PlayerObj = GameObject.FindGameObjectWithTag(TAG.Player.ToString());

            try
            {
                var playerObj = GetPlayerType(PlayerObj);
                playerObj.SetPlayerMovement(new Movement(new PlayerInput()));
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
                SavePlayer(GetPlayerType(PlayerObj));
            if (Input.GetKeyDown(KeyCode.K))
                LoadPlayer(GetPlayerType(PlayerObj));
        }

        private Player GetPlayerType(GameObject player) => player.GetComponent<Player>();

        public override void OnApplicationStop()
        {
            SavePlayer(GetPlayerType(PlayerObj));
        }

        private void SavePlayer(Player player)
        {
            var info = new PlayerInfo()
            {
                Stats = player.Stats,
                LastLevel = CurrentLevel,
                Currency = player.Currency,
            };

            Debug.Log($@"Saving player at: {SavePath}");

            using (FileStream file = File.Create(SavePath))
                new BinaryFormatter().Serialize(file, info);
        }

        private PlayerInfo LoadPlayer(Player player = null)
        {
            try
            {
                Debug.Log($@"Loading player info from: {SavePath}");

                var playerData = PlayerInfo.None;
                using (FileStream file = File.Open(SavePath, FileMode.OpenOrCreate))
                {
                    object loadedData = new BinaryFormatter().Deserialize(file);
                    playerData = (PlayerInfo)loadedData;

                    if (player != null)
                        player.SetData(playerData.Currency, playerData.Stats);
                }

                return playerData;
            }
            catch (Exception ex)
            {
                Debug.LogError(new Exception("Loading has Failed: ", ex));
                return PlayerInfo.None;
            }
        }
    }
}