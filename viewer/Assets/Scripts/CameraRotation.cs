using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {
    public float rotatesens = 2.0f;
    float Range = 60.0f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Camera.main.fieldOfView>3.0f && Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Camera.main.fieldOfView -= 1.0f;
        }
        if (Camera.main.fieldOfView < 50.0f && Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            Camera.main.fieldOfView += 1.0f;
        }
        float roty = Input.GetAxis("Mouse X") * rotatesens;
        float rotx  = -Input.GetAxis("Mouse Y") * rotatesens;
        if (Input.GetKey("mouse 1")) Camera.main.transform.Rotate(rotx, roty, 0);
        if (Input.GetKey("[5]")) Camera.main.transform.localRotation=Quaternion.Euler(0f,0f,0f);

    }
}
