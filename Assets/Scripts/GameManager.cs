using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager 
{
    public static CardTurn firstCard;
    public static int turnedCards;
    public static void MyCard(CardTurn onclicked)
    {
        firstCard = onclicked;
    }
}
