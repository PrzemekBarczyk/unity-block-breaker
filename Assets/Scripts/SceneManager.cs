using SM = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoSingleton<SceneManager>
{
    public void LoadNextLevel()
	{
		SM.LoadScene(SM.GetActiveScene().buildIndex + 1);
	}

	public void LoadFirstLevel()
	{
		SM.LoadScene(0);
	}
}
