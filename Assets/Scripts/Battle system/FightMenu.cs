using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightMenu : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI uiHealthText;

    [SerializeField]
    private Slider uiHealth;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiMessage;

    [SerializeField]
    private GameObject fightMenu;

    [SerializeField]
    private TMPro.TextMeshProUGUI uiAPText;
    
    [SerializeField]
    private TMPro.TextMeshProUGUI uiMPText;

    private Player player;


    public void ShowFightMenu()
    {
        fightMenu.SetActive(true);
    }

    public void HideFightMenu()
    {
        fightMenu.SetActive(false);
    }

    public void SetMessage(string text)
    {
        uiMessage.text = text;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePoints()
    {

    }

    private void FixedUpdate()
    {
        if(fightMenu.activeSelf)
        {
            Stats stats = player.Stats;
            uiHealthText.text = stats.Health.ToString();
            uiHealth.maxValue = stats.Health;
            uiHealth.value = stats.Health;

            uiAPText.text = $"нд: {stats.ActionPoints}";
            uiMPText.text = $"но: {stats.MovePoints}";
        }
    }
}
