using UnityEngine;
using System.Collections;

public class WorldSpaceCrosshair : MonoBehaviour {

    [SerializeField]
    Sprite crosshair;

    [SerializeField]
    Camera targetCamera;

    [SerializeField]
    float cursorDistance = 5f;

    [SerializeField]
    bool dynamic = false;

	// Use this for initialization
	void Start ()
    {
        DrawFixed();
	}

    void Update ()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(targetCamera.transform.position, targetCamera.transform.forward), out hit))
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
        else
        {
            HandleInteraction(null);
            DrawFixed();
        }

        FaceCamera();
    }

    private void DrawFixed()
    {
        transform.position = targetCamera.transform.position + targetCamera.transform.forward * cursorDistance;
    }

    private void FaceCamera()
    {
        transform.LookAt(targetCamera.transform);
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
                lastInteractable.OnGazeLeave();
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

        lastInteractable = interactable;

        
    }

}
