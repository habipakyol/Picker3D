using RunTime.Enums;
using RunTime.Signals;
using UnityEngine;

namespace RunTime.Managers
{
    public class UIManager : MonoBehaviour
    {
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += onLevelInitialize;
            CoreGameSignals.Instance.onlevelSuccessful += onlevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += onLevelFailed;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void onLevelFailed()
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Fail, 2);
        }

        private void onlevelSuccessful()
        {
            CoreUISignals.Instance.onOpenPanel.Invoke(UIPanelTypes.Win, 2);
        }

        private void onLevelInitialize(byte arg0)
        {
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Level, 0);
            UISignals.Instance.onSetLevelValue?.Invoke(((byte)CoreGameSignals.Instance.onGetLevelValue?.Invoke()));
        }

        private void OnReset()
        {
            CoreUISignals.Instance.onCloseAllPanels?.Invoke();
            CoreUISignals.Instance.onOpenPanel?.Invoke(UIPanelTypes.Start, 1);
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= onLevelInitialize;
            CoreGameSignals.Instance.onlevelSuccessful -= onlevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= onLevelFailed;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        public void Play()
        {
            UISignals.Instance.onPlay?.Invoke();
            CoreUISignals.Instance.onClosePanel?.Invoke(1);
            InputSignals.Instance.onEnableInput?.Invoke();
            //CameraSignals.Instance.onSetCameraTarget?.Invoke();
            
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
        }
    }
}