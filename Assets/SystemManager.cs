using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    // Start is called before the first frame update

    // 最大ステージ数
    [SerializeField]
    const int MAX_STAGE = 5;
    // 選択されたレベルを保存する
    static int level = 1;
    // スコア用の配列　要素数:5
    static float[] score = new float[MAX_STAGE];

    // ゲーム数のカウント
    static int gameCount = 1;
    void Start()
    {
        // このオブジェクトは自動削除されない
        DontDestroyOnLoad(this);

        for(int i = 0; i < MAX_STAGE; i++)
        {
            score[i] = 0.0f;
        }
    }

    // GetSet祭り

    // レベル
    public void SetLevel(int lv)
    {
        level = lv;
    }
    public int GetLevel()
    {
        return level;
    }

    // スコア
    public void SetScore(float num,int element)
    {
        score[element] = num;
    }
    public float GetScore(int element)
    {
        return score[element];
    }

    // ゲームカウント
    public void AddGameCount()
    {
        gameCount++;
    }
    public int GetGameCount()
    {
        return gameCount;
    }
}
