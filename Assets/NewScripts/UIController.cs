using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private LiderboardView _liderBoardView;
    [SerializeField] private StartGameView _startView;
    [SerializeField] private SettingView _settingView;
    [SerializeField] private BuyCarView _buyCarView;

    public event Action<Button> OnButtonClicked;
    public event Action<bool> MainMenuShowStatusChanged;

    public void InvokeButtonClicked(Button button)
    {
        OnButtonClicked?.Invoke(button);
    }

    public void ShowADS()
    {
        Debug.Log("ShowREWARD");
    }

    public void StartGame()
    {
        Debug.Log("LoadScene");
    }

    public void ShowGarage()
    {
        Debug.Log("ShowPriceCar");
        MainMenuShowStatusChanged?.Invoke(false);
    }

    public void ShowBackMenu()
    {
        Debug.Log("¬ключаю меню обратно");
        MainMenuShowStatusChanged?.Invoke(true);
    }
}
