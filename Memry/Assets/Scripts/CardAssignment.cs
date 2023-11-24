using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAssignment : MonoBehaviour
{
    private List<int> cardNumbers = new List<int>();
    private int originalCardNumberLength;
    private int chosenCard;

    public int[] shuffledCardNumbersDoNotEdit = new int[12];
    private void Awake()
    {
        for (int i = 0; i < 6; i++)
        {
            cardNumbers.Add(i);
            cardNumbers.Add(i);
        }
        originalCardNumberLength = cardNumbers.Count;
        for (int i = 0; i < originalCardNumberLength; i++)
        {
            chosenCard = Random.Range(0, cardNumbers.Count - 1);
            shuffledCardNumbersDoNotEdit[i] = cardNumbers[chosenCard];
            cardNumbers.Remove(cardNumbers[chosenCard]);
        }
    }
}
