using System;
using System.Collections.Generic;
using UnityEngine;

public class RowCollector : MonoBehaviour
{

	public GameObject ColorController;
	public GameObject DriveController;

	EngineColor engColor;
	GasColor gasColor;
	TireColor tireColor;
	DriveWheels wheelSpeed;

	ExcelReader reader;

	public int playSpeed = 60;
	public float rev_per_sec = 8000;

	int frame = 0;
	int listIndex = 0;

	float engSpeedValue;
	float fuelConsumValue;
	float vehicleSpeed;
	float wheelRotation;

	float normalized_engSpeed;
	float normalized_fuelConsum;
	float normalized_wheelSpeed;
	float normalized_wheelRotation;

	string engValue;
	string gasValue;
	string speedValue;
	string rotationValue;

	List<Dictionary<string, string>> allRows;


	public RowCollector ()
	{
		
	}

	void Start(){
		reader = new ExcelReader("car_data.csv");
		allRows = reader.getAllRows();

		engColor = ColorController.GetComponent<EngineColor> ();
		gasColor = ColorController.GetComponent<GasColor> ();
		wheelSpeed = DriveController.GetComponent<DriveWheels> ();
		tireColor = ColorController.GetComponent<TireColor> ();


		/*
		foreach (Dictionary<string, string> row in allRows) {
			foreach (KeyValuePair<string, string> entry in row) {
				Debug.Log (entry.Key + "->" + entry.Value);
			}
			Debug.Log ("\n");
		}
		*/
	}

	void Update(){
		if (frame == playSpeed) {
			engValue = (allRows[listIndex])["Engine_Speed"];
			if (engValue.Equals ("")) {
				engValue = "0";
			}
			engSpeedValue = float.Parse (engValue);
			normalized_engSpeed = (engSpeedValue / 6500f);
			engColor.setColorValue (normalized_engSpeed);

			gasValue = (allRows [listIndex]) ["Fuel_Consum"];
			if (gasValue.Equals ("")) {
				gasValue = "0";
			}
			fuelConsumValue = float.Parse (gasValue);
			normalized_fuelConsum = (fuelConsumValue / 8.5f);
			gasColor.setColorValue (normalized_fuelConsum);

			speedValue = (allRows [listIndex]) ["Vehicle_Speed"];
			if (speedValue.Equals ("")) {
				speedValue = "0";
			}
			vehicleSpeed = float.Parse (speedValue);
			wheelSpeed.setWheelSpeed (vehicleSpeed);

			rotationValue = (allRows [listIndex]) ["Streering_Angle_Degree"];
			if (rotationValue.Equals ("")) {
				rotationValue = "0";
			}
			wheelRotation = float.Parse (rotationValue);
			normalized_wheelRotation = wheelRotation / 10.0f;
			wheelSpeed.setWheelRotation (normalized_wheelRotation);

			normalized_wheelSpeed = (vehicleSpeed / 100);
			tireColor.setColorValue (normalized_wheelSpeed);

			frame = 0;
			Debug.Log (normalized_wheelRotation + " Row:" + (listIndex + 2));
			listIndex++;
		}
		frame++;
	}
}

