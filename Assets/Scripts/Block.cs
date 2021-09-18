using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] [Min(1)] int _strength = 1;

	[SerializeField] int _score = 1;

	BlockManager _blockManager;
	GameManager _gameManager;

	void Start()
	{
		_blockManager = FindObjectOfType<BlockManager>();
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
			_blockManager.RemoveBlock(this);
			Destroy(gameObject);

			if (_blockManager.BlocksLeft() <= 0)
				_gameManager.NextLevel();
		}
	}
}
