using System.Collections.Generic;
using UnityEngine;

public class UseAll : MonoBehaviour
{
    public List<SampleScript> Scripts;

    public void UseAllScripts()
    {
        foreach (SampleScript script in Scripts)
        {
            script.Use();
        }
    }
}
