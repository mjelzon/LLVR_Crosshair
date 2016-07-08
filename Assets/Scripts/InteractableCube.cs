using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Renderer))]
public class InteractableCube : MonoBehaviour, IInteractable {

    [SerializeField]
    Material gazeEnter;

    [SerializeField]
    Material onMouseDown;

    private Renderer myRenderer;
    private Material defaultMaterial;

    public void OnGazeEnter()
    {
        myRenderer.material = gazeEnter;
    }

    public void OnGazeLeave()
    {
        myRenderer.material = defaultMaterial;
    }

    public void OnGazeStay()
    {
        Debug.Log("GazeStay");
    }

    public void OnMouseDown()
    {
        myRenderer.material = onMouseDown;
    }

    public void OnMouseUp()
    {
        myRenderer.material = gazeEnter;
    }

    // Use this for initialization
    void Start ()
    {
        myRenderer = GetComponent<Renderer>();
        defaultMaterial = myRenderer.material;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
