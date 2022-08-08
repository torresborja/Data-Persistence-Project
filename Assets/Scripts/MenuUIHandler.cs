using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] InputField namePlayer;
    [SerializeField] Text bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadPersistentData();
        int score = DataManager.Instance.maxScore;
        string player = DataManager.Instance.nameMaxScorePlayer;
        if (score == 0)
        {
            player = "none";
        }
        UpdateMaxScoreText(player, score);
    }

    void UpdateMaxScoreText(string name, int score)
    {
        bestScoreText.text = "Best Score: " + name + " : " + score;
    }

    public void OnStartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void OnQuit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnEndEdit()
    {
        DataManager.Instance.nameActualPlayer = namePlayer.text;
    }
}
