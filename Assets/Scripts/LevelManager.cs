using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("經驗值")]
    public Image imgExp;
    [Header("文字等級")]
    public TextMeshProUGUI textLv;
    [Header("文字經驗值")]
    public TextMeshProUGUI textExp;
    [Header("升級面板")]
    public GameObject goLvUp;
    [Header("技能 1~3")]
    public GameObject[] goSkillUI;
    
    /// <summary>
    /// 0 吸取經驗
    /// 1 啤酒攻擊
    /// 2 啤酒間隔
    /// 3 玩家血量
    /// 4 移動速度
    /// </summary>
    [Header("技能資料陣列")]
    public DataSkill[] dataSkills;

    public List<DataSkill> randomSkill = new List<DataSkill>();

    private int lv = 1;
    private float exp = 0;

    public float[] expNeeds = { 100, 200, 300 };

    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            // print($"<color=#ff6699>i 的值：{i}</color>");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // print($"<color=#6699ff>{collision.name} </color>");

        if (collision.name.Contains("經驗值"))
        {
            collision.GetComponent<ExpSystem>().enabled = true;
        }
    }

    public void AddExp(float exp)
    {
        this.exp += exp;

        if (this.exp > expNeeds[lv - 1])
        {
            this.exp -= expNeeds[lv - 1];
            lv++;
            textLv.text = lv.ToString();
            LevelUp();
        }

        textExp.text = this.exp + " / " + expNeeds[lv - 1];
        imgExp.fillAmount = this.exp / expNeeds[lv - 1];
    }

    private void LevelUp()
    {
        goLvUp.SetActive(true);
        Time.timeScale = 0;

        randomSkill = dataSkills.Where(skill => skill.skillLv < 5).ToList();
        randomSkill = randomSkill.OrderBy(skill => Random.Range(0, 999)).ToList();

        for (int i = 0; i < 3; i++)
        {
            goSkillUI[i].transform.Find("技能名稱").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillName;
            goSkillUI[i].transform.Find("技能描述").GetComponent<TextMeshProUGUI>().text = randomSkill[i].skillDescription;
            goSkillUI[i].transform.Find("技能等級").GetComponent<TextMeshProUGUI>().text = "Lv" + randomSkill[i].skillLv;
            goSkillUI[i].transform.Find("技能圖片").GetComponent<Image>().sprite = randomSkill[i].skillPicture;
        }
    }

    [ContextMenu("產生經驗值需求資料")]
    private void ExpNeeds()
    {
        expNeeds = new float[100];

        for (int i = 0; i < 100; i++)
        {
            expNeeds[i] = (i + 1) * 100;
        }
    }

    public void ClickSkillButton(int indexSkill)
    {
        // print($"<color=#6699ff>點擊技能編號：{indexSkill}</color>");
        randomSkill[indexSkill].skillLv++;
        goLvUp.SetActive(false);
        Time.timeScale = 1;
    }
}
