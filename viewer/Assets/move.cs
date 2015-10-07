using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    public float rotatesens = 2.0f;
    public Vector3 enl = new Vector3(0.03f, 0.03f, 0.03f);
    public Vector3 enlx = new Vector3(0.001f, 0, 0);
    public Vector3 enly = new Vector3(0, 0.001f, 0);
    public Vector3 enlz = new Vector3(0, 0, 0.001f);
    public Vector3 standart = new Vector3(0, 0, 0);
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float rot = Input.GetAxis("Mouse X") * rotatesens;
        float upSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");
        if(transform.localScale.x > 0.11f && Input.GetAxis("Mouse ScrollWheel") >0){
            transform.localScale-=enl;
        }
        if (transform.localScale.x<0.99f&&Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.localScale += enl;
        }


        transform.Rotate(upSpeed, sideSpeed, 0);
        if(Input.GetKey("mouse 0")) transform.Rotate(0, 0, rot);
        if (transform.localPosition.z < 0.03f && Input.GetKey("[8]")) transform.localPosition += enlz;
        if (transform.localPosition.z > -0.03f && Input.GetKey("[2]")) transform.localPosition -= enlz;
        if (transform.localPosition.x < 0.03f && Input.GetKey("[4]")) transform.localPosition += enlx;
        if (transform.localPosition.x > -0.03f && Input.GetKey("[6]")) transform.localPosition -= enlx;
        if (transform.localPosition.y < 0.03f && Input.GetKey("[7]")) transform.localPosition += enly;
        if (transform.localPosition.y > -0.03f && Input.GetKey("[9]")) transform.localPosition -= enly;
        if (Input.GetKeyDown("[5]")) transform.localPosition = standart;

    }
}
