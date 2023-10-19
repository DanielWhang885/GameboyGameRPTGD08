using UnityEngine;
using TMPro;

public class NPC_UI_Manager : MonoBehaviour
{
    //UI Manager script for temporarily displaying enemy resource values

    public TextMeshProUGUI goldText, woodText, foodText, housingText;

    public static NPC_UI_Manager instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        goldText.text = $"Gold: {NPC_AI_Manager.instance.resources.x}";
        woodText.text = $"Wood: {NPC_AI_Manager.instance.resources.y}";
        foodText.text = $"Food: {NPC_AI_Manager.instance.foodAndHousing.x}";
        housingText.text = $"Housing: {NPC_AI_Manager.instance.foodAndHousing.y}";
    }
}
