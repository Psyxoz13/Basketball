using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private Image[] _numbers;
    [SerializeField] private Sprite[] _numbersSprites;

    public void SetNumber(int number)
    {
        var setNumbers = GetNumbers(number);

        for (int i = 0; i < _numbers.Length; i++)
        {
            _numbers[i].sprite = _numbersSprites[setNumbers[i]];
        }
    }

    private List<int> GetNumbers(int number)
    {
        var numberString = number.ToString();
        var numbers = new List<int>();

        var zeroCount = _numbers.Length - numberString.Length;

        for (int i = 0; i < zeroCount; i++)
        {
            numbers.Add(0);
        }

        for (int i = 0; i < numberString.Length; i++)
        {
            numbers.Add(int.Parse(numberString[i].ToString()));
        }

        return numbers;
    }
}
