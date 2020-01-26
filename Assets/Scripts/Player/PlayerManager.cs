using Sauce.Character;
using UnityEngine;

namespace Sauce
{
    public class PlayerManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject player;

        private void Start()
        {
            var playerObj = GetPlayerType(player);
            playerObj.SetPlayer(new PlayerMovement());
        }

        private Player GetPlayerType(GameObject player) => player.GetComponent<Player>();
    }
}