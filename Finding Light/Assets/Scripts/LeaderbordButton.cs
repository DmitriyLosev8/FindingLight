using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.UI;


public class LeaderbordButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Button _closeButton;
    [SerializeField] private LeaderboardDisplay _leaderbordDisplay;
    [SerializeField] private LightContainer _lightCounter;
    [SerializeField] private PauseMenu _pauseMenu;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
        _closeButton.onClick.AddListener(OnCloseButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
        _closeButton.onClick.RemoveListener(OnCloseButtonClick);
    }

    private void OnButtonClick()
    {
        if (_leaderbordDisplay.gameObject.activeSelf)
            Hide();
        else
        {
            _pauseMenu.PauseGame(_leaderbordDisplay.gameObject);
            Show();
        }
            
    }

    private void OnCloseButtonClick()
    {
        _leaderbordDisplay.gameObject.SetActive(false);
        _pauseMenu.ResumeGame(_leaderbordDisplay.gameObject);
    }

    private void Hide()
    {
        _leaderbordDisplay.gameObject.SetActive(false);
    }

    private void Show()
    {
        _leaderbordDisplay.gameObject.SetActive(true);
        _leaderbordDisplay.OpenLeaderboard();
    }
}
