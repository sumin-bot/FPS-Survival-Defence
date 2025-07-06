using UnityEngine;

[System.Serializable]
public class ItemEffect 
{
    public string itemName;
    [Tooltip("HP, SP, DP, HUNGRY, THIRSTY, SATISFY�� �����մϴ�.")]
    public string[] part;
    public int[] num;
}

public class ItemEffectDatabase : MonoBehaviour
{
    [SerializeField]
    private ItemEffect[] itemEffects;

    [SerializeField]
    private StatusController statusController;
    [SerializeField]
    private WeaponManager weaponManager;

    private const string HP = "HP", SP = "SP", DP = "DP", HUNGRY = "HUNGRY", THIRSTY = "THIRSTY", SATISFY = "SATISFY";

    public void UseItem(Item _item)
    {
        if (_item.itemType == Item.ItemType.Equipment)
        {
            StartCoroutine(weaponManager.ChangeWeaponCoroutine(_item.weaponType, _item.itemName));
        }
        else if (_item.itemType == Item.ItemType.Used)
        {
            for (int x = 0; x < itemEffects.Length; x++)
            {
                if (itemEffects[x].itemName == _item.itemName)
                {
                    for (int y = 0; y < itemEffects[x].part.Length; y++)
                    {
                        switch (itemEffects[x].part[y])
                        {
                            case HP:
                                statusController.IncreaseHP(itemEffects[x].num[y]);
                                break;
                            case SP:
                                statusController.IncreaseSP(itemEffects[x].num[y]);
                                break;
                            case DP:
                                statusController.IncreaseDP(itemEffects[x].num[y]);
                                break;
                            case THIRSTY:
                                statusController.IncreaseThirsty(itemEffects[x].num[y]);
                                break;
                            case HUNGRY:
                                statusController.IncreaseHungry(itemEffects[x].num[y]);
                                break;
                            case SATISFY:
                                break;
                            default:
                                Debug.Log("�߸��� Status ����. HP, SP, DP, HUNGRY, THIRSTY, SATISFY�� �����մϴ�.");
                                break;

                        }
                        Debug.Log(_item.itemName + " �� ����߽��ϴ�.");
                        
                    }
                    return;
                }
            }
            Debug.Log("ItemEffectDatabase�� ��ġ�ϴ� itemName�� �����ϴ�.");
        }
    }
}
