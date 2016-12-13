/* Code derived from Alexander Ameye's DOOR SCRIPT file: "Door.cs" (v1.0.3 - 10/19/2016) */

using UnityEngine;
using System.Collections;
using UnityEditor;

public class SlidingDoorScript : MonoBehaviour {

	// INSPECTOR SETTINGS
	[Header("Sliding Door Settings")]
	[Tooltip("The intial position of the door/window. (Relative to current location of self in Scene)")]
	public float InitialPosition = 0.0f;
	[Tooltip("The number of [undefined] units the door/window translates.")]
	public float TranslatedPosition = 90.0f;

	public enum PositionOfHinge {
		Left,
		Right,
	}
	public PositionOfHinge HingePosition;

	public enum SideOfTranslation {
		Left,
		Right,
	}
	public SideOfTranslation TranslationSide;

	[Tooltip("Translation speed of the door/window.")]
	public float TranslationSpeed = 3f;
	[Tooltip("0 = infintie times")]
	public int TimesMoveable = 0;

	// PRIVATE SETTINGS
	private int n = 0; // for "TimesMoveable" loop
	[HideInInspector] public bool Running = false;

	// DEBUGGING
	[Header("Debug Settings")]
	[Tooltip("Visualises the position of the hinge in-game by a coloured cube.")]
	public bool VisualiseHinge = false;
	[Tooltip("The visualisation colour of the hinge.")]
	public Color HingeColour = Color.cyan;

//	// Defines intial and final translation points

//Define an initial and final rotation.
//	private Quaternion FinalRot, InitialRot;
//	private int State;

	// Creates a hinge
	GameObject hinge;

	// START FUNCTION (used for initialization)
	void Start () {
		// Gives object the name "Door" for future reference
		gameObject.tag = "Door";

		// Creates hinge
		hinge = new GameObject();
		hinge.name = "hinge";

		//Calculate sine/cosine of initial angle (needed for hinge positioning).
		float CosDeg = Mathf.Cos ((transform.eulerAngles.y * Mathf.PI) / 180);
		float SinDeg = Mathf.Sin ((transform.eulerAngles.y * Mathf.PI) / 180);

		// Reads transform (position/rotation/scale) of the door
		float DoorPositX = transform.position.x;
		float DoorPositY = transform.position.y;
		float DoorPositZ = transform.position.z;

		float DoorRotateX = transform.position.x;
//		float DoorRotateY = transform.position.y;
		float DoorRotateZ = transform.position.z;

		float DoorScaleX = transform.localScale.x;
//		float DoorScaleY = transform.localScale.y;
		float DoorScaleZ = transform.localScale.z;

		// Creates a placeholder of the hinge's position/rotation
		Vector3 HingePositCopy = hinge.transform.position;
		Vector3 HingeRotateCopy = hinge.transform.localEulerAngles;

		// HINGE LEFT
		if (HingePosition == PositionOfHinge.Left)
		{
			// CALCULATE
			if (transform.localScale.x > transform.localScale.z)
			{
				HingePositCopy.x = (DoorPositX - (DoorScaleX / 2 * CosDeg));
				HingePositCopy.z = (DoorPositZ + (DoorScaleX / 2 * SinDeg));
				HingePositCopy.y = DoorPositY;
		//*TODO*
				HingeRotateCopy.x = DoorRotateX;
				HingeRotateCopy.y = -InitialPosition;
				HingeRotateCopy.z = DoorRotateZ;
			} else {
				HingePositCopy.x = (DoorPositX + (DoorScaleZ / 2 * SinDeg));
				HingePositCopy.z = (DoorPositZ + (DoorScaleZ / 2 * CosDeg));
				HingePositCopy.y = DoorPositY;
		//*TODO*
				HingeRotateCopy.x = DoorRotateX;
				HingeRotateCopy.y = -InitialPosition;
				HingeRotateCopy.z = DoorRotateZ;
			}
		}

		// HINGE RIGHT
		if (HingePosition == PositionOfHinge.Right)
		{
			// CALCULATE
			if (transform.localScale.x > transform.localScale.z)
			{
				HingePositCopy.x = (DoorPositX + (DoorScaleX / 2 * CosDeg));
				HingePositCopy.z = (DoorPositZ - (DoorScaleX / 2 * SinDeg));
				HingePositCopy.y = DoorPositY;
		//*TODO*
				HingeRotateCopy.x = DoorRotateX;
				HingeRotateCopy.y = -InitialPosition;
				HingeRotateCopy.z = DoorRotateZ;
			} else {
				HingePositCopy.x = (DoorPositX - (DoorScaleZ / 2 * SinDeg));
				HingePositCopy.z = (DoorPositZ - (DoorScaleZ / 2 * CosDeg));
				HingePositCopy.y = DoorPositY;
		//*TODO*
				HingeRotateCopy.x = DoorRotateX;
				HingeRotateCopy.y = -InitialPosition;
				HingeRotateCopy.z = DoorRotateZ;
			}
		}

		// HINGE POSITIONING
		hinge.transform.position = HingePositCopy;
		transform.parent = hinge.transform;
		hinge.transform.localEulerAngles = HingeRotateCopy;

		// DEBUGGING
		if (VisualiseHinge == true) {
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = HingePositCopy;
			cube.transform.localScale = new Vector3 (0.25f, 0.5f, 0.25f);
			cube.GetComponent<Renderer> ().material.color = HingeColour;
		}

		// ERROR CODE	* Has TODO with RotationAngles *
		if (Mathf.Abs (InitialPosition) + Mathf.Abs (TranslatedPosition) == 180 
			|| Mathf.Abs (InitialPosition) + Mathf.Abs (TranslatedPosition) > 180) 
		{
			UnityEditor.EditorUtility.DisplayDialog ("Error 001", "The difference between 'Initial Position' " 
				+ "and 'Translated Position' cannot exceed or be equal to 180 degrees.", "OK", "");
			UnityEditor.EditorApplication.isPlaying = false;
		}

//		// ANGLES
//		if (RotationSide == SideOfRotation.Left)
//		{
//			InitialRot = Quaternion.Euler (0, -InitialAngle, 0);
//			FinalRot = Quaternion.Euler(0, -InitialAngle - RotationAngle, 0);
//		}
//
//		if (RotationSide == SideOfRotation.Right)
//		{
//			InitialRot = Quaternion.Euler (0, -InitialAngle, 0);
//			FinalRot = Quaternion.Euler(0, -InitialAngle + RotationAngle, 0);
//		}

	}

	// UPDATE FUNCTION (called once per frame)
	void Update () {}

//	// OPEN FUNCTION
//	public IEnumerator Open ()
//    {
//		if (n < TimesMoveable || TimesMoveable == 0)
//		{
//			//Change state from 1 to 0 and back (= alternate between FinalRot and InitialRot).
//			if (hinge.transform.rotation == (State == 0 ? FinalRot : InitialRot)) State ^= 1;
//
//			//Set 'FinalRotation' to 'FinalRot' when moving and to 'InitialRot' when moving back.
//			Quaternion FinalRotation = ((State == 0) ? FinalRot : InitialRot);
//
//			//Make the door/window rotate until it is fully opened/closed.
//			while (Mathf.Abs(Quaternion.Angle(FinalRotation, hinge.transform.rotation)) > 0.01f)
//			{
//				Running = true;
//				hinge.transform.rotation = Quaternion.Lerp (hinge.transform.rotation, FinalRotation, Time.deltaTime * Speed);
//				yield return new WaitForEndOfFrame();
//			}
//			Running = false;
//
//			if (TimesMoveable == 0) n = 0;
//			else n++;
//		}
//	}

	// GUI FUNCTION
	void OnGUI () {
		// Accesses the 'InReach' variable from raycasting script
		GameObject Player = GameObject.Find("Player");
		Detection detection = Player.GetComponent<Detection> ();

		if (detection.InReach == true) {
			GUI.color = Color.white;
			GUI.Box (new Rect (20, 20, 200, 25), "Press 'E' to Open/Close the Door");
		}
	}
}