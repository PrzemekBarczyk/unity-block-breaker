using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
	[SerializeField] [Min(1)] int _livesValue = 3;

    [SerializeField] Text _livesText;

	[SerializeField] Ball _ball;
	[SerializeField] Paddle _paddle;

	SceneManager _sceneManager;

	void Start()
	{
		_livesText.text = _livesValue.ToString();

		_ball = FindObjectOfType<Ball>();
		_paddle = FindObjectOfType<Paddle>();

		_sceneManager = SceneManager.Instance;
	}

	public void RemoveLife()
	{
        _livesValue--;

		if (_livesValue <= 0)
		{
			_sceneManager.LoadFirstLevel();
		}
		else
		{
			_ball.ResetPosition();
			_paddle.ResetPosition();
		}

        _livesText.text = _livesValue.ToString();
	}
}
