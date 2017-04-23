using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveWheels : MonoBehaviour {

	public GameObject wheel0;
	public GameObject wheel1;
	public GameObject wheel2;
	public GameObject wheel3;

	public float Speed = 0.0f;
	public float wRotation = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		wheel0.transform.Rotate (Speed, 0.0f, 0.0f);
		wheel1.transform.Rotate (Speed, 0.0f, 0.0f);
		wheel2.transform.Rotate (Speed, 0.0f, 0.0f);
		wheel3.transform.Rotate (Speed, 0.0f, 0.0f);

	//	wheel0.transform.Rotate (0.0f, wRotation, 0.0f); 
	//	wheel1.transform.Rotate (0.0f, wRotation, 0.0f);




	}

	public void setWheelSpeed(float val)
	{
		this.Speed = val;
		//engine00.GetComponent<Renderer>().material.SetColor("_Color", HSBColor.ToColor(Mathf.PingPong(Time.time * Speed, 1),1,1)));
	}

	public void setWheelRotation(float val)
	{
		wheel0.transform.localRotation = Quaternion.Euler(wheel0.transform.localRotation.x,val,wheel0.transform.localRotation.z); 
		wheel1.transform.localRotation = Quaternion.Euler(wheel1.transform.localRotation.x,val,wheel1.transform.localRotation.z); 
	}
}
