using Sauce.Character;
using Sauce.Enums;
using UnityEngine;

namespace Sauce
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        //TODO: Use IoC
        private void Start()
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag(TAG.Player.ToString());

            try
            {
                var playerObj = GetPlayerType(player);
                playerObj.SetPlayer(new Movement(new PlayerInput()));
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex);
            }
        }

        private Player GetPlayerType(GameObject player) => player.GetComponent<Player>();
    }
}