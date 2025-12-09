using UnityEngine;
using System;

[System.Serializable]
public class ItemStack//одна ячейка инвентаря
{
    public ItemData item;
    public int count;

    public bool isEmpty
    {
        get { return item == null || count <= 0; }
    }

    public void Clear()
    {
        item = null; count = 0;
    }
}
public class Inventory : MonoBehaviour// логика инвентаря
{
    public static Inventory Instance {  get; private set; }

    public ItemStack[] slots = new ItemStack[8];//8 слотов

    public int activeIndex = 0;//какой слот активный

    public event Action OnChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new ItemStack();
        }
    }

    public void SetActive(int index)
    {
        activeIndex = Mathf.Clamp(index, 0, slots.Length - 1);
        OnChanged?.Invoke();
    }

    public ItemStack GetActive()
    {
        return slots[activeIndex];
    }

    public bool Add(ItemData item, int amount = 1)
    {
        if (item == null || amount <= 0)
            return false;

        for (int i = 0; i < slots.Length && amount > 0; i++)
        {
            ItemStack s = slots[i];

            if (s.item == item && s.count < item.maxStack)
            {
                int free = item.maxStack - s.count;
                int toAdd = Mathf.Min(amount, free);

                s.count += toAdd;
                amount -= toAdd;
            }
        }

        for (int i = 0; i < slots.Length && amount > 0; i++)
        {
            ItemStack s = slots[i];

            if (s.isEmpty)
            {
                int toAdd = Mathf.Min(amount, item.maxStack);

                s.item = item;
                s.count = toAdd;

                amount -= toAdd;
            }
        }

        OnChanged?.Invoke();

        return amount == 0;
    }

    public bool RemoveFromSlot(int index, int amount = 1)
    {
        if (index < 0 || index >= slots.Length) return false;

        ItemStack s = slots[index];

        if (s.isEmpty || amount <= 0)
        {
            return false;
        }

        s.count -= amount;

        if (s.count <= 0)
        {
            s.Clear();
        }

        OnChanged?.Invoke();
        return true;
    }

    public bool RemoveFromActive(int amount = 1)
    {
        return RemoveFromSlot(activeIndex, amount);
    }
}
