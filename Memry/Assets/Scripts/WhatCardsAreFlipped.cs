using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatCardsAreFlipped : MonoBehaviour
{
    public List<int> flippedCards = new List<int>();
    public int amountOfCardsFlipped;
    public int cardNumberFlipped1;
    public int cardNumberFlipped2;
    public CardAssignment cardAssignment;
    public CardTurn[] cardTurnScrips;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 12; i++)
        {
            flippedCards.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        amountOfCardsFlipped = 0;
        cardNumberFlipped1 = -1;
        cardNumberFlipped2 = -1;
        for(int i = 0; i < flippedCards.Count; i++)
        {
            if(flippedCards[i] == 1)
            {
                if(cardNumberFlipped1 == -1)
                {
                    cardNumberFlipped1 = i;
                }
                else
                {
                    cardNumberFlipped2 = i;
                }
                amountOfCardsFlipped ++;
            }
        }
        if (!cardTurnScrips[0].grounded || !cardTurnScrips[1].grounded || !cardTurnScrips[2].grounded || !cardTurnScrips[3].grounded || !cardTurnScrips[4].grounded || !cardTurnScrips[5].grounded || !cardTurnScrips[6].grounded || !cardTurnScrips[7].grounded || !cardTurnScrips[8].grounded || !cardTurnScrips[9].grounded || !cardTurnScrips[10].grounded || !cardTurnScrips[11].grounded)
        {
            for (int i = 0; i < cardTurnScrips.Length; i++)
            {
                cardTurnScrips[i].canFlip = false;
            }
        }
        else
        {
            for(int i = 0; i < cardTurnScrips.Length; i++)
            {
                cardTurnScrips[i].canFlip = true;
            }
        }
        if (cardNumberFlipped1 != -1 && cardNumberFlipped2 != -1)
        {
            if (cardAssignment.shuffledCardNumbersDoNotEdit[cardNumberFlipped1] == cardAssignment.shuffledCardNumbersDoNotEdit[cardNumberFlipped2])
            {
                for (int i = 0; i < cardTurnScrips.Length; i++)
                {
                    if(i == cardNumberFlipped1 || i == cardNumberFlipped2)
                    {
                        cardTurnScrips[i].deactivate = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < cardTurnScrips.Length; i++)
                {
                    cardTurnScrips[i].forceFlip = true;
                }
            }
        }
    }
}
