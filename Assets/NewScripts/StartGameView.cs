using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartGameView : MonoBehaviour
{
    [SerializeField] private Button _startGameButton;
    [SerializeField] private Button _garageButton;
    [SerializeField] private Button _rewardADSButton;
    [SerializeField] private Button _backMenuButton;
    [SerializeField] private UIController _controller;
    [SerializeField] private GameObject _testOBJ;

    private void OnEnable()
    {
        _startGameButton.onClick.AddListener(OnStartButtonCliked);
        _garageButton.onClick.AddListener(OnGarageButtonCliked);
        _rewardADSButton.onClick.AddListener(OnRewardADSButtonCliked);
        _controller.MainMenuShowStatusChanged += OnMenuStatusChanged;
        _backMenuButton.onClick.AddListener(OnBackMenuBattonCliked);
    }

    private void OnDisable()
    {
        _startGameButton.onClick.RemoveListener(OnStartButtonCliked);
        _garageButton.onClick.RemoveListener(OnGarageButtonCliked);
        _rewardADSButton.onClick.RemoveListener(OnRewardADSButtonCliked);
        _controller.MainMenuShowStatusChanged -= OnMenuStatusChanged;
        _backMenuButton.onClick.RemoveListener(OnBackMenuBattonCliked);
    }

    private void OnMenuStatusChanged(bool isShow)
    {
        _startGameButton.gameObject.SetActive(isShow);
    }

    private void OnGarageButtonCliked()
    {
        _controller.InvokeButtonClicked(_garageButton);
        _controller.ShowGarage();
    }

    private void OnRewardADSButtonCliked()
    {
        _controller.InvokeButtonClicked(_rewardADSButton);
        _controller.ShowADS();
        _testOBJ.SetActive(true);
    }

    private void OnStartButtonCliked()
    {
        _controller.InvokeButtonClicked(_startGameButton);
        _controller.StartGame();
    }

    private void OnBackMenuBattonCliked()
    {
        _controller.InvokeButtonClicked(_backMenuButton);
        _controller.ShowBackMenu();
    }
}
