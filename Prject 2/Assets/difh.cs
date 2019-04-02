using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difh : MonoBehaviour
{
    public sceneMaker scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hand")
        {
            scene.itemDB.dificulty = "Difficulty assessment: High";
        }
    }
}