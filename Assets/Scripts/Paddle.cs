using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Transform _leftWall;
    [SerializeField] Transform _rightWall;

    float _minXRange;
    float _maxXRange;

    void Start()
    {
        if (_leftWall == null) Debug.LogWarning("Field is null");
        if (_rightWall == null) Debug.LogWarning("Field is null");

        _minXRange = _leftWall.position.x + _leftWall.localScale.x / 2 + transform.localScale.x / 2;
        _maxXRange = _rightWall.position.x - _rightWall.localScale.x / 2 - transform.localScale.x / 2;
    }

    void Update()
    {
        MoveAfterCursor();
    }

    void MoveAfterCursor()
    {
        Vector2 mousePositionInWordPoints = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(Mathf.Clamp(mousePositionInWordPoints.x, _minXRange, _maxXRange), transform.position.y, transform.position.z);
    }
}
