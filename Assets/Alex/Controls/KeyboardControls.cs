using UnityEngine;
using System.Collections;

public class KeyboardControls : MonoBehaviour {
	
	public float force = 1f;
	
	public KeyCode[] keycodes = {KeyCode.W, KeyCode.S,KeyCode.A, KeyCode.D};
	public KeyCode[] altKeycodes = {KeyCode.UpArrow, KeyCode.DownArrow,KeyCode.LeftArrow, KeyCode.RightArrow};
	protected bool[] keys = new bool[4];
	protected bool[] altKeys = new bool[4];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = 0f, z = 0f;
		for(int i=0; i<4; ++i){
			if(Input.GetKeyDown (keycodes[i])){
				keys[i] = true;	
			} else if(Input.GetKeyUp (keycodes[i])){
				keys[i] = false;	
			}
			if(Input.GetKeyDown (altKeycodes[i])){
				altKeys[i] = true;	
			} else if(Input.GetKeyUp (altKeycodes[i])){
				altKeys[i] = false;	
			}
		}
		if(keys[0] || altKeys[0]){
			z += 1.0f;
		}
		if(keys[1] || altKeys[1]){
			z -= 1.0f;
		}
		if(keys[2] || altKeys[2]){
			x -= 1.0f;
		}
		if(keys[3] || altKeys[3]){
			x += 1.0f;
		}
		
		float total = Mathf.Abs (x) + Mathf.Abs (z);
		if(total > 0){
			total = Mathf.Sqrt(total);
			x /= total;
			z /= total;
			
			this.transform.rigidbody.velocity += new Vector3(x * force, 0f, z * force);
		}
	}
}
