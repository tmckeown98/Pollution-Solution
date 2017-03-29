using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;

    private bool change = true;

    private int frames = 0;

    private float releaseTime = 1.0f;
    private float y = 1;

    Vector3 GetDirection()
    {
        Vector3 targetPos = target.position;
        Vector3 objPos = transform.position;

        Vector3 direction = targetPos - objPos;

        return direction.normalized;
    }

    Vector3 GetNormal(Vector3 v)
    {
        return new Vector3(-v.y, v.x);
    }

    void FixedUpdate()
    {
        frames++;
        Vector3 direction = GetDirection();
        Vector3 normal = GetNormal(direction);

        transform.Translate((direction) * Time.deltaTime);

        y = normal.y * Mathf.Sin(frames * (Mathf.PI / 180));
        transform.Translate(0, y * Time.deltaTime, 0);

        if (change)
        {
            StartCoroutine(ChangeDirection());
            change = false;
        }
    }

    IEnumerator ChangeDirection()
    {
        yield return new WaitForSeconds(releaseTime);
        y *= -1;
        change = true;
    }
}
