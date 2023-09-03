using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUISystem : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Slider _health;
    [SerializeField] private Slider _oxygen;
    [SerializeField] private List<IconOfDoor> _iconsOfDoor;
    [SerializeField] private TMP_Text _greetings;

    private float _timeOfGreetings = 10;

    private void Start()
    {
        _health.value = _player.Health;
        _oxygen.value = _player.Oxygen;
    }

    private void Update()
    {
        GreetingsWork();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _player.OxygenChanged += OnOxygenChanged;
        Door.Opened += OnDoorOpened;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
        _player.OxygenChanged -= OnOxygenChanged;
        Door.Opened -= OnDoorOpened;
    }

    private void OnHealthChanged(float health)
    {
        _health.value = _player.Health;
    }

    private void OnOxygenChanged(float oxygen)
    {
        _oxygen.value = _player.Oxygen;
    }

    private void OnDoorOpened(int id)
    {
        for(int i = 0; i < _iconsOfDoor.Count; i++)
        {
            if(id == i)
                _iconsOfDoor[i].StartOpenedAnimation();
        }
    }

    private void GreetingsWork()
    {
        _timeOfGreetings -= Time.deltaTime;

        if (_timeOfGreetings <= 0)
            _greetings.enabled = false;
    }
}
