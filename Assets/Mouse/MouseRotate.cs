using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float rotationSpeed = 100.0f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get the mouse position in screen space
            var mousePos = Input.mousePosition;

            // Convert the mouse position to world space
            var mousePosWorld = Camera.main!.ScreenToWorldPoint(mousePos);

            // Get the angle between the sprite and the mouse
            var position = transform.position;
            var angle = Mathf.Atan2(mousePosWorld.y - position.y, mousePosWorld.x - position.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotationSpeed);
        }
    }
}