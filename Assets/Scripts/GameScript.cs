using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Char;
using Random = UnityEngine.Random;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI numberOfMatchesText;
    [SerializeField] private TMP_InputField playerInputField;
    [SerializeField] private Button enterButton;

    private int _numberLength = 4;
    private int _hiddenNumber;
    private string _inputText;

    private byte[] _hiddenNumberArray;
    private byte[] _inputNumberArray;

    private void Start()
    {
        enterButton.onClick.AddListener(SearchForMatches);
        _hiddenNumber = Random.Range(1000, 10000);
        _hiddenNumberArray = ConvertIntegerToList(_hiddenNumber);
        _inputText = playerInputField.text;
    }

    private void Update()
    {
    }

    private void SearchForMatches()
    {
        if (_inputText.Length == _numberLength)
        {
        }
    }

    private byte[] ConvertIntegerToList(int number)
    {
        var listOfNumbers = new List<byte>();
        foreach (var a in number.ToString().ToCharArray())
        {
            listOfNumbers.Add((byte)GetNumericValue(a));
        }

        return listOfNumbers.ToArray();
    }
}