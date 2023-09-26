using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NewLevelZone : MonoBehaviour
{
    public static event UnityAction NewLevelOpened;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            NewLevelOpened?.Invoke();
    }
}
