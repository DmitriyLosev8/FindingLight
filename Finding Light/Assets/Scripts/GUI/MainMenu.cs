using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    //private PlayerInput _playerInput;

    public static event UnityAction PlayButtonClicked;
    [SerializeField] private GameObject _levelsPanel;


    public void OnPlayButtonClicked()
    {
        _levelsPanel.SetActive(true);

        // PlayButtonClicked?.Invoke();
    }
}
