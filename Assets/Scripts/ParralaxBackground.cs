using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParralaxBackground : MonoBehaviour
{
    private GameObject cam;
    [SerializeField] private float parralaxEffect;
    private float xPosition;
    private float yPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponentInChildren<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
        yPosition = transform.position.y;
    }

    void Update()
    {
        float distanceMoved = cam.transform.position.x * (1 - parralaxEffect);
        float distanceToMove = cam.transform.position.x * parralaxEffect;
        float distanceToMoveY = cam.transform.position.y;
        transform.position = new Vector3(xPosition + distanceToMove, yPosition + (distanceToMoveY + 3f ) / 7.0f);

        if (distanceMoved > xPosition + length)
        {
            xPosition += length;
        }
        else if (xPosition - length > distanceMoved)
        {
            xPosition -= length;
        }
    }
}
