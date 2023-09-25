using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Agava.YandexGames.Samples 
{
    public class LeaderboardDisplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _payerScore;
        [SerializeField] private TMP_Text _authorizationStatusText;
        [SerializeField] private TMP_Text _personalProfileDataPermissionStatusText;
        [SerializeField] private TMP_Text[] _ranks;
        [SerializeField] private TMP_Text[] _leaderNames;
        [SerializeField] private TMP_Text[] _scoreList;
        [SerializeField] private LightContainer _lightContainer;
        [SerializeField] private string _leaderBoardName = "Leaderboard";
        [SerializeField] private InputField _cloudSaveDataInputField;

        private int _countOfLights;
        private readonly string _anonimus = "Anonimus";

        private void Awake()
        {
            YandexGamesSdk.CallbackLogging = true;
            _countOfLights = (int)_lightContainer.Lights;

            // StartCoroutine(Start());
            gameObject.SetActive(false);
        }


        public void OpenLeaderboard()
        {
            //  StartCoroutine(Start());

            Leaderboard.GetEntries(_leaderBoardName, result =>
            {
                int leaderNumber;

                if (result.entries.Length >= _leaderBoardName.Length)
                    leaderNumber = _leaderBoardName.Length;
                else
                    leaderNumber = result.entries.Length;

                for (int i = 0; i < leaderNumber; i++)
                {
                    string name = result.entries[i].player.publicName;

                    if (string.IsNullOrEmpty(name))
                    {
                        name = _anonimus;
                    }

                    _leaderNames[i].text = name;
                    _scoreList[i].text = result.entries[i].formattedScore;
                    _ranks[i].text = result.entries[i].rank.ToString();
                }
            },

            error =>
            {

            });
        }

        public void SetLeaderboardScore()
        {
            Leaderboard.GetPlayerEntry(_leaderBoardName, OnSuccessCallback);
        }

        private void OnSuccessCallback(LeaderboardEntryResponse result)
        {
            if (result == null || _lightContainer.Lights > result.score)
            {
                Leaderboard.SetScore(_leaderBoardName, _lightContainer.Lights);
            }
        }
    }


//        private IEnumerator Start()
//        {
//#if !UNITY_WEBGL || UNITY_EDITOR
//            yield break;
//#endif

//            // Always wait for it if invoking something immediately in the first scene.
//            yield return YandexGamesSdk.Initialize();

//            if (PlayerAccount.IsAuthorized == false)
//                PlayerAccount.StartAuthorizationPolling(1500);

//            while (true)
//            {
//                _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

//                if (PlayerAccount.IsAuthorized)
//                    _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
//                else
//                    _personalProfileDataPermissionStatusText.color = Color.red;

//                yield return new WaitForSecondsRealtime(0.25f);
//            }
//        }
//    }

}


