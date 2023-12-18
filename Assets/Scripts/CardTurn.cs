using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CardTurn : MonoBehaviour
{
    private Vector3 _turning = new Vector3(0, 1, 0);
    public bool isTurning = false;
    private int counter = 0;
    public string fruitName;
    public int nameIndex;
    [SerializeField] public TextMeshPro tmp_text;

    private void Start()
    {
        tmp_text.text = fruitName;
    }
    void Update()
    {
        if (isTurning == true)
        {
            if (counter < 180)
            {
                gameObject.transform.Rotate(_turning);
                counter++;
                
            }
            else if (counter >= 180 && GameManager.turnedCards == 0)
            {
                isTurning = false;
            }
            else if (GameManager.turnedCards == 2)
            {
                Matched();
            }
        }
    }

    private void OnMouseDown()
    {
        if (isTurning == false)
        {
            if (GameManager.turnedCards <= 1)
            {
                isTurning = true;
                counter = 0;
                if (GameManager.firstCard == null)
                {
                    GameManager.MyCard(this);
                }
                GameManager.turnedCards++;

            }
        }
    }
    public void Matched()
    {
        if (GameManager.firstCard == null)
        {
            return;
        }
        if (GameManager.firstCard == this)
        {
            return;
        }
        if (GameManager.firstCard.nameIndex == nameIndex)
        {
            GameManager.turnedCards = 0; 
            Destroy(GameManager.firstCard.gameObject , 0.30f);
            GameManager.firstCard = null;
            Destroy(gameObject, 0.30f);   
        }
        else
        {
            TurnCard();
            GameManager.firstCard.TurnCard();
            GameManager.firstCard = null;
            StartCoroutine(WaitForTurnCard()); 
        }
    }
    IEnumerator WaitForTurnCard() 
    {
        yield return new WaitForSeconds(0.80f);
        GameManager.turnedCards = 0;
    }
    public void TurnCard()
    {
        isTurning = true;
        counter = 0;
    }


}//class
