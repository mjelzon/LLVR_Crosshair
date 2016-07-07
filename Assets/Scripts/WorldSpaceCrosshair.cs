using UnityEngine;
using System.Collections;

public class WorldSpaceCrosshair : MonoBehaviour {

    [SerializeField]
    Sprite crosshair;

    [SerializeField]
    Camera camera;

    [SerializeField]
    float cursorDistance = 5f;

    [SerializeField]
    bool dynamic = false;

	// Use this for initialization
	void Start ()
    {

	}

    void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(camera.transform.position, camera.transform.forward), out hit))
        {
            //check if collision has IInteractable
            IInteractable interactable =
                hit.transform.root.GetComponentInChildren(typeof(IInteractable)) as IInteractable;

            HandleInteraction(interactable);

            if (dynamic)
            {
                if(interactable != null)
                {
                    transform.position = hit.point;
                }
                else { DrawFixed(); }
            }
            else
            {
                DrawFixed();
            }
        }

        FaceCamera();
    }

    private void DrawFixed()
    {
        transform.position = camera.transform.forward * cursorDistance;
    }

    private void FindInteractable()
    {
        
    }

    private void FaceCamera()
    {
        transform.LookAt(camera.transform);
    }

    private IInteractable lastInteractable = null;
    /// <summary>
    /// Control what IInteractable methods to call
    /// And handle input events
    /// </summary>
    private void HandleInteraction(IInteractable interactable)
    {
        if(interactable == null)
        {
            if(lastInteractable != null)
            {
                interactable.OnGazeLeave();
            }
        }
        else if(interactable != null)
        {
            if(lastInteractable != null)
            {
                interactable.OnGazeStay();
            }
            else if(lastInteractable == null)
            {
                interactable.OnGazeEnter();
            }

            if (Input.GetMouseButtonDown(0))
            {
                interactable.OnMouseDown();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                interactable.OnMouseUp();
            }
        }

        
    }

}
