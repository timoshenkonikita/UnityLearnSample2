using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScriptROMACHA : MonoBehaviour
{
    public GameObject prefab;
    [SerializeField]
    public int numberOfCopies;
    public float stepDistance = 2.0f;

    [ContextMenu("Test")]
    public void Use()
    {
        Vector3 startPosition = transform.position;

        for (int i = 1; i <= numberOfCopies; i++)
        {
            Vector3 spawnPosition = startPosition + transform.forward * i * stepDistance;

            Instantiate(prefab, spawnPosition, Quaternion.identity);

        }
    }

}

