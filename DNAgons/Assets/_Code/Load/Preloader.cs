using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Preloader : MonoBehaviour {

    float loadTime;
    public float minLoadTime = 2f;

    public Text percentage;

    void Start ()
    {
        percentage.text = "0%";

        // Load the game
        // $$$

        // Get a timestamp of the completion time

        if (Time.time < minLoadTime)
            loadTime = minLoadTime;
        else
            loadTime = Time.time;
    }

    void Update()
    {
        float _timeLeft = (loadTime - Time.time) / loadTime * 100;

        float _progress = Mathf.Clamp((100 - _timeLeft), 0f, 100f);
        float _pRounded = Mathf.Round(_progress);

        percentage.text = _pRounded.ToString() + "%";
        if ((_progress) >= 100)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
