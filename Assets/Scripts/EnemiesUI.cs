using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesUI : MonoBehaviour
{
    public TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        EnemyManager.SharedInstance.onEnemyChange.AddListener(RefreshText);
    }

    private void RefreshText()
    {
        _text.text = $"ENEMIES: {EnemyManager.SharedInstance.Enemies}";
    }
}
