using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int _startMoney = 300;

    private int _money;


    public int GetMoney()
    {
        return _money;
    }

    public void BuyCar2(int price)
    {
        Debug.Log(_startMoney);
        _money -= price;
    }
    private void Start()
    {
        _money = _startMoney;
    }
}
