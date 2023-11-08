using UnityEngine;
namespace tott
{
public class CameraCusor : MonoBehaviour
{
    public Transform playerTransform;
    public float sensitivity = 2.0f;
    public float maxYAngle = 80.0f;
    public float tiltAngle = 45.0f;
    public float smooth = 0.125f;
    
    private Vector2 currentRotation = Vector2.zero;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        currentRotation.x += mouseX * sensitivity;
        currentRotation.y -= mouseY * sensitivity;

        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);

        Quaternion cameraRotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
        transform.rotation = cameraRotation;

        Quaternion playerRotation = Quaternion.Euler(0, currentRotation.x, 0);
        playerTransform.rotation = playerRotation;

        Vector3 cameraForward = cameraRotation * Vector3.forward;
        Quaternion tiltRotation = Quaternion.Euler(tiltAngle, 0, 0);
        cameraForward = tiltRotation * cameraForward;

        Vector3 cameraPosition = playerTransform.position - cameraForward * 1.15f;
        cameraPosition.y = playerTransform.position.y + 1.15f;
        transform.position = cameraPosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}

}
