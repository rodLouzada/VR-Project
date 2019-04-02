using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ne : MonoBehaviour
{
    // Start is called before the first frame update
    public sceneMaker scene;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "hand")
        {
            scene.itemDB.nausea = "Nausea assessment: Low";
        }
    }
}

