using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    public Rigidbody RB;

    public float moveSpeed = 10f;

    private Vector2 mouseInput;
    private Vector2 keyboardInput;

    public float mouseSensitivity = 3f;

    public Camera mainCamera;

    private float minAngle = 10f;
    private float maxAngle = 160f;
    public Animator gunAnim;
    

        

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void Awake()
    {
        instance = this;
    }


    // Update is called once per frame
    void Update()
    {

        void movement()
        {

            // keyboard movement

            keyboardInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHoriz = transform.up * -keyboardInput.x;
            Vector3 moveVert = transform.right * keyboardInput.y;
            RB.velocity = (moveHoriz + moveVert) * moveSpeed;

            // mouse movement

            mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("MouseY"));
            Vector3 rotAmountHorz = transform.rotation.eulerAngles + new Vector3(0f, 0f, -mouseInput.x);
            transform.rotation = Quaternion.Euler(rotAmountHorz.x, rotAmountHorz.y, rotAmountHorz.z);

            Vector3 rotAmountVert = mainCamera.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);
            mainCamera.transform.localRotation = Quaternion.Euler(rotAmountVert.x, Mathf.Clamp(rotAmountVert.y, minAngle, maxAngle), rotAmountVert.z);
        }
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            // يقوم بإخفاء السهم
            if (Input.GetMouseButtonDown(0))
            {
                gunAnim.SetTrigger("shoot");//يقوم بتفعيل الأنميشن

                Ray ray =
             mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Enemy")
                    {
                        Destroy(gameObject);
                    }
                    
                }
            }
        }



        movement();

    }
}
