using TMPro;
using UnityEngine;

public class WavesUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        WaveManager.SharedInstance.OnWaveChange.AddListener(RefreshText);
    }

    // Update is called once per frame
    void RefreshText()
    {
        _text.text = $"WAVE: {WaveManager.SharedInstance.Waves} / {WaveManager.SharedInstance.TotalWaves}";
    }
}
