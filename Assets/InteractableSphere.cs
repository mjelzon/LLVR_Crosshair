using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(AudioSource))]
public class InteractableSphere : MonoBehaviour, IInteractable {

    [SerializeField]
    float growSpeed;

    [SerializeField]
    Vector3 targetScale;

    [SerializeField]
    AudioClip popSound;

    private AudioSource audioSource;
    private Vector3 defaultScale;
    private bool isPopped;

    public void OnGazeEnter()
    {
        if (!isPopped)
        {
            StopAllCoroutines();
            StartCoroutine(Grow());
        }
        
    }

    public void OnGazeLeave()
    {
        if (!isPopped)
        {
            StopAllCoroutines();
            StartCoroutine(Shrink());
        }
        
    }

    public void OnGazeStay()
    {
    }

    public void OnMouseDown()
    {
        if (!isPopped)
        {
            isPopped = true;
            audioSource.PlayOneShot(popSound);
            enabled = false;

            StopAllCoroutines();
            StartCoroutine(Respawn());
        }
    }

    public void OnMouseUp()
    {
    }

    // Use this for initialization
    void Start ()
    {
        defaultScale = transform.localScale;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator Grow()
    {
        while(transform.localScale.magnitude < targetScale.magnitude)
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Shrink()
    {
        while(transform.localScale.magnitude > defaultScale.magnitude)
        {
            transform.localScale -= Vector3.one * growSpeed * Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator Respawn()
    {
        transform.localScale = Vector3.zero;

        enabled = true;

        yield return new WaitForSeconds(3);

        while(transform.localScale.magnitude < defaultScale.magnitude)
        {
            transform.localScale += Vector3.one * growSpeed * Time.deltaTime;
            yield return null;
        }

        isPopped = false;
    }
}
