using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanel : MonoBehaviour
{
    [SerializeField] private List<LevelButton> _levelButtons;
    [SerializeField] private LevelSave _levelSave;

    private int _openedLevels;

    private void Start()
    {
        Paint();
    }


    private void Paint()
    {
        int mainMenu = 1;

        if (Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Level))
        {
            _openedLevels = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Level);  
        }
            
       for(int i = 0; i < _openedLevels - mainMenu; i++)
        {
            _levelButtons[i].SetWhiteColor();
        }
    }
}

