using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
	[SerializeField] [Min(0)] int _highScoreValue = 0;
	[SerializeField] Text _hightScoreText;

	[SerializeField] [Min(0)] int _scoreValue = 0;
	[SerializeField] Text _scoreText;

	[SerializeField] [Min(1)] int _livesValue = 3;
    [SerializeField] Text _livesText;

	Ball _ball;
	Paddle _paddle;

	SceneManager _sceneManager;

	void Start()
	{
		_highScoreValue = PlayerPrefs.GetInt("high score");

		_hightScoreText.text = _highScoreValue.ToString();
		_scoreText.text = _scoreValue.ToString();
		_livesText.text = _livesValue.ToString();

		_ball = FindObjectOfType<Ball>();
		_paddle = FindObjectOfType<Paddle>();

		_sceneManager = SceneManager.Instance;
	}

	public void AddScore(int scoreToAdd)
	{
		_scoreValue += scoreToAdd;
		_scoreText.text = _scoreValue.ToString();
	}

	public void RemoveLife()
	{
        _livesValue--;

		if (_livesValue <= 0)
		{
			if (_scoreValue > _highScoreValue)
				PlayerPrefs.SetInt("high score", _scoreValue);

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
