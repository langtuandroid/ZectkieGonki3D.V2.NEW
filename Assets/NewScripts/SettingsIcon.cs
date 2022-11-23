using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsIcon : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;

    public void ShowSettingMenu(bool state)
    {
        _settingsMenu.SetActive(state);
    }
 
    private void OnTriggerEnter(Collider collsion)
    {
        if (collsion.TryGetComponent<UIMenu>(out UIMenu uIMenu))
        {
            Debug.Log("Voshel!!!!");
            _settingsMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collsion)
    {
        if (collsion.TryGetComponent<UIMenu>(out UIMenu uIMenu))
        {
            Debug.Log("Vishel");
            _settingsMenu.SetActive(false);
        }
    }
}
