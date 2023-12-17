using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class InteractiveRaycast : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private Camera cam;
    [SerializeField]
    private InteractiveBox _interactiveBox;
    [SerializeField]
    private ObstacleItem obstacleItem;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("InteractivePlane") is true)
                {
                    Instantiate(prefab, hit.point, prefab.transform.rotation);
                }
                if(hit.collider.gameObject.CompareTag("InteractiveBox") is true)
                {
                    InteractiveBox clicked = hit.collider.GetComponent<InteractiveBox>();
                    if (!ReferenceEquals(clicked, _interactiveBox))
                    {
                        if (_interactiveBox is null)
                        {
                            _interactiveBox = clicked;
                        }
                        else
                        {
                            _interactiveBox.AddNext(clicked);
                        }
                    }
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("InteractiveBox") is true)
                {
                    Destroy(hit.collider.transform.parent.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(2))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                if (hit.collider.gameObject.CompareTag("InteractivePlane") is true)
                {
                    Instantiate(obstacleItem, hit.point, prefab.transform.rotation);
                }
            }
        }
    }
}
