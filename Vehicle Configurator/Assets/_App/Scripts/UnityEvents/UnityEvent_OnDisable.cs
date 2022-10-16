using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_OnDisable : MonoBehaviour
{
    [SerializeField] private UnityEvent onDisable;

    private void OnDisable() => onDisable?.Invoke();
}
