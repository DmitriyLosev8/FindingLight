using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    private const string CanOpen = "CanOpen";

    [SerializeField] private int _id;

    private Animator _animator;

    public int Id => _id;
    public static event UnityAction<int> Opened;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Key key))
        {
            if (key.Id == _id)
                _animator.SetBool(CanOpen, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Key key))
        {
            if (key.Id == _id)
                Destroy(key.gameObject);

            Opened?.Invoke(_id);
        }
    }
}
