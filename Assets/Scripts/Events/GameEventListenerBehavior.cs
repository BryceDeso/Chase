using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerBehavior : MonoBehaviour, IListener
{
    [SerializeField]
    private UnityEvent _actions;
    [SerializeField]
    private Event _event;
    [SerializeField]
    private GameObject _intendedsender;

    public void Invoke(GameObject Sender)
    {
        if (_intendedsender == null || _intendedsender == Sender)
        {
            _actions.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _event.AddListener(this);
    }
}
