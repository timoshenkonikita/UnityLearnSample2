using System.Collections;
using UnityEngine;

public class Nikita : SampleScript
{
    public float rotationSpeed = 10.0f;
    public Vector3 targetRotation = new Vector3(90.0f, 90.0f, 90.0f);

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
            t += Time.deltaTime / (rotationSpeed * 9); // 9 секунд для 90 градусов при данной скорости
            transform.rotation = Quaternion.Lerp(startRotation, targetRotationQuaternion, t);
            yield return null;
        }
    }
}
