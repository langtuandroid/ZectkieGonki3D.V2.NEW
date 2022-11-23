using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingView : MonoBehaviour
{
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Button _settingButton;
    [SerializeField] private UIController _controller;

    private void OnClickSettingButton()
    {
        _controller.InvokeButtonClicked(_settingButton);
    }

    private void OnEnable()
    {
        _settingButton.onClick.AddListener(OnClickSettingButton);
        _controller.OnButtonClicked += HandleButtonClick;
        _controller.MainMenuShowStatusChanged += OnMenuStatusChanged;
    }

    private void OnDisable()
    {
        _settingButton.onClick.RemoveListener(OnClickSettingButton);
        _controller.OnButtonClicked -= HandleButtonClick;
        _controller.MainMenuShowStatusChanged -= OnMenuStatusChanged;
    }

    private void HandleButtonClick(Button button)
    {

        if (button != _settingButton)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void OnMenuStatusChanged(bool isShow)
    {
        _settingButton.gameObject.SetActive(isShow);
    }

    private void Show()
    {
        _settingPanel.SetActive(true);
    }

    private void Hide()
    {
        _settingPanel.SetActive(false);
    }
}
