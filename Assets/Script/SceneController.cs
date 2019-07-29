using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public void StartButtonClicked()
    {
        // タイトル → セレクト
        SceneManager.LoadScene("StageSelect");
    }

    public void ReStartButtonClicked()
    {
        // リザルト → ゲーム
        SceneManager.LoadScene("Follow");
    }

    public void StageSelectButtonClicked()
    {
        // リザルト → セレクト
        SceneManager.LoadScene("StageSelect");
    }

    public void NextStageButtonClicked()
    {
        // リザルト → 次のステージ
        SceneManager.LoadScene("Follow");
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
        #endif
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) EndGame();
    }
}
