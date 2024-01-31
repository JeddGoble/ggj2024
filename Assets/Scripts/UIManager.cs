using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;
    [SerializeField] private TextMeshProUGUI volunteersText;
    [SerializeField] private TextMeshProUGUI winText;

    public void UpdateCounter(int count)
    {
        counterText.text = count.ToString();
    }

    public void LevelWin() {
        counterText.gameObject.SetActive(false);
        volunteersText.gameObject.SetActive(false);
        winText.gameObject.SetActive(true);
    }
}
