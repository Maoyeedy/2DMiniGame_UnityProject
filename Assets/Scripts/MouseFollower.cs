using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 25f;

    private void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase is TouchPhase.Stationary or TouchPhase.Moved) || Input.GetMouseButton(0))
            MouseFollowAndRotate();
    }

    private void MouseFollowAndRotate()
    {
        Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        Transform transform1;
        (transform1 = transform).position = Vector2.Lerp(transform.position, mousePos, speed * Time.deltaTime);
        var transform2 = transform1;
        var position = transform2.position;
        var angle = Mathf.Atan2(mousePos.y - position.y, mousePos.x - position.x) * Mathf.Rad2Deg;
        transform2.rotation = Quaternion.Lerp(transform2.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * rotationSpeed);
    }
}