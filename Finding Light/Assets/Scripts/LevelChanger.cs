using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    public static event UnityAction LevelChangedToNext;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            LevelChangedToNext?.Invoke();
    }
}
