using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class test : MonoBehaviour
{
    public Transform trackingSpace;
	public sceneMaker scene;
    public int currentPlatform = 0;

    private void Start()
    {


    }

    private void Update()
    {
        bool state = SteamVR_Input.GetStateDown("InteractUI", SteamVR_Input_Sources.Any);
        if (state)
        {
            trackingSpace.position = scene.listP[0].position;
            scene.listP.RemoveAt(0);

        }
    }

    private IEnumerator teleportToNextPlatform()
    {
        while (scene.listP.Count != 0)
        {
            bool state = SteamVR_Input.GetState("InteractUI", SteamVR_Input_Sources.Any);
            if (state)
            {
                trackingSpace.position = scene.listP[0].position;
                scene.listP.RemoveAt(0);
                yield return new WaitForSeconds(2.0f);
            }
        } 
    }

}
