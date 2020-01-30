using Sauce.Character;
using Sauce.Enums;
using UnityEngine;

namespace Sauce.Manager
{
    public class PlayerManager : ManagerBase
    {
        [SerializeField]
        private GameObject player;

        //TODO: Use IoC
        public override void Start()
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag(TAG.Player.ToString());

            try
            {
                var playerObj = GetPlayerType(player);
                playerObj.SetPlayerMovement(new Movement(new PlayerInput()));
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        private Player GetPlayerType(GameObject player) => player.GetComponent<Player>();
    }
}