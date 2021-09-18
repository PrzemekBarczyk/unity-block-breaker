using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
	[SerializeField] [Range(100, 400)] float _speed = 100f;
	[Space]

	[SerializeField] [Range(200, 400)] float _bounceOfPlayerRange = 300f;
	[Space]

	Paddle _paddle;

	Vector3 _startPosition;

	Vector3 _offsetToPaddle;

	bool _isGluedToPlayer = true;

	Rigidbody2D _myRigidbody;

	void Awake()
	{
		_myRigidbody = GetComponent<Rigidbody2D>();

		_paddle = FindObjectOfType<Paddle>();
	}

	void Start()
	{
		_startPosition = transform.position;

		_offsetToPaddle = _paddle.transform.position - transform.position;
	}

	void Update()
	{
		if (_isGluedToPlayer)
		{
			FollowPlayer();
		}
		if (Input.GetMouseButtonDown(0))
		{
			_isGluedToPlayer = false;
		}
	}

	void FollowPlayer()
	{
		transform.position = _paddle.transform.position - _offsetToPaddle;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag(_paddle.tag))
		{
			float xForce = (transform.position.x - collision.transform.position.x) * _bounceOfPlayerRange;
			float yForce = Mathf.Sqrt(Mathf.Abs(_speed * _speed - xForce * xForce));

			_myRigidbody.velocity = Vector2.zero;
			_myRigidbody.AddForce(new Vector2(xForce, yForce));
		}
	}

	public void ResetPosition()
	{
		_isGluedToPlayer = true;
		transform.position = _startPosition;
	}
}
