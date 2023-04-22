using System;
using Charizard.Views.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Charizard.Views
{
    public class StartView : BaseView
    {
        public event Action OnClickButtonStart;

        [SerializeField] private Button _buttonStart;

        private void Awake()
        {
            _buttonStart.onClick.AddListener(() => StartGame(null));
        }

        public override void Initialize()
        {

        }

        private void StartGame(EventParam param) => TriggerEvent(UIEventType.Start, param);
    }
}