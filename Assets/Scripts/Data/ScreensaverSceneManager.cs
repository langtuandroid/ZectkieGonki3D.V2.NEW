using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensaverSceneManager : MonoBehaviour
{
    [SerializeField] private bool _isRemoveDataOnStart = false;
    [SerializeField] private Data _data;
    [SerializeField] private GameObject _musicPlayer;

    public void StartGame()
    {
        if (_isRemoveDataOnStart)
            _data.RemoveData();

        DontDestroyOnLoad(_musicPlayer);

        CheckSaveFile();
        _data.AddSession();
        _data.SetLastLoginDate(DateTime.Now);
        _data.Save();
        SceneManager.LoadScene(_data.GetLevelIndex());
    }

    private void CheckSaveFile()
    {
        if (PlayerPrefs.HasKey(_data.GetKeyName()))
        {
            _data.Load();
        }
        else
        {
            _data.Save();
            _data.SetLevelIndex(1);
            _data.SetDateRegistration(DateTime.Now);
        }
    }
}
