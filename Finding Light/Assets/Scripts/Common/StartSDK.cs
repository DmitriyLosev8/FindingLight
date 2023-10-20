using System.Collections;
using Agava.YandexGames;
using Agava.YandexGames.Samples;
using System.Collections.Generic;
using UnityEngine;

public class StartSDK : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Start());
    }


    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
        YandexGamesSdk.GameReady();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);
    }
}
