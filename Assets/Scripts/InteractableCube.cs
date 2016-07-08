using UnityEngine;
using System.Collections;
using System;

public class InteractableCube : MonoBehaviour, IInteractable {

    [SerializeField]
    Material gazeEnter;

    public void OnGazeEnter()
    {
        Debug.Log("GazeEnter");
    }

    public void OnGazeLeave()
    {
        Debug.Log("GazeLeave");
    }

    public void OnGazeStay()
    {
        Debug.Log("GazeStay");
    }

    public void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
    }

    public void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
