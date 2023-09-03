using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    private PlayerInput _playerInput;

    public static event UnityAction PlayButtonClicked;
    public static event UnityAction ExitButtonClicked;

    public void OnPlayButtonClicked()
    {
        PlayButtonClicked?.Invoke();    
    }

    public void OnExitButtonClicked()
    {
        ExitButtonClicked?.Invoke();
    }
}
