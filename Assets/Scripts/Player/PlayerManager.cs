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

        #region Override Methods

        public override void Start()
        {
            if (PlayerObj == null)
                PlayerObj = GameObject.FindGameObjectWithTag(TAG.Player.ToString());

            try
            {
                var player = GetPlayerType();
                player.SetPlayerMovement(new Movement(new PlayerInput()));
                SetPlayerPostion();

                //Should be fading out or sth

                //Loads player info thus freeing movement
                LoadPlayerInfo(GetPlayerType());
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        public override void Update()
        {
            /*if (Input.GetKeyDown(KeyCode.L))
                SavePlayerInfo(GetPlayerType());
            if (Input.GetKeyDown(KeyCode.K))
                LoadPlayerInfo(GetPlayerType());*/
        }

        public override void OnApplicationStop() => SavePlayerInfo(GetPlayerType());

        #endregion Override Methods

        public Player GetPlayerType() => PlayerObj.GetComponent<Player>();

        public void SetPlayerPostion()
        {
            var spawPoint = GameObject.FindGameObjectWithTag(TAG.PlayerSpawn.ToString());
            PlayerObj.transform.position = spawPoint.transform.position;
        }

        private void SavePlayerInfo(Player player)
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

        private void LoadPlayerInfo(Player player = null)
        {
            try
            {
                Debug.Log($@"Loading player info from: {SavePath}");

                using (FileStream file = File.Open(SavePath, FileMode.OpenOrCreate))
                {
                    object loadedData = new BinaryFormatter().Deserialize(file);
                    var playerData = (PlayerInfo)loadedData;

                    if (player != null)
                        player.SetData(playerData.Currency, playerData.Stats);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(new Exception("Loading has Failed: ", ex));
            }
        }
    }
}