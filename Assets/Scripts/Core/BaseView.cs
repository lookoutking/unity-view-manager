using System;
using System.Collections.Generic;
using UnityEngine;

namespace Charizard.Views.Core
{
    public class EventParam { }

    /// <summary>
    /// Base class of every UI View
    /// </summary>
    public abstract class BaseView<TProperties> : BaseView where TProperties : ViewProperties
    {
        protected TProperties _data;

        public virtual void OnSetProperties(TProperties data)
        {
            _data = data;
        }
    }


    public abstract class BaseView : MonoBehaviour
    {
        protected Dictionary<UIEventType, Action<EventParam>> _events = new();

        public abstract void Initialize();

        protected virtual void OnDestroy()
        {
            RemoveAllListeners();
        }

        public virtual void Hide() => gameObject.SetActive(false);

        public virtual void Show() => gameObject.SetActive(true);

        public void AddListener(UIEventType eventType, Action<EventParam> listener)
        {
            if (_events.TryGetValue(eventType, out Action<EventParam> thisEvent))
            {
                thisEvent += listener;
                _events[eventType] = thisEvent;
            }
            else
            {
                thisEvent += listener;
                _events.Add(eventType, thisEvent);
            }
        }

        // Remove an event from the dictionary
        public void RemoveListener(UIEventType eventType, Action<EventParam> listener)
        {
            if (_events.TryGetValue(eventType, out Action<EventParam> thisEvent))
            {
                thisEvent -= listener;
                _events[eventType] = thisEvent;
            }
        }

        public void RemoveAllListeners()
        {
            _events.Clear();
        }

        // Trigger an event with a single argument
        public void TriggerEvent(UIEventType eventType, EventParam arg)
        {
            if (_events.TryGetValue(eventType, out Action<EventParam> thisEvent))
            {
                thisEvent?.Invoke(arg);
            }
        }
    }
}