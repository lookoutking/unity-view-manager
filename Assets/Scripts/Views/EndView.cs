using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Charizard.Views.Core;

namespace Charizard.Views
{
    public class EndView : BaseView<EndViewData>
    {
        [SerializeField] private Button _buttonBack;
        [SerializeField] private TMP_Text _textName;

        private void Awake()
        {
            _buttonBack.onClick.AddListener(() => Back(null));
        }

        public override void Initialize()
        {

        }

        public override void OnSetProperties(EndViewData data)
        {
            base.OnSetProperties(data);
            _textName.text = data.name;
        }

        private void Back(EventParam param) => TriggerEvent(UIEventType.Back, param);
    }

    public class EndViewData : ViewProperties
    {
        public string name;
    }

}