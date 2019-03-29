using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
  // configuration parameters
  [SerializeField] float minX = 1f, maxX = 15f;
  [SerializeField] float screenWidthInUnits = 16f;

  // cached component references
  GameSession theGameSession;
  Ball theBall;

  private void Start() {
    theGameSession = FindObjectOfType<GameSession>();
    theBall = FindObjectOfType<Ball>();
  }

  // Update is called once per frame
  void Update() {
    Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
    paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
    transform.position = paddlePos;
  }

  private float GetXPos() {
    if (theGameSession.IsAutoPlayEnabled()) {
      return theBall.transform.position.x;
    }

    return Input.mousePosition.x / Screen.width * screenWidthInUnits;
  }
}
