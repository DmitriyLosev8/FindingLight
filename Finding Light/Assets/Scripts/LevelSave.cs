using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSave : MonoBehaviour
{
    private int _countOfAvailableLevels;
    private List<int> _allLevels = new List<int>();
    public List<int> AvailableLevels; 

    private int _startLevel = 1;


    //public int Lights => _lights;

   // public static UnityAction<int> LightChanged;

    private void Start()
    {

        
        FillAllLevels();
        SetCountOfAvalaibleLevels();
        SetAvalaibleLevels();

        //if (Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Level_Number))
        //    _countOfAvailableLevels = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Level_Number);
        //else
        //    Debug.Log("Бан");


        //if (UnityEngine.PlayerPrefs.HasKey(KeySave.Light_Orb))
        //    _lights = UnityEngine.PlayerPrefs.GetInt(_loghtOrbs);
        //else
        //    Debug.Log("Бан");

        //if (Agava.YandexGames.PlayerPrefs.GetInt(KeySave.LEVEL_NUMBER) == 0)
        //    _lights = _startLights;


        // LightChanged?.Invoke(_lights);
        // Debug.Log("Вот сколько шаров на старте -  " + _lights);
    }

    private void FillAllLevels()
    {
        int CountOfLevels = 9;
        int currentLevel = 0;

        for(int i = 0; i < CountOfLevels; i++)
        {
            _allLevels.Add(currentLevel++);
           // Debug.Log(_AllLevels[i]);
        }   
    }

    private void SetCountOfAvalaibleLevels()
    {
        int correctNumber = 1;

        _countOfAvailableLevels = SceneManager.GetActiveScene().buildIndex + correctNumber;

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            _countOfAvailableLevels += _startLevel;
        }

        if (Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Level_Number))
        {
            if (_countOfAvailableLevels > Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Level_Number))
                Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Level_Number, _countOfAvailableLevels);
        }
        else
        {
           // Debug.Log("нет ключа в самом начале");
            Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Level_Number, _countOfAvailableLevels);

            //if (Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Level_Number))
            //    Debug.Log("кдюч задан");
        }
            
    }

    private void SetAvalaibleLevels()
    {
        for(int i = 0; i < _countOfAvailableLevels; i++)
        {
            AvailableLevels.Add(_allLevels[i]);
            Debug.Log("Доступные уровни - " + AvailableLevels[i] + " ");
        }
    }

    public void ApplyLights(int light)
    {
       // _lights += light;
       // LightChanged?.Invoke(_lights);
        //UnityEngine.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);
        //Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);

        // string lightsJson = JsonUtility.ToJson(_lights);
        // PlayerAccount.SetCloudSaveData(lightsJson);
    }

    //public void LoadLights()
    //{
    //    PlayerAccount.GetCloudSaveData(OnLoadSuccess);
    //}

    //public void LoseLights(int light)
    //{
    //    _lights -= light;
    //    LightChanged?.Invoke(_lights);
    //    Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);

    //}

    //private void OnLoadSuccess(string cloudLights)
    //{
    //    _lights = JsonUtility.FromJson<int>(cloudLights);
    //    Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);
    //}
}
