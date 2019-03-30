using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
	public GameObject teleporterPointPrefab;
	public OVRInput.Controller myController;
	PickupObject currentAttachment = null;
	public float pickUpTriggerThreshold;
	public float releaseTriggerThreshold;
	public bool dissappearOnPickup;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerStay(Collider c) {
		Rigidbody rb = c.attachedRigidbody;

		if(rb == null) {
			return;
		}
		
		PickupObject p = rb.GetComponent<PickupObject>();
		
		if(p == null) {
			return;
		}
		
		float triggerValue;
        triggerValue = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);
		
		if(currentAttachment == null && triggerValue > pickUpTriggerThreshold) {
			currentAttachment = p;
            currentAttachment.pickedUp(this.transform);
            if (dissappearOnPickup) {
				MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer m in meshRenderers) {
					m.enabled = false;
				}
			}
		}
		
		if(currentAttachment != null && triggerValue < releaseTriggerThreshold) {
			currentAttachment.released(this.transform, OVRInput.GetLocalControllerVelocity(myController));
			currentAttachment = null;
			if(dissappearOnPickup) {
				MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
				foreach(MeshRenderer m in meshRenderers) {
					m.enabled = true;
				}
			}
		}
	}
}
