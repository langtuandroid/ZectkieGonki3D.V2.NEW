using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRewardImage : MonoBehaviour
{
    [SerializeField] private GameObject _rewardView;

    public void CloseImage()
    {
        _rewardView.SetActive(false);
    }    
}
