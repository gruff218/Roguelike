using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelComplete : MonoBehaviour
{
    
    public void LoadNextLevel() {
        GameInfo.level = GameInfo.level + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
