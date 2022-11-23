using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    [SerializeField] private Transform _playerCar;

    private void LateUpdate()
    {
        Vector3 newPosition = _playerCar.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90, _playerCar.eulerAngles.y, 0f);
    }
}
