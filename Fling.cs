using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fling : MonoBehaviour {

    public Rigidbody2D rb;

    private float releaseTime = 0.1f;

    private Vector3 dragStart;
    private Vector3 dragEnd;
    private Vector3 direction;

    private bool isThrown = false;

    void Update()
    {
        if (isThrown)
        {
            rb.AddForce(direction / 2);
        }
    }

    void OnMouseDown()
    {
        rb.isKinematic = true;
        dragStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        StartCoroutine(Release());
    }

    void OnMouseUp()
    {
        if (!isThrown)
        {
            rb.isKinematic = false;
            isThrown = true;
            dragEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = dragEnd - dragStart;
            direction.Normalize();
        }
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        OnMouseUp();
    }

}