using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] TMP_Text bestTimeText;
    [SerializeField] TMP_Text coinText;  
    public static GameManager instance;

    public float levelTime;
    private float bestTime;
    private int totalCoins = 0;  
    [SerializeField] private int maxCoins = 4;  

    void Awake()
    {
        instance = this;
        bestTime = PlayerPrefs.GetFloat("bestTime", float.MaxValue);
        bestTimeText.text = "Best: " + TimeSpan.FromSeconds(bestTime).ToString(@"mm\:ss\:f");
        UpdateCoinDisplay();
    }

    void Update()
    {
        levelTime += Time.deltaTime;
        timerText.text = TimeSpan.FromSeconds(levelTime).ToString(@"mm\:ss\:f");
    }

    public void CollectCoin()
    {
        if (totalCoins < maxCoins)
        {
            totalCoins++;
            UpdateCoinDisplay();
            Debug.Log($"Coin collected! Total coins: {totalCoins}");
        }
    }

    private void UpdateCoinDisplay()
    {
        coinText.text = $"{totalCoins} / {maxCoins}";
    }

    public void Win()
    {
        if (levelTime < bestTime)
        {
            bestTime = levelTime;
            PlayerPrefs.SetFloat("bestTime", bestTime);
        }
    }

    public async void Die()
    {
        await new WaitForSeconds(2f);
        var name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }

    public void SetMaxCoins(int newMax)
    {
        maxCoins = newMax;
        UpdateCoinDisplay();
    }
}