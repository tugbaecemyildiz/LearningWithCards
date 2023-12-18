using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class AllMatched : MonoBehaviour
{
    [SerializeField] private Transform cards;
    [SerializeField] private GameObject panel;
    private void Update()
    {
        if (cards.childCount ==0)
        {
            if (SceneManager.GetActiveScene().buildIndex <3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            else
            {
                if (panel != null)
                {
                    panel.SetActive(true);
                }
            }
        }
    }
}//class
