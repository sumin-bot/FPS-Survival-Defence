using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Base;

    [SerializeField]
    private Text txt_ItemName;
    [SerializeField]
    private Text txt_ItemDesc;
    [SerializeField]
    private Text txt_ItemHowToUsed;

    public void ShowToolTip(Item _item)
    {
        go_Base.SetActive(true);

        txt_ItemName.text = _item.itemName;
        txt_ItemDesc.text = _item.itemDesc;

        if (_item.itemType == Item.ItemType.Equipment)
            txt_ItemHowToUsed.text = "우클릭 - 장착";
        else if (_item.itemType == Item.ItemType.Used)
            txt_ItemHowToUsed.text = "우클릭 - 먹기";
        else
            txt_ItemHowToUsed.text = "";
    }

    public void HideToolTip()
    {
        go_Base.SetActive(false);
    }
}
