using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _healthDamage;
    [SerializeField] int _oxygenDamage;
    [SerializeField] int _lightDamage;

    private int _sendingDamage;

    private void Start()
    {
        ChoseRandomDamage();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
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
}
