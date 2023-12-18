using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCardNames : MonoBehaviour
{
    public List<string> CardNamesEng;
    public List<string> CardNamesTr;
    public List<CardTurn> Cards;

    private void Awake()
    {
        Cards = Cards.OrderBy(a => Guid.NewGuid()).ToList();
        for (int i = 0; i < Cards.Count/2; i++)
        {
            Cards[i].fruitName= CardNamesEng[i];
            Cards[i].nameIndex = i;
        }
        for (int i = Cards.Count / 2; i < Cards.Count ; i++)
        {
            Cards[i].fruitName = CardNamesTr[i-Cards.Count/2];
            Cards[i].nameIndex = i - Cards.Count / 2;
        }
    }



}//class
