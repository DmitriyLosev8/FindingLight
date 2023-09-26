using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _joyStick;
    [SerializeField] AudioSource _music;

    public static UnityAction LoadMainMenuButtonClicked;
    public static UnityAction Unpaused;

    public static bool IsPaused;

    private void Start()
    {
        _pausePanel.SetActive(false);
    }

    public void PauseGame(GameObject panel)
    {
        if (_pausePanel != null)
        {
            panel.SetActive(true);

            if (Application.isMobilePlatform)
                _joyStick.SetActive(false);  
            
            IsPaused = true;
            _music.Pause();
            Time.timeScale = 0;
        }
    }

    public void ResumeGame(GameObject panel)
    {
        panel.SetActive(false);

        if (Application.isMobilePlatform)
            _joyStick.SetActive(true);

        IsPaused = false;
        Time.timeScale = 1;
        Unpaused?.Invoke();
    }

    public void OnLoadMainMenuButtonClicked()
    {
        Time.timeScale = 1;
        LoadMainMenuButtonClicked?.Invoke();
    }
}
