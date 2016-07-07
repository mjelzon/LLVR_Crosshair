using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

    [SerializeField]
    float speed;

    private float mouseX;
    private float mouseY;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, mouseX * speed * Time.deltaTime, Space.World);
        transform.Rotate(transform.right, -mouseY * speed * Time.deltaTime, Space.World);
    }
}
