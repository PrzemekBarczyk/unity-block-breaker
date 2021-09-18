using UnityEngine;

public class Block : MonoBehaviour
{
	[SerializeField] [Min(1)] int _strength = 1;

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
			Destroy(gameObject);
		}
	}
}
