using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject tray;
    [SerializeField] private bool down = false;
    [SerializeField] private Vector2 mouseOnDown;
    [SerializeField] private Vector2 mouse;
    [SerializeField] private float movementSpeed = .05f;
    [SerializeField] private float limitXMovementMin = -45f;
    [SerializeField] private float limitXMovementMax = 45f;
    [SerializeField] private float limitYMovementMin = -20f;
    [SerializeField] private float limitYMovementMax = 20f;
    [SerializeField] private Vector3 position;
    [SerializeField] private Animation moveTrayUpAnim;
    [SerializeField] private Animation moveTrayDownAnim;

    private bool moveTrayUp = false;
    private bool moveTrayDown = false;
    private bool gotinstrument = false;
    private GameObject theGrabbedInstr;
    private int count = 18;

    void Start()
    {
       Cursor.visible = false;
     //   GameObject.Find("Tray").GetComponent<Animator>().enabled = false;
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

        mouse.x = Input.mousePosition.x-725f;
        mouse.y = Input.mousePosition.y-350f;

 //       Debug.Log("x=" + mouse.x.ToString());
 //       Debug.Log("y=" + mouse.y.ToString());

        mouse.x *= movementSpeed;
        mouse.y *= movementSpeed;

 //       Debug.Log("damp x=" + mouse.x.ToString());
 //       Debug.Log("damp y=" + mouse.y.ToString());

        mouse.x = Mathf.Clamp(mouse.x, limitXMovementMin, limitXMovementMax);
        mouse.y = Mathf.Clamp(mouse.y, limitYMovementMin, limitYMovementMax);

 //       Debug.Log("clamp x=" + mouse.x.ToString());
 //       Debug.Log("clamp y=" + mouse.y.ToString());

        position.x = mouse.x; 
        position.y = mouse.y; 
        position.z = 0f; 

        transform.position = position;

        if (down)
        {
            /*
            // If mouse is down
            if (!moveTrayUp)
            {
                moveTrayUp = true;
                GameObject.Find("Tray").GetComponent<Animator>().enabled = true;
            }
            */

            if (!gotinstrument)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -Vector3.up, out hit))
                {
                    var iname = hit.collider.gameObject.name;
                    Debug.Log("gotinstrument = " + iname);
                    if ((iname != "Left Board" && iname != "Top Board" && iname != "Right Board" && iname != "Bottom Board"))
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.transform.parent = this.transform;
                        gotinstrument = true;
                        theGrabbedInstr = hit.collider.gameObject;
                        theGrabbedInstr.GetComponent<Parts>().PlayInstrument();
                    }

                }
            }

        }
            
        if (Input.GetMouseButtonUp(1) && gotinstrument)
            {
                if (theGrabbedInstr != null)
                {
                    theGrabbedInstr.GetComponent<AudioSource>().clip = theGrabbedInstr.GetComponent<Parts>().instrument.Collision;
                    Debug.Log("Collision sound: " + theGrabbedInstr.GetComponent<Parts>().instrument.Collision);
                    Debug.Log("Clip name: " + theGrabbedInstr.GetComponent<AudioSource>().clip.name);
                    theGrabbedInstr.GetComponent<AudioSource>().Play();
                   // theGrabbedInstr.GetComponent<ParticleSystem>().Play();

                     Destroy(theGrabbedInstr, .01f);
                    Debug.Log("thegrabbedinstr " + theGrabbedInstr.name + " was destroyed");
                    gotinstrument = false;
                    count--;
                }

            if (count == 0)
            {
                SceneManager.LoadSceneAsync("Home");
            }
        }
    }
    /*
        void FixedUpdate()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit))
            {
               // Debug.Log("Found an object - distance: " + hit.distance);
                Debug.Log("Hit Collider: " + hit.collider.name);
            }
        }
    */
}
