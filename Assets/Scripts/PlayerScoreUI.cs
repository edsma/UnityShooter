using TMPro;
using UnityEngine;

public class PlayerScoreUI : MonoBehaviour
{
    public TextMeshProUGUI _text;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChange.AddListener(RefreshText);
    }

    private void RefreshText()
    {
        _text.text = $"SCORE: {ScoreManager.SharedInstance.Amount}";
    }
}
