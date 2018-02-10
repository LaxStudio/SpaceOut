using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{

    [Tooltip("Event that can be triggered")]
    [SerializeField]
    public GameEvent Event;

    [Tooltip("The Response when the event is triggered")]
    [SerializeField]
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }

}