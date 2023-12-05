using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Den_Moving_Object : SampleScript
{
    [SerializeField]
    [Min(0)]
    private float Speed;
    [SerializeField]
    private Vector3 movingPosition;

    private Transform movingTransform;

    private void Awake()
    {
        movingTransform = transform;
    }

    [ContextMenu("Test")]
    public override void Use()
    {
        StartCoroutine(MovingObjectCoroutine());
    }

    private IEnumerator MovingObjectCoroutine()
    {
        while(transform.localPosition != movingPosition)
        {
            movingTransform.position = Vector3.MoveTowards(movingTransform.position, movingPosition, Time.deltaTime*Speed);
            yield return null;
        }

    }
}
