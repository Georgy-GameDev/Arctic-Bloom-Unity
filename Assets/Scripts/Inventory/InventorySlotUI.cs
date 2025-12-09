using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour//отображение одного слота в интерфейсе
{
    public Image iconImage;
    public TMP_Text countText;

    public void Set(ItemStack stack)
    {
        if (stack == null || stack.isEmpty)
        {
            iconImage.enabled = false;
            countText.text = "";
        }
        else
        {
            iconImage.enabled = true;
            iconImage.sprite = stack.item.icon;

            if (stack.count > 1)
                countText.text = stack.count.ToString();
            else
                countText.text = "";
        }
    }
}
