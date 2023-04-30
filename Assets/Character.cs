using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    [SerializeField, Range(0, 1)] float moveDuration = 0.1f;
    [SerializeField, Range(0, 1)] float jumpHeight = 0.5f;

    void Update()
    {

        if (DOTween.IsTweening(transform))
            return;

        Vector3 direction = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }

        if (direction == Vector3.zero)
            return;

        Move(direction);

    }

    public void Move(Vector3 direction)
    {
        transform.DOMoveZ(transform.position.z + direction.z, moveDuration);
        transform.DOMoveX(transform.position.x + direction.x, moveDuration);
    
        var seq = DOTween.Sequence();
        seq.Append(transform.DOMoveY(jumpHeight, moveDuration * 0.5f));
        seq.Append(transform.DOMoveY(0, moveDuration * 0.5f));

    }
}
