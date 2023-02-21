using UnityEngine;
using UnityEngine.SceneManagement;
using UnityTools.Buttons;

public class Restarter : MonoBehaviour
{
    [SerializeField] private UIButton _button;

    #region MonoBehaviour

    private void OnEnable()
    {
        _button.OnClicked += RestartCurrentScene;
    }

    private void OnDisable()
    {
        _button.OnClicked -= RestartCurrentScene;
    }

    #endregion

    private void RestartCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        var currentIndex = currentScene.buildIndex;

        SceneManager.LoadScene(currentIndex);
    }
}