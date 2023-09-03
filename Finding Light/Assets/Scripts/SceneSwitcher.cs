using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    private int _sceneToLoad = 1;
    private void OnEnable()
    {
        MainMenu.PlayButtonClicked += LoadScene;
        MainMenu.ExitButtonClicked += OnExitButtonClicked;
        LevelChanger.LevelChangedToNext += OnLevelChangedToNext;
        PauseMenu.LoadMainMenuButtonClicked += LoadMainMenu;
        Player.Died += OnPlayerDied;
    }
    private void OnDisable()
    {
        MainMenu.PlayButtonClicked -= LoadScene;
        MainMenu.ExitButtonClicked -= OnExitButtonClicked;
        LevelChanger.LevelChangedToNext -= OnLevelChangedToNext;
        PauseMenu.LoadMainMenuButtonClicked -= LoadMainMenu;
        Player.Died -= OnPlayerDied;
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad); 
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }

    private void LoadMainMenu()
    {
        if (_sceneToLoad != 0)
            _sceneToLoad = 0;

        LoadScene();
    }

    private void LoadCurrenScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnLevelChangedToNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnPlayerDied()
    {
        StartCoroutine(AnimationOfDying());
    }

    private IEnumerator AnimationOfDying()
    {
        float delay = 0.5f;
        yield return new WaitForSeconds(delay);
        LoadMainMenu();
    }
}
