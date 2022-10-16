using UnityEngine;
using UnityEngine.Events;

public class UnityEvent_OnEnable : MonoBehaviour
{
    [SerializeField] private UnityEvent onEnable;

    private void OnEnable() => onEnable?.Invoke();
}