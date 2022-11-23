using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] private GameObject _targetPointVeiw;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _pathSetting;
    [SerializeField] private Transform _pathLiaderboard;
    [SerializeField] private Transform _pathStartGame;
    [SerializeField] private Transform _path4;
    [SerializeField] private Transform _path5;
    [SerializeField] private Transform _path6;
    [SerializeField] private Transform _path7;
    [SerializeField] private Transform _path8;

    private Coroutine _rotateJob;

    private IEnumerator Coroutine(Vector3 targetPosition)
    {
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * _speed);
            transform.LookAt(_targetPointVeiw.transform);
            yield return null;
        }
    }

    public void MoveCamera(Transform transformTarget)
    {
        if (_rotateJob!=null)
        {
            StopCoroutine(_rotateJob);
        }

        _rotateJob = StartCoroutine(Coroutine(transformTarget.position));
    }

    //private void Update()
    //{
    //    transform.RotateAround(_targetPointVeiw.transform.position, _axis, _speed);
    //}


}
