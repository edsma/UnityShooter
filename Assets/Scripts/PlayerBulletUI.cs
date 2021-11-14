using UnityEngine;
using TMPro;
public class PlayerBulletUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public PlayerShooting targetShooting;
    private int maxAmounBullet;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        maxAmounBullet = GunConfiguration.sharedInstance.maxAmountBullet;
    }

    private void Update()
    {
        _text.text = $"{targetShooting.bulletsAmount}/{maxAmounBullet}";
    }
}
