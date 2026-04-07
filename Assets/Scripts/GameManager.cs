using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public List<Target> targets;
    public TextMeshProUGUI cucumberPoint;
    public Button restartButton;
    public GameObject pickleOver;
    public GameObject startScreen;
    public bool isGameActive;
    
    public float spawnRate = 1;
    private int  score = 0;
    

    void Start()
    {
        restartButton.onClick.AddListener(RestartLevel); 
         cucumberPoint.text = ("Cucumber point:"+score);
         pickleOver.SetActive(false); 
        restartButton.gameObject.SetActive(false);

    }
    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate = spawnRate/difficulty;
     StartCoroutine(SpawnTarget());
     startScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }  
    private IEnumerator SpawnTarget()
    {
     while(isGameActive == true)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomTarget = Random.Range(0,targets.Count);
            Instantiate(targets[randomTarget].gameObject);
         
        }

    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score +=scoreToAdd;
        
      //    if (score < 0)
       // {
       //     score = 0;
      //  }
      cucumberPoint.text = ("Cucumber point:"+score);
    }

    public void CucumberDeath()
    {
        pickleOver.SetActive(true);
         isGameActive = false;
          restartButton.gameObject.SetActive(true);
    }

    private void RestartLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }
}   




// private make object point (-2)
 
