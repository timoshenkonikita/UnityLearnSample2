using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 0.2f; // Значение урона, которое вы хотите нанести

    private void OnTriggerEnter(Collider other)
    {
        ObstacleItem obstacle = other.GetComponent<ObstacleItem>(); // Получаем доступ к скрипту ObstacleItem

        if (obstacle != null)
        {
            obstacle.GetDamage(damageAmount); // Вызываем метод GetDamage у препятствия
        }
    }
}