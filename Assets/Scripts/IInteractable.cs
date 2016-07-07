using UnityEngine;
using System.Collections;

public interface IInteractable
{
    void OnGazeEnter();
    void OnGazeLeave();
    void OnGazeStay();
    void OnMouseDown();
    void OnMouseUp();
}
