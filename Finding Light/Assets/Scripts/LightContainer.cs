using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using UnityEngine;
using UnityEngine.Events;

public class LightContainer : MonoBehaviour
{
    private int _lights;
    private int _startLights = 0;
   // private string _loghtOrbs = "light orbs";

    public int Lights => _lights;

    public static UnityAction<int> LightChanged;

    private void Start()
    {

        if (Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Light_Orb))
            _lights = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Light_Orb);
        else
        {
            _lights = _startLights;
            Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);
            Debug.Log("колво доступных шаров из старта - " + Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Light_Orb));
        }
            


        //if (UnityEngine.PlayerPrefs.HasKey(KeySave.Light_Orb))
        //    _lights = UnityEngine.PlayerPrefs.GetInt(_loghtOrbs);
        //else
        //    Debug.Log("Бан");

        //if (Agava.YandexGames.PlayerPrefs.GetInt(KeySave.LEVEL_NUMBER) == 0)
        //    _lights = _startLights;


        LightChanged?.Invoke(_lights);
       // Debug.Log("Вот сколько шаров на старте -  " + _lights);
    }

    //private void Awake()
    //{
    //    if (!Agava.YandexGames.PlayerPrefs.HasKey(KeySave.Light_Orb))
    //    {
    //        Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _startLights);
    //    }
    //}

    //private void Update()
    //{
    //    Debug.Log(UnityEngine.PlayerPrefs.GetInt(KeySave.Light_Orb));
    //}

    public void ApplyLights(int light)
    {
        _lights += light;
        LightChanged?.Invoke(_lights);
        //UnityEngine.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);
        Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);

        // string lightsJson = JsonUtility.ToJson(_lights);
        // PlayerAccount.SetCloudSaveData(lightsJson);
    }

    public void LoadLights()
    {
        PlayerAccount.GetCloudSaveData(OnLoadSuccess);
    }

    public void LoseLights(int light)
    {
        _lights -= light;
        LightChanged?.Invoke(_lights);
        Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);

    }

    private void OnLoadSuccess(string cloudLights)
    {
        _lights = JsonUtility.FromJson<int>(cloudLights);
        Agava.YandexGames.PlayerPrefs.SetInt(KeySave.Light_Orb, _lights);
    }
}
