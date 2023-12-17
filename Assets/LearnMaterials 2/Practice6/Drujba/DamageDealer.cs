using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 0.2f; // �������� �����, ������� �� ������ �������

    private void OnTriggerEnter(Collider other)
    {
        ObstacleItem obstacle = other.GetComponent<ObstacleItem>(); // �������� ������ � ������� ObstacleItem

        if (obstacle != null)
        {
            obstacle.GetDamage(damageAmount); // �������� ����� GetDamage � �����������
        }
    }
}