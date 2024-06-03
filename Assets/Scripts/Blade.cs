using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody2D rb;
    public float minVelo = 0.1f;

    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        col.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            col.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            col.enabled = false;
        }
        BladeMovementWithMouse();
    }

    private void BladeMovementWithMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;     // distance of 10 units from the camera
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private bool IsMouseMoving(){
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePos - curMousePos).magnitude * 5;
        lastMousePos = curMousePos;
        Debug.Log(lastMousePos);
        Debug.Log(traveled + "Travelled");
        
        if (traveled > minVelo)
            return true;
        else
            return false;
    }
}
