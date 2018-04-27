using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControleTouchScript : MonoBehaviour {

	public float velocidade;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		float mover_x = CrossPlatformInputManager.GetAxisRaw ("Horizontal") * velocidade * Time.deltaTime;
		float mover_y = CrossPlatformInputManager.GetAxisRaw ("Vertical") * velocidade * Time.deltaTime;

		print (mover_x);
		transform.Translate (new Vector3 (mover_x, mover_y));
	}
}
