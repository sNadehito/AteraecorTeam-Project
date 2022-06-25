using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Inventory hanya terdapat 1 slot
    /// Pemain harus mengganti / menukar inventory kalau ingin membawa benda lain
    /// </summary>

    // Struct dari inventory ini untuk mempermudah unity editor, ignore saja dan lanjut ke bawah
    [System.Serializable]
    public struct ItemSlots
    {
        [SerializeField]
        private bool isFull;
        // Property di C#
        public bool IsFull
        {
            get { return isFull; }
            set { isFull = value; }
        }

        [SerializeField]
        private GameObject slot;
        public GameObject Slot
        {
            get { return slot; }
            set { slot = value; }
        }

        [SerializeField]
        private string itemName;
        public string ItemName
        {
            get { return itemName; }
            set { itemName = value; }
        }
    }
    // Struct untuk representasi slot di inventory
    public ItemSlots itemSlots;
    public Sprite baseSprite;

    /// <summary>
    /// mengecek apakah kita memeiliki item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <returns>  true, jika </returns>
    public bool HasItem(string itemName)
    {
        if(itemSlots.ItemName == itemName)
            return true;
        return false;
    }

    /// <summary>
    /// Hapus item dengan nama <paramref name="itemName"/>
    /// </summary>
    /// <returns>
    /// True jika item berhasil dihapus, false jika item tidak ditemukan.
    /// </returns>
    /// <param name="itemName"></param>

    public bool RemoveItem()
    {
        if(itemSlots.ItemName != null)
        {
            itemSlots.IsFull = false;
            itemSlots.ItemName = null;
            // Hapus UI dan game object pada itemSlot
            itemSlots.Slot.GetComponent<Image>().sprite = baseSprite;
            return true;
        }
        Debug.LogWarning("item dengan nama : " + itemSlots.ItemName + " tidak ditemukan");
        return false;
    }

    /// <summary>
    /// Update itemSlot dengan item yang terbaru
    /// </summary>

    public void UpdateItem(Sprite sprite, string itemName)
    {
        // kalau itemSlot sudha terisi, maka ganti item slot dengan yang baru
        if(itemSlots.IsFull == true)
        {
            RemoveItem();
        }
        itemSlots.Slot.GetComponent<Image>().sprite = sprite;
        itemSlots.ItemName = itemName;
    }
}
