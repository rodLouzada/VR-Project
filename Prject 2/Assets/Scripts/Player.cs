using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	public Transform head;
	
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.UpArrow)) {
		  Vector3 newFootPosition = head.position;
		  newFootPosition = newFootPosition + new Vector3(0,0,1);
		  teleport(newFootPosition, Vector3.zero);
	  }
    }
	
	public void teleport(Vector3 playerFeetWorldSpace, Vector3 playerDirectionWorldSpace) {
		Vector3 currFeetPosTrackingSpace = this.transform.worldToLocalMatrix.MultiplyPoint(head.position);
		currFeetPosTrackingSpace.y = 0;
		Vector3 currentFeetPosWorldSpace = this.transform.localToWorldMatrix.MultiplyPoint(currFeetPosTrackingSpace);
		
		Vector3 feetOffsetWorldSpace = playerFeetWorldSpace - currentFeetPosWorldSpace;
		this.transform.Translate(feetOffsetWorldSpace, Space.World);
		
	}
}
