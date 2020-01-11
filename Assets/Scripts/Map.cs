using Sauce.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sauce
{
    public class Map : MonoBehaviour
    {
        public int maxRooms;
        public int minRooms;

        public List<IRoom> Rooms { get; private set; }

        private void Start()
        {
            //SpawnRooms();
        }

        private void SpawnRooms()
        {
            var actualRoomNumber = (int)UnityEngine.Random.Range(minRooms, (float)maxRooms);
            Rooms.Add(GetInitialRoom());

            SpawNextRooms(Rooms.FirstOrDefault());

            Rooms.ForEach(async r => await r.StartRoomAsync());
        }

        //TODO: this should be recursive and "remember" rooms that still have openings, not surpass max value
        // check if open rooms can have another placed or change the one in the place
        private IRoom SpawNextRooms(IRoom room = null)
        {
            //TODO: Should know when and how much to rotate(unless templates have predefined rotations)
            throw new NotImplementedException();
        }

        private IRoom GetInitialRoom() => GetComponentInChildren<IRoom>();
    }
}