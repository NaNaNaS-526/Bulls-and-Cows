using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button leftArrow;
    [SerializeField] private Button rightArrow;
    [SerializeField] private TextMeshProUGUI numberLengthText;
    public static int NumberLength = 4;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartNewGame);
        settingsButton.onClick.AddListener(ShowSettingsPanel);
        leftArrow.onClick.AddListener(DecreaseNumberLength);
        rightArrow.onClick.AddListener(IncreaseNumberLength);
        numberLengthText.text = NumberLength.ToString();
        settingsPanel.SetActive(false);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(1);
    }

    private void ShowSettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    private void IncreaseNumberLength()
    {
        if (NumberLength < 6) NumberLength++;
        numberLengthText.text = NumberLength.ToString();
    }

    private void DecreaseNumberLength()
    {
        if (NumberLength > 2) NumberLength--;
        numberLengthText.text = NumberLength.ToString();
    }
}