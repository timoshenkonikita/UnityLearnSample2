using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    public float currentValue = 1.0f;
    public UnityEvent onDestroyObstacle;

    private Renderer obstacleRenderer;
    private bool isDestroyed = false;

    private void Start()
    {
        obstacleRenderer = GetComponent<Renderer>();
        UpdateColor();
    }

    public void Damage()
    {
        StartCoroutine(GetDamageCoroutine(0.001f));
    }

    private void UpdateColor()
    {
        Color targetColor = Color.Lerp(Color.red, Color.white, currentValue); // ���������� ������� ������� �����

        if (obstacleRenderer != null)
        {
            obstacleRenderer.material.color = targetColor;
        }
    }
    
   
    public IEnumerator GetDamageCoroutine(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue); // ��������, ��� currentValue ��������� � ��������� �� 0 �� 1

        UpdateColor();

        if (currentValue <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            onDestroyObstacle.Invoke();
            Destroy(transform.parent.gameObject);
        }
        yield return null;
    }
}


