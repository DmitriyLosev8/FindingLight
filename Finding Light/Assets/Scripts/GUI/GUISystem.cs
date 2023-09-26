using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GUISystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _health;
    [SerializeField] private Slider _oxygen;
    [SerializeField] private List<IconOfDoor> _iconsOfDoor;
    [SerializeField] private AudioSource _music;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private TMP_Text _lightsCount;
    [SerializeField] private LightContainer _lightContainer;
    [SerializeField] private TMP_Text _levels;
    [SerializeField] private GameObject _joyStick;

    private void Start()
    {
        _health.value = _player.Health;
        _oxygen.value = _player.Oxygen;
        _lightsCount.text = _lightContainer.Lights.ToString();
        
        if (Application.isMobilePlatform)
            EnableJoistick();
       // _lightsCount.text = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Light_Orb).ToString();
    }

    private void Update()
    {
        _health.value = _player.Health;
       // _levels.text = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.Levels_Number).ToString();
    }

    private void OnEnable()
    {
        // _player.HealthChanged += OnHealthChanged;
        LightContainer.LightChanged += OnLightChanged;
        _player.OxygenChanged += OnOxygenChanged;
        PauseMenu.Unpaused += OnUnpaused;
        _musicToggle.onValueChanged.AddListener(TurnSound);
    }

   

    private void OnDisable()
    {
        // _player.HealthChanged -= OnHealthChanged;
        LightContainer.LightChanged -= OnLightChanged;
        _player.OxygenChanged -= OnOxygenChanged;
        PauseMenu.Unpaused -= OnUnpaused;
        _musicToggle.onValueChanged.RemoveListener(TurnSound);
    }

    //private void OnHealthChanged(float health)
    //{
    //    _health.value = health;
    //}

    private void EnableJoistick()
    {
        _joyStick.SetActive(true);
    }
    private void OnLightChanged(int lightsOrbs)
    {
        _lightsCount.text = lightsOrbs.ToString();
    }

    private void OnOxygenChanged(float oxygen)
    {
        _oxygen.value = oxygen;
    }

    private void OnUnpaused()
    {
        _music.UnPause();
    }

    public void TurnSound(bool isOn)
    {
        if (isOn)
            _music.Play();
        else
            _music.Stop();
    }
}
