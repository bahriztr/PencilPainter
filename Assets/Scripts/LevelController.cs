using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class LevelController : MonoBehaviour
{     
    
    public static LevelController Instance;

    public int currentLevel = 0;
    public Transform levels;
    public Transform pencil;
    private Vector3 pencilStartPos = new Vector3(0f, 20f, 0f);

    void Awake()
    {
        if (Instance != null)
            Destroy(this);

        else
        {
            Instance = this;            
        }
    }

    private void Start()
    {
        pencil = GameObject.FindGameObjectWithTag("Player").transform;
        levels = GameObject.FindGameObjectWithTag("Levels").transform;
    }


    public void NextLevel()
    {
        DOTween.KillAll();

        if (currentLevel < levels.transform.childCount - 1)
        {
            levels.GetChild(currentLevel).gameObject.SetActive(false);
            levels.GetChild(currentLevel + 1).gameObject.SetActive(true);
            pencil.position = pencilStartPos;
            currentLevel++;
        }

        else
            RestartGame();

    }

    public void RestartLevel()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);        
        levels.GetChild(0).gameObject.SetActive(false);
        levels.GetChild(currentLevel).gameObject.SetActive(true);        

    }

    public void RestartGame()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(0);        
        currentLevel = 0;
    }

}
