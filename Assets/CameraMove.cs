using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform Player;

    Vector3 Offset_Pos;
    Vector3 Follow_Camera_Pos;
    Vector3 Zoom_Pos;

    bool CameraFix;

    [Range(1.0f,10.0f)]
    public float Zoom_Distance;
    float Zoom;

    [Range(1.0f,10.0f)]
    public float Zoom_Speed;

    // Start is called before the first frame update
    void Start()
    {
        Zoom = 0.0f;
        Player = GameObject.Find("Player").transform;
        CameraFix = false;
        Offset_Pos = transform.position;
        Follow_Camera_Pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            UnityEditor.EditorApplication.isPlaying = false;

        Cursor.lockState = CursorLockMode.Confined;

        if(Input.GetKeyDown(KeyCode.Y))
        {
            if (!CameraFix) CameraFix = true;
            else CameraFix = false;
        }

        if (Input.GetKey(KeyCode.Space)) CameraFix = true;

        else if (Input.GetKeyUp(KeyCode.Space)) CameraFix = false;

        float Z = Input.GetAxis("Mouse ScrollWheel") * Zoom_Speed;

        if (Z > 0.0f)
            Zoom = Mathf.Lerp(Zoom, Zoom_Distance, Z);

        else if (Z < 0.0f)
            Zoom = Mathf.Lerp(Zoom,0.0f,-Z);

        Zoom_Pos = transform.forward * Zoom;
        if (CameraFix)
            Follow_Camera_Pos = Player.position + Offset_Pos;

        else
        {
            if (Input.mousePosition.x < 10.0f)
                Follow_Camera_Pos += Vector3.left * 10.0f * Time.deltaTime;

            else if (Input.mousePosition.x > (Screen.width - 10.0f))
                Follow_Camera_Pos += Vector3.right * 10.0f * Time.deltaTime;

            if (Input.mousePosition.y < 10.0f)
                Follow_Camera_Pos += Vector3.back * 10.0f * Time.deltaTime;

            else if (Input.mousePosition.y > (Screen.height - 10.0f))
                Follow_Camera_Pos += Vector3.forward * 10.0f * Time.deltaTime;
        }

        transform.position = Follow_Camera_Pos + Zoom_Pos;
    }
}
