using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private PlayerStats _playerStats;

    private void Update()
    {
        _moneyText.text = _playerStats.GetMoney().ToString();
    }
}
