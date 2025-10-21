using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _damping;
    [SerializeField] private float cameraUpperLimit;
    [SerializeField] private float cameraLowerLimit;
    [SerializeField] private float cameraLeftLimit;
    [SerializeField] private float cameraRightLimit;
    public Transform target;

    private Vector3 vel = Vector3.zero;

    private void Start()
    {
        //cameraUpperLimit = cam.
    }
    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + _offset;
        targetPosition.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref vel, _damping);
        // if at the edge of the map(wall) stop moving
        float clampedX = Mathf.Clamp(transform.position.x, cameraLeftLimit, cameraRightLimit);
        float clampedY = Mathf.Clamp(transform.position.y, cameraLowerLimit, cameraUpperLimit);
        transform.position = new Vector3(clampedX, clampedY, transform.position.z);

    }
}