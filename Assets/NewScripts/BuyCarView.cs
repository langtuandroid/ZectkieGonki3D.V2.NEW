using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyCarView : MonoBehaviour
{
    [SerializeField] private GameObject[] _garageButtons;
    [SerializeField] private GameObject _backMebuButton;
    [SerializeField] private Button _upgradeMenu;
    [SerializeField] private UIController _controller;

    private void OnEnable()
    {
        _controller.OnButtonClicked += HandleButtonClick;
    }

    private void OnDisable()
    {
        _controller.OnButtonClicked -= HandleButtonClick;
    }

    private void HandleButtonClick(Button button)
    {
        if (button != _upgradeMenu)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        foreach (var button in _garageButtons)
        {
            button.SetActive(true);
        }

        _backMebuButton.SetActive(true);
        Debug.Log("Кнопка меню включена");
    }

    public void Hide()
    {
        foreach (var button in _garageButtons)
        {
            button.SetActive(false);
        }
    }
}
