using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pressed : MonoBehaviour
{
    public int timer;
    public Text txtTimer;
    public bool psd;
    
    void Start()
    {
        psd = false;
        txtTimer.text = "Timer: " + timer;
        //StartCoroutine(WaitAndPrint());

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "btn")
        {
            psd = true;

            StartCoroutine(WaitAndPrint());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "btn")
        {
            psd = false;
            StopCoroutine(WaitAndPrint());
         }
    }

    private IEnumerator WaitAndPrint()
    {
        while (psd)
        {
            yield return new WaitForSeconds(1.0f);
            if (timer > 0)
            {
                txtTimer.text = "Time: " + (timer--);
            }
            
        }
    }
}
