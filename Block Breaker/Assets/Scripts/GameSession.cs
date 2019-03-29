using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {
  // config params
  [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
  [SerializeField] int pointsPerBlockDestroyed = 83;
  [SerializeField] TextMeshProUGUI scoreText;
  [SerializeField] bool isAutoPlayEnabled = false;

  // state variables
  [SerializeField] int currentScore = 0;

  private void Awake() {
    int gameStatusCount = FindObjectsOfType<GameSession>().Length;

    // check if an instance of GameStatus already exists as part of our singleton pattern
    if (gameStatusCount > 1) {
      // always SetActive to false for the singleton pattern. Just destroying isn't enough
      // for there may exist a split moment during the update before the GameStatus object
      // is actually destroyed as per the script lifecycle
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else {
      DontDestroyOnLoad(gameObject);
    }
  }

  private void Start() {
    scoreText.text = currentScore.ToString();
  }

  // Update is called once per frame
  void Update() {
    Time.timeScale = gameSpeed;
  }

  public void AddToScore() {
    currentScore += pointsPerBlockDestroyed;
    scoreText.text = currentScore.ToString();
  }

  public void ResetGame() {
    Destroy(gameObject);
  }

  public bool IsAutoPlayEnabled() {
    return isAutoPlayEnabled;
  }
}
