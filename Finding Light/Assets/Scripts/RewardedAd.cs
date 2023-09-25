using System;
using System.Collections;
using System.Collections.Generic;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardedAd : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _rewardUI;
    [SerializeField] private int _initialReward = 10;
    [SerializeField] private int _rewardMultiplier = 2;
    [SerializeField] private LightContainer _lightContainer;

    private int _digitsCount = 2;
    private string[] _names = { "", "K", "M", "B", "T" };
    private int _amountReductionStart = 1000;
    private int _reward;
    private readonly string _money = "$";
    private readonly string _plus = "+";
    private readonly string _rewardtypeAddClick = "rewardtype-ad-click";
    private readonly string _gold = "gold";
    private readonly string _rewardText = "reward";
    private readonly string _rewardButton =  "reward button";
    private int _adStep = 5;

    private Action _adOpened;
    private Action _adClosed;
    private Action _adRewarded;
    private Action<bool> _interstitialAdClosed;
    private Action<string> _addErrorOccured;



    private void Start()
    {
       // TryToShowVideoAdd();
        UpdateRewardValue();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
        _adOpened += OnAddOpened;
        _adClosed += OnAddClosed;
        _adRewarded += OnAddRewarded;
    }

   

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
        _adOpened -= OnAddOpened;
        _adClosed -= OnAddClosed;
        _adRewarded -= OnAddRewarded;
    }

    private void OnAddClosed()
    {
        EnableSound();
        Time.timeScale = 1;
    }

    private void EnableSound()
    {
        AudioListener.pause = false;
       // AudioListener.volume = Agava.YandexGames.PlayerPrefs.GetFloat(KeySave.AUDIO_LEVEL);
    }

    private void OnAddRewarded()
    {
        UpdateRewardValue();
        _lightContainer.ApplyLights(_reward);
        gameObject.SetActive(false);
        
    }

    private void OnAddOpened()
    {
        AudioListener.pause = true;
        AudioListener.volume = 0;
        Time.timeScale = 0;
    }

    private void OnClick()
    {

        VideoAd.Show(_adOpened, _adRewarded, _adClosed, _addErrorOccured);

#if YANDEX_GAMES && !UNITY_EDITOR
              VideoAd.Show(_adOpened, _adRewarded, _adClosed, _adErrorOccured);

#endif

#if UNITY_EDITOR

#endif

    }

    private void ShowInterstitialVideoAd()
    {
        InterstitialAd.Show(_adOpened,_interstitialAdClosed,_addErrorOccured);
    }

    private void UpdateRewardValue()
    {
       // _reward = (int)(Agava.YandexGames.PlayerPrefs.GetInt(KeySave.ABILITY_PRICE) * _rewardMultiplier);

        if(_reward < _initialReward)
            _reward = _initialReward;

        _rewardUI.text = _plus + RoundReward(_reward);
    }

    private string RoundReward(int reward)
    {
        int count = 0;

        while(count +1 < _names.Length && reward >= _amountReductionStart)
        {
            reward /= _amountReductionStart;
            count++;
        }

        float value = (float)Math.Round((float)reward, _digitsCount);
        string convertValue = value.ToString();
        string convertReward = convertValue + _names[count] + reward;

        return convertReward; 
    }

    private void TryToShowVideoAdd()
    {
       // int currentLevel = (Agava.YandexGames.PlayerPrefs.GetInt(KeySave.LEVEL_NUMBER) + 1);
       // int lastAdLevel = Agava.YandexGames.PlayerPrefs.GetInt(KeySave.LAST_AD_LEVEL);

        //if (currentLevel % _adStep == 0 && lastAdLevel != currentLevel)
        //{
        //    Agava.YandexGames.PlayerPrefs.SetInt(KeySave.LAST_AD_LEVEL, currentLevel);
        //}
    }
}
