using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;
using RunTime.Signals;
using Sirenix.OdinInspector;
using TMPro;

namespace RunTime.Controllers.UI
{
    public class LevelPanelController : MonoBehaviour
    {
        [SerializeField] private List<Image> stageImages = new List<Image>();
        [SerializeField] private List<TextMeshProUGUI> levelTexts = new List<TextMeshProUGUI>();
        
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue += OnSetLevelValue;
            UISignals.Instance.onSetStageColor += OnSetStageColor;
        }

        [Button("SetStageColor")]
        private void OnSetStageColor(byte stageValue)
        {
            stageImages[stageValue].DOColor(new Color(0.7722455f, 0.1123049f, 0.02765238f), 0.5f);
        }

        private void OnSetLevelValue(byte levelValue)
        {
            var additionalValue = ++levelValue;
            levelTexts[0].text = additionalValue.ToString();
            additionalValue++;
            levelTexts[1].text = additionalValue.ToString();
        }

        private void UnSubscribeEvents()
        {
            UISignals.Instance.onSetLevelValue -= OnSetLevelValue;
            UISignals.Instance.onSetStageColor -= OnSetStageColor;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
}