using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool down = false;
    [SerializeField] private Vector2 mouseOnDown;
    [SerializeField] private Vector2 mouse;
    [SerializeField] private float movementSpeed = .05f;
    [SerializeField] private float limitXMovementMin = -45f;
    [SerializeField] private float limitXMovementMax = 45f;
    [SerializeField] private float limitYMovementMin = -20f;
    [SerializeField] private float limitYMovementMax = 20f;
    [SerializeField] private Vector3 position;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            down = true;
            mouseOnDown.x = Input.mousePosition.x;
            mouseOnDown.y = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            down = false;
        }

        if (down || 1==1)
        {
            mouse.x = Input.mousePosition.x-725f;
            mouse.y = Input.mousePosition.y-350f;

            Debug.Log("x=" + mouse.x.ToString());
            Debug.Log("y=" + mouse.y.ToString());

            mouse.x *= movementSpeed;
            mouse.y *= movementSpeed;

            Debug.Log("damp x=" + mouse.x.ToString());
            Debug.Log("damp y=" + mouse.y.ToString());

            mouse.x = Mathf.Clamp(mouse.x, limitXMovementMin, limitXMovementMax);
            mouse.y = Mathf.Clamp(mouse.y, limitYMovementMin, limitYMovementMax);

            Debug.Log("clamp x=" + mouse.x.ToString());
            Debug.Log("clamp y=" + mouse.y.ToString());

            position.x = mouse.x; 
            position.y = mouse.y; 
            position.z = 0f; 
            transform.position = position;
        }
    }
}
