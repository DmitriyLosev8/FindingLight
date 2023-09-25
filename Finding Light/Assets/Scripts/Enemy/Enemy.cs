using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] private bool _isScullPanelEnemy;

    private float _healthDamage;
    private float _oxygenDamage;
    private float _lightDamage;

    private int _sendingDamage;

    private void Start()
    {
        ChoseRandomDamage();
    }

    private void Update()
    {
        SetValueOfDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
           // SetValueOfDamage(player.Level);

            switch (_sendingDamage)
            {
                case 0:
                    player.TakeHealthDamage(_healthDamage);
                    break;
                case 1:
                    player.TakeOxygenDamage(_oxygenDamage);
                    break;
                case 2:
                    player.TakeLightDamage(_lightDamage);
                    break;
            }
        }
    }

    private void ChoseRandomDamage()
    {
        int countOfDamages = 3;
        _sendingDamage = Random.Range(0, countOfDamages);
    }

    private void SetValueOfDamage()
    {
        int lowDamage = 3;
        int middleDamage = 5;
        int highDamage = 8;
        int scullPanelDamage = 150;
           
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _healthDamage = lowDamage;
            _oxygenDamage = lowDamage;
            _lightDamage = lowDamage;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            _healthDamage = middleDamage;
            _oxygenDamage = middleDamage;
            _lightDamage = middleDamage;
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            _healthDamage = highDamage;
            _oxygenDamage = highDamage;
            _lightDamage = highDamage;
        }

        if (_isScullPanelEnemy)
        {
            _healthDamage = scullPanelDamage;
            _oxygenDamage = scullPanelDamage;
            _lightDamage = scullPanelDamage;
        }
    }
}
