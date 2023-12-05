using System.Collections;
using UnityEngine;

public class Nikita : SampleScript
{
    [SerializeField]
    public float rotationSpeed = 1f;
    [SerializeField]
    public Vector3 targetRotation;

    [ContextMenu("start")]
    public override void Use()
    {
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotationQuaternion = Quaternion.Euler(targetRotation);
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime / (rotationSpeed * 9);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotationQuaternion, t);
            yield return null;
        }
    }
}
