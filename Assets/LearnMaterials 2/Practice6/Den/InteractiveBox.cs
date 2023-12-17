using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox _next = null;
    private Transform myTransform;
    private Transform target;
    [SerializeField]
    private LayerMask rayMask;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
        myTransform.tag = "InteractiveBox";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 ray = myTransform.forward * rayDistance;
        
        //Debug.DrawRay(myTransform.position, ray, Color.red, 0.3f);
    }

    public void AddNext(InteractiveBox box)
    {
        _next = box;
        StartCoroutine(RayCoroutine(_next));
    }

    
    private IEnumerator RayCoroutine(InteractiveBox next)
    {
        _next = next;
        target = _next.transform;
        while (_next != null)
        {
            if (Physics.Linecast(myTransform.position, target.position, out RaycastHit hit, rayMask))
            {
                Debug.DrawLine(myTransform.position, hit.point, Color.red, 0.1f);
                if (hit.collider.gameObject.CompareTag("ObstacleItem"))
                {
                    Debug.Log("ObstacleItem");
                    ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                    obstacle.Damage();
                }
                yield return null;
            }
        }
        

    }
}
