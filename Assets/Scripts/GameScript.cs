using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using static UnityEngine.SceneManagement.SceneManager;

public class GameScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bullsAndCowsText;
    [SerializeField] private TMP_InputField inputNumberText;
    [SerializeField] private Button enterButton;

    [SerializeField] private TextMeshProUGUI numberText;
    [SerializeField] private TextMeshProUGUI bullsText;
    [SerializeField] private TextMeshProUGUI cowsText;
    [SerializeField] private TextMeshProUGUI moveCounterText;
    [SerializeField] private TextMeshProUGUI resultText;

    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private Button startNewGameButton;
    [SerializeField] private Button menuButton;

    private string _hiddenNumber;
    private string _inputNumber;
    private bool _isHiddenNumberCorrect;
    private bool _isInputNumberCorrect;
    private int _moves;

    private void Start()
    {
        enterButton.onClick.AddListener(SearchForMatches);
        startNewGameButton.onClick.AddListener(StartNewGame);
        menuButton.onClick.AddListener(GoToMenu);
        print(MenuScript.NumberLength);
        _hiddenNumber = Convert.ToInt32(Random.Range((float)Math.Pow(10, MenuScript.NumberLength - 1),
            (float)Math.Pow(10, MenuScript.NumberLength))).ToString();
        print(_hiddenNumber);
        inputNumberText.gameObject.GetComponent<TMP_InputField>().characterLimit = MenuScript.NumberLength;
        while (_isHiddenNumberCorrect == false)
        {
            _isHiddenNumberCorrect = CheckForCorrectNumber(_hiddenNumber);
            if (_isHiddenNumberCorrect == false)
            {
                _hiddenNumber = Convert.ToInt32(Random.Range((float)Math.Pow(10, MenuScript.NumberLength - 1),
                    (float)Math.Pow(10, MenuScript.NumberLength))).ToString();
                print(_hiddenNumber);
            }
        }
    }

    private void Update()
    {
        _inputNumber = inputNumberText.text;
    }

    private bool CheckForCorrectNumber(string number)
    {
        try
        {
            Convert.ToInt32(number);
        }
        catch
        {
            return false;
        }

        for (int i = 0; i < number.Length; i++)
        {
            for (int j = 0; j < number.Length; j++)
            {
                if (number[i] == number[j] && i != j)
                {
                    return false;
                }
            }
        }

        if (number[0] == '0') return false;
        return true;
    }

    private void SearchForMatches()
    {
        if (CheckForCorrectNumber(_inputNumber) == false)
        {
            _inputNumber = "";
            inputNumberText.text = "";
            return;
        }

        int bulls = 0;
        int cows = 0;
        if (inputNumberText.text.Length != _hiddenNumber.Length) return;
        for (int i = 0; i < MenuScript.NumberLength; i++)
        {
            int index = inputNumberText.text.IndexOf(_hiddenNumber[i]);
            if (index >= 0 & i == index)
            {
                bulls++;
            }
            else if (index >= 0)
            {
                cows++;
            }
        }

        _moves++;
        if (_moves >= 15)
        {
            ShowGameEndPanel("Defeat");
        }

        moveCounterText.text = _moves.ToString();
        bullsAndCowsText.text = $"Bulls: {bulls}\nCows: {cows}";
        numberText.text += $"{inputNumberText.text}\n";
        bullsText.text += $"{bulls.ToString()}\n";
        cowsText.text += $"{cows.ToString()}\n";
        inputNumberText.text = "";
        if (bulls == MenuScript.NumberLength)
        {
            ShowGameEndPanel("Victory!");
        }
    }

    private void ShowGameEndPanel(string result)
    {
        endGamePanel.SetActive(true);
        resultText.text = result;
    }

    private void StartNewGame()
    {
        LoadScene(GetActiveScene().buildIndex);
    }

    private void GoToMenu()
    {
        LoadScene(0);
    }
}