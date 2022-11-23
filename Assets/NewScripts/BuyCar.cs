using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCar : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private int _priceCar;
    //[SerializeField] private GameObject _upgradeUI;
    [SerializeField] private GameObject _priceUI;

    public void BuyThisCar(int _price)
    {
        Debug.Log(_price);
        _playerStats.BuyCar2(_price);
    }

    public void ShowUpgradeUI()
    {
        //_upgradeUI.SetActive(true);
       gameObject.SetActive(false);
        _priceUI.SetActive(false);

    }
}
