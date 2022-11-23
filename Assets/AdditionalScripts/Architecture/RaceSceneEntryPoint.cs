using System;
using System.Collections;
using UnityEngine;

namespace AdditionalScripts
{
    public class RaceSceneEntryPoint : MonoBehaviour
    {
        [SerializeField] private Transform _startPoint;
        [SerializeField] private Transform _carContainer;
        [SerializeField] private ConfigContainer _configContainer;
        [SerializeField] private VehicleCamera _vehicleCamera;
        [SerializeField] private EnemyCar[] _enemyCars;

        private bool _isInitialized;
        private ICarFactory _carFactory;
        private PlayerCar _playerCar;

        private void Start()
        {
            ConfigProvider configProvider = new ConfigProvider(_configContainer);
            CarFactory carFactory = new CarFactory(configProvider);
            Initialize(carFactory);
        }

        private void Initialize(ICarFactory carFactory)
        {
            _carFactory = carFactory;
            _isInitialized = true;
            StartCoroutine(StartRace());
        }

        private IEnumerator StartRace()
        {
            _playerCar = _carFactory.CreatePlayerCar(_startPoint, _carContainer);
            _playerCar.Initialize();
            _vehicleCamera.Initialize(_playerCar.GetComponent<VehicleControl>());
            // _enemyCars = _carFactory.CreateEnemyCars();
            yield break;
        }
    }
}