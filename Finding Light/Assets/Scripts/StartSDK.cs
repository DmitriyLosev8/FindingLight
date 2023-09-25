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

        // Always wait for it if invoking something immediately in the first scene.
        yield return YandexGamesSdk.Initialize();

        if (PlayerAccount.IsAuthorized == false)
            PlayerAccount.StartAuthorizationPolling(1500);

        //while (true)
        //{
        //    _authorizationStatusText.color = PlayerAccount.IsAuthorized ? Color.green : Color.red;

        //    if (PlayerAccount.IsAuthorized)
        //        _personalProfileDataPermissionStatusText.color = PlayerAccount.HasPersonalProfileDataPermission ? Color.green : Color.red;
        //    else
        //        _personalProfileDataPermissionStatusText.color = Color.red;

        //    yield return new WaitForSecondsRealtime(0.25f);
        //}
    }
}
