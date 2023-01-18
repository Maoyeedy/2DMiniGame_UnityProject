using TMPro;
using UnityEngine;

public class MatchColliderToName : MonoBehaviour
{
    public float sizePerLetter = 0.6f;
    private TextMeshProUGUI _name;
    private BoxCollider2D _collider;
    private void Start()
    {
        _name = GetComponent<TextMeshProUGUI>();
        _collider = GetComponent<BoxCollider2D>();
        if (_name.text.Length > 0)
            _collider.size = new Vector2(_name.text.Length * sizePerLetter, _collider.size.y);
        else
            _collider.size = new Vector2(0, _collider.size.y);
    }
}