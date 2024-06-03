using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour //,IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Score System")]
    [SerializeField] private int score;
    [SerializeField] private int highScore;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text HighScoreText;
    
    [Header("GameOver System")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text gameOverScoreText;
    
    // [Header("Ads")]
    // [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    // [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    // string _adUnitId;
    //
    // [SerializeField] string _androidGameId;
    // [SerializeField] string _iOSGameId;
    // [SerializeField] bool _testMode = true;
    // private string _gameId;


    private void Awake()
    {
        // InitializeAds();
        // Get the Ad Unit ID for the current platform:
        // _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //     ? _iOsAdUnitId
        //     : _androidAdUnitId;
        //---------------------------------------------------------------------------//
        
        gameOverPanel.SetActive(false);
        highScore = PlayerPrefs.GetInt("Highscore");
        HighScoreText.text = "Best: " + highScore;
    }

    public void ScoreSystem()
    {
        score++;
        scoreText.text = score.ToString();
        if (score > highScore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            HighScoreText.text = "Best: "+ score.ToString();
        }
        
    }

    public void BombHit()
    {
        //ShowAd();
        AdsManager.Instance.interstitial.ShowAd();
        Time.timeScale = 0;         // Basic way to stop the game...
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score.ToString();
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameRestart()
    {
        //ShowAd();
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("Game");
        //todo Restart Game
    }
    
    
    //-------------------------Advertisement-------------------------------------------------
    
//     public void InitializeAds()
//     {
//         #if UNITY_IOS
//             _gameId = _iOSGameId;
//         #elif UNITY_ANDROID
//             _gameId = _androidGameId;
//         #elif UNITY_EDITOR
//             _gameId = _androidGameId; //Only for testing the functionality in the Editor
//         #endif
//         if (!Advertisement.isInitialized && Advertisement.isSupported)
//         {
//             Advertisement.Initialize(_gameId, _testMode, this);
//         }
//     }
//     public void OnInitializationComplete()
//     {
//         Debug.Log("Unity Ads initialization complete.");
//     }
//  
//     public void OnInitializationFailed(UnityAdsInitializationError error, string message)
//     {
//         Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
//     }
//    
//  
//     // Load content to the Ad Unit:
//     public void LoadAd()
//     {
//         // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
//         Debug.Log("Loading Ad: " + _adUnitId);
//         Advertisement.Load(_adUnitId, this);
//     }
//  
//     // Show the loaded content in the Ad Unit:
//     public void ShowAd()
//     {
//         // Note that if the ad content wasn't previously loaded, this method will fail
//         Debug.Log("Showing Ad: " + _adUnitId);
//         Advertisement.Show(_adUnitId, this);
//     }
//  
//     // Implement Load Listener and Show Listener interface methods: 
//     public void OnUnityAdsAdLoaded(string adUnitId)
//     {
//         // Optionally execute code if the Ad Unit successfully loads content.
//     }
//  
//     public void OnUnityAdsFailedToLoad(string _adUnitId, UnityAdsLoadError error, string message)
//     {
//         Debug.Log($"Error loading Ad Unit: {_adUnitId} - {error.ToString()} - {message}");
//         // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
//     }
//  
//     public void OnUnityAdsShowFailure(string _adUnitId, UnityAdsShowError error, string message)
//     {
//         Debug.Log($"Error showing Ad Unit {_adUnitId}: {error.ToString()} - {message}");
//         // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
//     }
//  
//     public void OnUnityAdsShowStart(string _adUnitId) { }
//     public void OnUnityAdsShowClick(string _adUnitId) { }
//     public void OnUnityAdsShowComplete(string _adUnitId, UnityAdsShowCompletionState showCompletionState) { }
}
