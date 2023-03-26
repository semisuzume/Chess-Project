using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Vector3 parentPosition;
    public float i;

    // Start is called before the first frame update
    void Start()
    {
        parentPosition = transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
        CameraParent();
        CameraRotate();
    }

    private void CameraRotate()
    {
        Vector2 screen_point;
        screen_point = Input.mousePosition;
        if (screen_point.y <= 0)
        {
            transform.parent.Rotate(0.5f, 0, 0);
        }
        if (screen_point.y >= Screen.height)
        {
            transform.parent.Rotate(-0.5f, 0, 0);
        }
    }
    public void CameraMove()
    {
        parentPosition += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) / 5;
        parentPosition += new Vector3(0, 0, Input.GetAxisRaw("Vertical")) / 5;
        parentPosition += new Vector3(0, Input.GetAxisRaw("Jump")) / 5;
        if (gameObject.transform.position.y >= 3)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                i = -1;
                parentPosition += new Vector3(0, i, 0) / 5;
            }
        }
    }
    private void CameraParent()
    {
        transform.position = parentPosition;
    }
}
