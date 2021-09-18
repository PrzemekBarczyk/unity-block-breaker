using UnityEngine;

public class BottomWall : MonoBehaviour
{
	GameManager _gameManager;

	void Start()
	{
		_gameManager = GameManager.Instance;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ball"))
		{
			_gameManager.RemoveLife();
		}
	}
}
