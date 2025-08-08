using UnityEngine;

public class GameFacade : MonoBehaviour
{
    private InventorySystem inventorySystem;
    private QuestSystem questSystem;
    private SoundSystem soundSystem;

    private void Awake()
    {
        inventorySystem = GetComponent<InventorySystem>();
        questSystem = GetComponent<QuestSystem>();
        soundSystem = GetComponent<SoundSystem>();


        if(inventorySystem == null)
        {
            inventorySystem = gameObject.AddComponent<InventorySystem>();
        }
        if (questSystem == null)
        {
            questSystem = gameObject.AddComponent<QuestSystem>();
        }
        if (soundSystem == null)
        {
            soundSystem = gameObject.AddComponent<SoundSystem>();
        }
    }

    public void ItemEvent(int index, string itemName)
    {
        if (index == 0)
            inventorySystem.AddItem(itemName);
        else if (index == 1)
            inventorySystem.HasItem(itemName);
        else if (index == 2)
            inventorySystem.RemoveItem(itemName);
    }

    public void QuestEvent(int index, string questName)
    {
        if (index == 0)
            questSystem.StartQuest(questName);
        else if (index == 1)
            questSystem.HasQuest(questName);
        else if (index == 2)
            questSystem.CompleteQuest(questName);
    }

    public void SoundEvent(int index, string soundName)
    {
        if (index == 0)
            soundSystem.StartSound(soundName);
        else if (index == 1)
            soundSystem.PauseSound(soundName);
        else if (index == 2)
            soundSystem.StopSound(soundName);
    }
}
