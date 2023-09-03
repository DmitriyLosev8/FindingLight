using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetFollow))]  
public class Arrow : MonoBehaviour
{
    [SerializeField] private List<Door> _doors;
    [SerializeField] private Player _player;
    
    private void Update()
    {    
        if(_player.IsHaveKey) 
            transform.LookAt(_doors[_player.CurrentKeyID].transform.position); 
    }
}

