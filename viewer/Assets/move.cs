using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    public float rotatesens = 2.0f;
    public Vector3 enl = new Vector3(0.01f, 0.01f, 0.01f);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rot = Input.GetAxis("Mouse X") * rotatesens;
        float upSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");
        if(transform.localScale.x > 0.11f&&Input.GetAxis("Mouse ScrollWheel") >0){
            transform.localScale-=enl;
        }
        if (transform.localScale.x<0.99f&&Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localScale += enl;
        }


        transform.Rotate(upSpeed, sideSpeed, rot);
        

	}
}
