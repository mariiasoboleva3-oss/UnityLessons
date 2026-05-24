using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;
 
public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1;
    public PlayerController player;
    public CanvasGroup exitBackgroundCanvasGroup;
    public float displayImageduration = 1;

    private bool isPlayerAtExit ;
    private float timer;

    private void OnTriggerEnter(Collider other)
    {
    if (other.TryGetComponent(out PlayerController playerController))
        {
            isPlayerAtExit = true;
        }
    }

   private void Update()
    {
        if (isPlayerAtExit == true)
        {
            EndLevel();
        }
    } 
    private void EndLevel()
    {
      timer+=Time.deltaTime;
      
      exitBackgroundCanvasGroup.alpha=timer/fadeDuration; 
      if (timer > fadeDuration + displayImageduration)
        { 
            #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
            #else 
            Application.Quit();
            #endif
        }
    }
}   

