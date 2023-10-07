using System;
using UnityEngine;
using UnityEngine.Events;

namespace RunTime.Signals
{
    public class UISignals : MonoBehaviour
    {
        public static UISignals Instance;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        public UnityAction<byte> onSetStageColor = delegate { };
        public UnityAction<byte> onSetLevelValue = delegate { };
        public UnityAction onPlay = delegate { };
    }
}