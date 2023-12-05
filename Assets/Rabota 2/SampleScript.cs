using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SampleScript : MonoBehaviour
{
    private GameObject target;


    


    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        //GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        //foreach (GameObject obj in objects)
        //{
        //    Debug.Log(obj.name)
        //    //Destroy(target);
        //}
    }

    public abstract void Use();
}
