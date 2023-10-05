using System.Collections.Generic;
using RunTime.Enums;
using RunTime.Signals;
using Sirenix.OdinInspector;
using UnityEngine;


namespace RunTime.Controllers.UI
{
    public class UIPanelController : MonoBehaviour
    {
        [SerializeField] private List<Transform> layers = new List<Transform>();

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel += OnClosePanel;
            CoreUISignals.Instance.onOpenPanel += OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels += onCloseAllPanels;
        }


        [Button("Close All Panel")]
        private void onCloseAllPanels()
        {
            foreach (var layer in layers)
            {
                if (layer.childCount <= 0) return;

#if UNITY_EDITOR
                DestroyImmediate(layer.GetChild(0).gameObject);
#else
                Destroy(layer.GetChild(0).gameObject);
#endif
            }
        }

        [Button("Open Panel")]
        private void OnOpenPanel(UIPanelTypes panelTypes, int value)
        {
            OnClosePanel(value);
            Instantiate(Resources.Load<GameObject>($"Screens/{panelTypes}Panel"), layers[value]);
        }

        [Button("Close Panel")]
        private void OnClosePanel(int value)
        {
            if (layers[value].childCount <= 0) return;
            
#if UNITY_EDITOR
                DestroyImmediate(layers[value].GetChild(0).gameObject);
#else
                Destroy(layers[value].GetChild(0).gameObject);
#endif
            
        }

        private void UnSubscribeEvents()
        {
            CoreUISignals.Instance.onClosePanel -= OnClosePanel;
            CoreUISignals.Instance.onOpenPanel -= OnOpenPanel;
            CoreUISignals.Instance.onCloseAllPanels -= onCloseAllPanels;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}