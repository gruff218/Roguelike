using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Vector3[] temp;
    public Camera camera;
    public float vel;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Equals))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 3, vel);
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 10, vel);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 3, vel*10);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, 10, vel*10);
        }
    }
}
