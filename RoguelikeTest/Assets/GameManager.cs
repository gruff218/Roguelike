using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;

    public float restartDelay = 1f;
    public GameObject completeLevelUI;
    public GameObject display;

    int level;
    void OnEnable() {
        level = GameInfo.level;
        display.GetComponent<DisplayLevel>().setLevel(level);
	}
    void OnDisable() {
        PlayerPrefs.SetInt("level", level);
	}

    

    public void EndGame() {
        if (gameEnded == false) {
            gameEnded = true;
            Invoke("Restart", restartDelay);
		}
	}

    public void CompleteLevel() {
        completeLevelUI.SetActive(true);
	}

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

	}

    int getLevel() {
        return level;
	}
}
