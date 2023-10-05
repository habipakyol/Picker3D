using UnityEngine;
using UnityEngine.Events;


namespace RunTime.Signals
{
    public class InputSignals : MonoBehaviour
    {
        public static InputSignals Instance;

        private void Awake()
        {
            if (Instance!=null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = null;
        }
        
        public UnityAction onEnableInput = delegate { };
        public UnityAction onDisableInput = delegate { };
        public UnityAction onFirstTimeTouchTaken = delegate { };
        public UnityAction onInputTaken = delegate { };
        public UnityAction onInputReleased = delegate { };
        public UnityAction<HorizontalInputParams> onInputDragged = delegate { };
    }
    
}