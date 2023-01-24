using TMPro;
using UnityEngine;

public class NameSetColliderWidth : MonoBehaviour
{
    public float sizePerLetter = 0.6f;
    private BoxCollider2D _collider;
    private TextMeshProUGUI _name;

    private void Start()
    {
        _name = GetComponent<TextMeshProUGUI>();
        _collider = GetComponent<BoxCollider2D>();
        _collider.size = _name.text.Length > 0 ? new Vector2(_name.text.Length * sizePerLetter, _collider.size.y) : new Vector2(0, _collider.size.y);
    }
}