using System.Collections.Generic;
using UnityEngine;

namespace Sauce.Manager
{
    public class MasterManager : MonoBehaviour
    {
        private readonly List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake()
        {
            if (managers != null)
                managers.ForEach(m => m.Awake());
        }

        private void Start()
        {
            managers.Add(new PlayerManager());
            //managers.Add(new EnemyManager());

            if (managers != null)
                managers.ForEach(m => m.Start());
        }

        private void Update()
        {
            if (managers != null)
                managers.ForEach(m => m.Update());
        }

        private void FixedUpdate()
        {
            if (managers != null)
                managers.ForEach(m => m.FixedUpdate());
        }
    }
}