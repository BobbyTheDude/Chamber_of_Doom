using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform FollowTransform;
    private Vector3 SmoothPos;
    private float SmoothSpeed = 0.5f;

    public GameObject CameraLeftBorder;
    public GameObject CameraRightBorder;

    private float CameraHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        CameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float BorderLeft = CameraLeftBorder.transform.position.x + CameraHalfWidth;
        float BorderRight = CameraRightBorder.transform.position.x - CameraHalfWidth;

        SmoothPos = Vector3.Lerp(this.transform.position,
            new Vector3(Mathf.Clamp(FollowTransform.position.x, BorderLeft, BorderRight),
            this.transform.position.y,
            this.transform.position.z), SmoothSpeed);
        this.transform.position = SmoothPos;
    }
}
