using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;
using System;

public class YandexAds : MonoBehaviour
{
    private const int _rewardAmount = 250;
    private CarsObserver _cardObserver;

    private bool _soundStatus = false;

    public Action _adRewarded;

    private void OnLevelWasLoaded(int level)
    {
        _cardObserver = FindObjectOfType<CarsObserver>();
        _cardObserver.PlayerFinished += ShowFullScreenAd;
    }

    private void OnEnable()
    {
        _adRewarded += OnRewarded;
    }

    private void OnDisable()
    {
        _adRewarded -= OnRewarded;
    }

    public void ShowRewardedAd()
    {
#if YANDEX_GAMES
        VideoAd.Show(_adOpened, _adReward, _adClosed, _adErrorOccured);
#endif
#if VK_GAMES
        Agava.VKGames.VideoAd.Show(_adRewarded);
#endif
    }

    public void ShowFullScreenAd()
    {
        print("Ad Shown!");

#if VK_GAMES
        Agava.VKGames.Interstitial.Show();
#endif
#if YANDEX_GAMES
        InterstitialAd.Show(OnOpen, onCloseCallback: OnFullScreenShowed);
#endif
    }

    public void OnOpen()
    {
        _soundStatus = AudioListener.pause;
        AudioListener.pause = true;
    }

    public void OnRewarded()
    {
        PointsTransmitter.Instance.OnTransaction(_rewardAmount);
    }

    public void OnRewardedClosed()
    {
        AudioListener.pause = _soundStatus;
    }

    public void OnFullScreenShowed(bool parameter)
    {
        AudioListener.pause = _soundStatus;
    }
}
