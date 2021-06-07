using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float endDelay = 2f;
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
        
        completeLevelUI.SetActive(true);
        Invoke("QuitGame", endDelay);
		
	}

    public void QuitGame() {
        Debug.Log("HELLO");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
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
