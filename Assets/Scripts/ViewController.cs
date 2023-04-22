
using System;
using UnityEngine;
using Charizard.Views;
using Charizard.Views.Core;

namespace Game
{
    /// <summary>
    /// Control UI Flow
    /// Communicate with ViewManager and Presenter
    /// </summary>
    [RequireComponent(typeof(ViewManager))]
    public class ViewController : MonoBehaviour
    {
        private void Start()
        {
            ViewManager.GetView<StartView>().AddListener(UIEventType.Start, (_) => OnShowBackView());
            ViewManager.GetView<EndView>().AddListener(UIEventType.Back, (_) => OnShowStartView());
        }

        private void OnShowBackView()
        {
            ViewManager.ShowWithProperties<EndView, EndViewData>(new EndViewData { name = "End" });
        }

        private void OnShowStartView()
        {
            ViewManager.Show<StartView>();
        }
    }
}