using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private LevelSave _levelSave;
  
    private int _sceneToLoad = 1;

    private void Start()
    {
        SaveCurrentLevel();
    }

    private void OnEnable()

    {
        LevelChanger.LevelChangedToNext += OnLevelChangedToNext;
        PauseMenu.LoadMainMenuButtonClicked += LoadMainMenu;
        Player.Died += OnPlayerDied;
        LevelButton.Clicked += OnLevelButtonClicked;
    }
    private void OnDisable()
    {
        LevelChanger.LevelChangedToNext -= OnLevelChangedToNext;
        PauseMenu.LoadMainMenuButtonClicked -= LoadMainMenu;
        Player.Died -= OnPlayerDied;
        LevelButton.Clicked -= OnLevelButtonClicked;
    }

    private void OnLevelButtonClicked(int levelButtonId)
    {

        for(int i = 0; i < _levelSave.AvailableLevels.Count; i++)
        {
            Debug.Log("Доступные уровни из кнопки - " + _levelSave.AvailableLevels[i] + " ");
            
            if (levelButtonId == _levelSave.AvailableLevels[i])
            {
                _sceneToLoad = levelButtonId;
                LoadScene();

            }
           else
                Debug.Log("ади не подходят, вот йади кнопки - " + levelButtonId + " вот доступный уровень - " + _levelSave.AvailableLevels[i]);
        }   
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(_sceneToLoad); 
    }

    //private void OnPlayButtonClicked()
    //{
    //    _levelsPanel.SetActive(true);
    //}

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
        LoadCurrenScene();
       // LoadMainMenu();
    }

    private void SaveCurrentLevel()
    {
        Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Level_Number, SceneManager.GetActiveScene().buildIndex);
    }
}
