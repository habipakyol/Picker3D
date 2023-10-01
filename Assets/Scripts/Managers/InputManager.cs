using System;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using Unity.Mathematics;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        private InputData _data;
        private bool _isAvailableForTouch, _isFirstTimeTouchTaken, _isTouching;

        private float _currentVelocity;
        private float3 _moveVector;
        private Vector2? _mousePosition;


        private void Awake()
        {
            _data = GetInputData();
        }

        private InputData GetInputData()
        {
            return Resources.Load<CD_Input>("Data/CD_Input").Data;
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += Onreset;
            InputSignals.Instance.OnEnableInput += OnEnableInput;
            InputSignals.Instance.OnDisableInput += onDisableInput;
        }

        private void onDisableInput()
        {
            _isAvailableForTouch = false;
        }

        private void OnEnableInput()
        {
            _isAvailableForTouch = true;
        }

        private void Onreset()
        {
            _isAvailableForTouch = false;
            _isTouching = false;
            //_isFirstTimeTouchTaken = false;
        }
        
        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= Onreset;
            InputSignals.Instance.OnEnableInput -= OnEnableInput;
            InputSignals.Instance.OnDisableInput -= onDisableInput;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }
    }
    
}