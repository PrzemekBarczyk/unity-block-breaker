using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] [Min(1)] int _strength = 1;

	[SerializeField] int _score = 1;

	GameManager _gameManager;

	void Start()
	{
		_gameManager = GameManager.Instance;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("Ball"))
		{
			TakeHit();
		}
	}

	void TakeHit()
	{
		_strength--;

		if (_strength == 0)
		{
			_gameManager.AddScore(_score);
			Destroy(gameObject);
		}
	}
}
