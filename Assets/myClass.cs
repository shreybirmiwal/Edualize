using UnityEngine;

public class RotateOnRightClick : MonoBehaviour
{
    public GameObject targetObject;
    private bool isDragging = false;
    private Vector3 previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // Start dragging on right-click
            isDragging = true;
            previousMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            // Stop dragging on right-click release
            isDragging = false;
        }

        if (isDragging)
        {
            // Calculate the rotation amount based on mouse movement
            Vector3 mouseDelta = Input.mousePosition - previousMousePosition;
            float rotationAmountX = Mathf.Clamp(mouseDelta.y, -5f, 5f); // Inverted the sign for vertical rotation
            float rotationAmountY = Mathf.Clamp(-mouseDelta.x, -5f, 5f);

            // Rotate the target GameObject
            if (targetObject != null)
            {
                targetObject.transform.Rotate(Vector3.up, rotationAmountY, Space.World);
                targetObject.transform.Rotate(Vector3.right, rotationAmountX, Space.World);
            }

            // Update the previous mouse position
            previousMousePosition = Input.mousePosition;
        }
    }
}
