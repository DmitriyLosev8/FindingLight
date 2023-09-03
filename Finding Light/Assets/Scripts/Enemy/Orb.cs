using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] private int _oxygenValueToGive;
    [SerializeField] private int _lightValueToGive;
    [SerializeField] private bool _isOxygen;
    
    private Player _player;
    private Vector3 _targetPosition;
    private float _speed = 5.8f;
      
    public bool _isSpoted = false;
    private void Update()
    {
        if (_player != null)
            BecomeCollected(_player);
    }

    private void BecomeCollected(Player player)
    {
        DetermineTargetPosition();

        if (_isSpoted)
         transform.position = Vector3.MoveTowards(transform.position,_targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)
        {
            if (_isOxygen)
                player.TakeOxygen(_oxygenValueToGive);
            else
                player.TakeLight(_lightValueToGive);

            Destroy(gameObject);
        }      
    }

    public void DeterminePlayer(Player player)
    {
        _player = player;  
    }

    private void DetermineTargetPosition()
    {
        float offsetY = 1;
        _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y + offsetY, _player.transform.position.z);
    }
}
