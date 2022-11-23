using UnityEngine;

namespace AdditionalScripts
{
    public interface ICarFactory
    {
        PlayerCar CreatePlayerCar(Transform at, Transform container);
        EnemyCar[] CreateEnemyCars(int amount);
    }
}