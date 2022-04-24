using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters 
    [SerializeField] int remainingBlocks; // serialized for debug

    //cached reference
    SceneChange sceneChange;
    private void Start()
    {
        sceneChange = FindObjectOfType<SceneChange>();
    }

    public void CountBlocks()
    {  
        remainingBlocks++;
    }
    public void BlockDeathCount()
    {
        remainingBlocks--;
        if (remainingBlocks <= 0)
        {
            sceneChange.LoadNextScene();
        }
    }  
}
