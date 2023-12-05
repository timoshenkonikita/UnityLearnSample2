using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class RomanScript : SampleScript
{


    private Transform target;
    
    private int childs;
    private const float _Time = 3;


    private void Start()
    {
        target = transform;
        childs = target.childCount;

    }

    [ContextMenu("Удалить")]
    public override void Use()
    {
        StartCoroutine(DeleteCoroutine());
    }

    private IEnumerator DeleteCoroutine()
    {
        //transform.localScale /= 2;
        
        for (int i = childs - 1; i >= 0; i--)
        {
            for (float j = 0; j < _Time; j += Time.deltaTime)
            {
                target.GetChild(i).localScale /= 1.002f;
                yield return null;

            }
            GameObject child = target.GetChild(i).gameObject;
            Destroy(child);
        }


        //Destroy(gameObject, Time.deltaTime);
        //Destroy(transform);
    }
    
}


