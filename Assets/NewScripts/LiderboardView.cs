using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiderboardView : MonoBehaviour
{
    [SerializeField] private GameObject _liderbordPanel;
    [SerializeField] private Button _liderbordButton;
    [SerializeField] private UIController _controller;

    private void OnClickLiderBoardButton()
    {
        _controller.InvokeButtonClicked(_liderbordButton);
    }

    private void OnEnable()
    {
        _liderbordButton.onClick.AddListener(OnClickLiderBoardButton);
        _controller.OnButtonClicked += HandleButtonClick;
        _controller.MainMenuShowStatusChanged += OnMenuStatusChanged;
    }

    private void OnDisable()
    {
        _liderbordButton.onClick.RemoveListener(OnClickLiderBoardButton);
        _controller.OnButtonClicked -= HandleButtonClick;
        _controller.MainMenuShowStatusChanged -= OnMenuStatusChanged;
    }

    private void HandleButtonClick(Button button)
    {
        if (button != _liderbordButton)
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
        _liderbordButton.gameObject.SetActive(isShow);
    }

    private void Show()
    {
        _liderbordPanel.SetActive(true);
    }

    private void Hide()
    {
        _liderbordPanel.SetActive(false);
    }
}
