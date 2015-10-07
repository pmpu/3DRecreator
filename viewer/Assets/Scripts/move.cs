using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    public float rotatesens = 2.0f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rot = Input.GetAxis("Mouse X") * rotatesens;
        float upSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");
        


        transform.Rotate(upSpeed, sideSpeed, 0);
        if(Input.GetKey("mouse 0")) transform.Rotate(0, 0, rot);

    }
}
