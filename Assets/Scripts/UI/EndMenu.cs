using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    private void Start()
    {
        Level.Instance.Ended += OnLevelEnded;
        gameObject.SetActive(false);
    }

    private void OnLevelEnded()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
} 
