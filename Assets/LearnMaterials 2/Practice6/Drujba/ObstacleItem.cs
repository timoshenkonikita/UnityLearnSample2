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


    [ContextMenu("Damage")]
    public void Damage()
    {
        GetDamage(0.1f);
    }


    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp01(currentValue); // Убедимся, что currentValue находится в диапазоне от 0 до 1

        UpdateColor();

        if (currentValue <= 0 && !isDestroyed)
        {
            isDestroyed = true;
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }
    }
    private void UpdateColor()
    {
        Color targetColor = Color.Lerp(Color.red, Color.white, currentValue); // Используем плавный переход цвета

        if (obstacleRenderer != null)
        {
            obstacleRenderer.material.color = targetColor;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}


