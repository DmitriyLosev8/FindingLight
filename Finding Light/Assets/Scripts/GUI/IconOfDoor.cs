using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IconOfDoor : MonoBehaviour
{
    private const string CanBecomeGreen = "CanBecomeGreen";

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartOpenedAnimation()
    {
        _animator.SetBool(CanBecomeGreen, true);
    }
}
