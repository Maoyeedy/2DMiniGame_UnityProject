using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    public float speed = 5f;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePos, speed * Time.deltaTime);
        }
    }
}