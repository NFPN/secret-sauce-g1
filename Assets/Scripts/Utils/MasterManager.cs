using System.Collections.Generic;
using UnityEngine;

namespace Sauce.Manager
{
    public class MasterManager : MonoBehaviour
    {
        private readonly List<ManagerBase> managers = new List<ManagerBase>();

        private void Awake() => managers?.ForEach(m => m.Awake());

        private void Start()
        {
            managers.Add(new PlayerManager());
            //managers.Add(new EnemyManager());

            managers?.ForEach(m => m.Start());
        }

        private void Update() => managers?.ForEach(m => m.Update());

        private void FixedUpdate() => managers?.ForEach(m => m.FixedUpdate());

        private void OnApplicationQuit() => managers?.ForEach(m => m.OnApplicationStop());

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                managers?.ForEach(m => m.OnApplicationStop());
        }
    }
}