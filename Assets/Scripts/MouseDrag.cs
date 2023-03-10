using UnityEngine;

public class MouseDrag : MonoBehaviour
{
    public float scaleFactor = 1.2f;
    public float followSpeed = 5f;
    private CircleCollider2D _collider;
    private Vector3 _mousePosition;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<CircleCollider2D>();
        _collider.enabled = true;
    }

    private void OnMouseOver()
    {
        Zoom();
        if (!Input.GetMouseButton(0)) return;
        _mousePosition = Camera.main!.ScreenToWorldPoint(Input.mousePosition);
        _mousePosition.x += Random.Range(-0.05f, 0.05f);
        transform.position = Vector2.Lerp(transform.position, _mousePosition, followSpeed * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        _spriteRenderer.color = Color.white;
        transform.localScale /= scaleFactor;
    }

    public void Zoom()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        transform.localScale *= 1.2f;
        _spriteRenderer.color = Color.red;
    }
}