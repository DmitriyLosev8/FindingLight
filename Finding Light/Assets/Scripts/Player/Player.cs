using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _oxygen;
    [SerializeField] private ParticleSystem _effectOfDying;
    [SerializeField] private Transform _raycastStartPoint;
    [SerializeField] private GameObject _laternSpotLight;
    [SerializeField] private Transform _keySpace;
    [SerializeField] private Arrow _arrow;

    private Light _spotLight;
    private float _positionYToSelfDesttoy = -30f;
    private float _oxygenLosingDamage = 0.005f; //0.0010f;
    private float _healthLosingDamage = 0.002f; //0.0006f;

    public bool IsHaveKey { get; private set; }
    public int DefaultValueOfCurrentKeyId = 100;
    public int CurrentKeyID;

    public static event UnityAction Died;
    public event UnityAction<float> HealthChanged;
    public event UnityAction<float> OxygenChanged;
    public event UnityAction OxygenBecomeEmpty;

    public int Level { get; private set; }
    public float Health => _health;
    public float Oxygen => _oxygen;
    
    private void Start()
    {
        _spotLight = _laternSpotLight.GetComponent<Light>();
    }

    private void Update()
    {
        if (transform.position.y <= _positionYToSelfDesttoy)
            Die();

        TryToCollectOrb();

        EternalDamagePerTime();

        if (IsHaveKey)
        {
            Debug.Log(CurrentKeyID);
        }
    }

    private void TryToCollectOrb()
    {
        float distanceToSpot = 3.5f;
        Ray rayToSpot = new Ray(_raycastStartPoint.transform.position, transform.forward);
        RaycastHit hit; 

        if(Physics.Raycast(rayToSpot, out hit, distanceToSpot))
        {
            Orb orb = hit.collider.gameObject.GetComponent<Orb>();

            if (orb)
            {
                orb._isSpoted = true;
                orb.DeterminePlayer(this);          
            }        
        }
    }

    public void TakeHealthDamage(float healthDamage)
    {
        _health -= healthDamage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0) 
            Die();
    }

    public void TakeOxygenDamage(float oxygenDamage)
    {
        if(_oxygen > 0)
        {
            _oxygen -= oxygenDamage;
            OxygenChanged?.Invoke(_oxygen);
        }

        if (_oxygen < 0)
            _oxygen = 0;

    }

    public void TakeLightDamage(int lightDamage)
    {
        if(_spotLight.spotAngle > 0)
            _spotLight.spotAngle -= lightDamage;
    }

    public void TakeOxygen(float valueOfOxygen)
    {
        int maxOxygen = 100;

        if (_oxygen < maxOxygen)
        {
            _oxygen += valueOfOxygen;
            OxygenChanged?.Invoke(_oxygen);
        }  
    }

    public void TakeLight(int valueOfLight)
    {
        int maxValueOfLigth = 50;

        if (_spotLight.spotAngle < maxValueOfLigth)
            _spotLight.spotAngle += valueOfLight;
    }

    private void PickUpKey(Key key)
    {
         key.transform.position = _keySpace.position;
         key.transform.rotation = _keySpace.rotation;
         key.transform.SetParent(_keySpace);
         IsHaveKey = true;
         CurrentKeyID = key.Id;
         EnableArrow();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Key key))
            PickUpKey(key);  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Door door))
        {     
            if (door.Id == CurrentKeyID)
            {
                IsHaveKey = false;
                DisableArrow();
                CurrentKeyID = DefaultValueOfCurrentKeyId;
                Destroy(GetComponent<Key>());
            }                
        }
    }

    private void Die()
    {
        Instantiate(_effectOfDying, transform.position, Quaternion.identity);
        Died?.Invoke();
        Destroy(gameObject);
    }

    private void EternalDamagePerTime()
    {
        if (_oxygen <= 0)
            SlowlyDie();
        else
            OxygenLosing();
    }

    private void SlowlyDie()
    {
        _health -= _healthLosingDamage;
        HealthChanged?.Invoke(_health);
    }

    private void OxygenLosing()
    {
        _oxygen -= _oxygenLosingDamage;
        OxygenChanged?.Invoke(_oxygen);
    }

    private void EnableArrow()
    {
        _arrow.gameObject.SetActive(true);
    }

    private void DisableArrow()
    {
        _arrow.gameObject.SetActive(false);
    }
}
