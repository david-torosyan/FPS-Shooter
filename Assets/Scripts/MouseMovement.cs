using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 5f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;


    float xRotation = 0f;
    float yRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Making cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Geting mouse input 
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; /** Time.deltaTime;*/
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; /** Time.deltaTime;*/

        // Rotation around X axis (Look up and down)
        xRotation -= mouseY;
        // Rotation left and right
        yRotation += mouseX;

        // Clamp the rotation 
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Apply rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}
