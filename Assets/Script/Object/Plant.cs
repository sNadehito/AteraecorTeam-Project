using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Object
{
    private int water;
    private int fertilizer;
    private int plantGrowth; // plant stage
    [Header("Item interact with")]
    public string[] itemNeeded = new string[3];
    [Header("Plant Growth State")]
    // terdapat 5 pertumbuhan pada tanaman, membutuhkan 5 sprite untuk menunjukan setiap pertumbuhan.
    public Sprite[] sprite = new Sprite[5];
    public int[] growthCountNeeded = new int[5]; // indikasi berapa banyak nutrisi yang dubutuhkan untuk sekali tumbuh
    public int growthCounter;
    [Header("Pest Event")]
    private bool isPested = false;
    /// <summary>
    /// Grown mengecek setiap player melakukan aksi apakah tenaman memiliki water dan fertilizer yang cukup.
    /// setiap player melakukan aksi growthcounter akan bertambah dengan mengambil value dari water dan fertilizer.
    /// growthcounter = water + fertilizer
    /// </summary>
    public void Grown()
    {
        if(water > 0 && fertilizer > 0)
        {
            water--;
            fertilizer--;
            growthCounter++;
        }

        if(growthCountNeeded[plantGrowth] >= growthCounter)
        {
            // reset growth counter
            growthCounter = 0;
            // level up plant
            plantGrowth++;
            ChangePlantState(); // naikan stage dari plant
        }
    }

    public override void Interact()
    {
        // bila sedang terkena hama, maka pemain tidak dapat berinteraksi dengan tanaman
        if (isPested)
        {
            var itemname = inventory.itemSlots.ItemName;
            if (itemname == itemNeeded[2])
                IncreaseNutrition(itemname);
            // beritahu pemain bawha mereka membutuhkan pesticide
            Debug.Log("There is pest on the plant!!, Must get rid the pest first!!");
        }
        else if (CheckItem())
        {
            IncreaseNutrition(inventory.itemSlots.ItemName);
            inventory.RemoveItem();
        }
        else
        {
            // beritahu pemain apa yang pemain butuhkan
            if(water > fertilizer)
            {
                Debug.Log("Neeed Fertilizer!!");
            }
            else
            {
                Debug.Log("Need Water");
            }
        }
        // lakukan cek pada pertumbuhan tanaman
        Grown();
            
    }

    public bool CheckItem()
    {
        foreach (string s in itemNeeded)
        {
            if (inventory.HasItem(s))
                return true;
        }
        return false;
    }
    /// <summary>
    /// Menambahkan counter pada parameter <para name="water"/> atau <para name="fertilizer"/>
    /// tergantung pada item yang sedang dibawa pemain dalam inventory
    /// </summary>
    /// <param name="s"></param>
    private void IncreaseNutrition(string s)
    {
        if (s == itemNeeded[0]) // "Bucked With Water"
            water++;
        else if (s == itemNeeded[1]) // "fertilizer"
            fertilizer++;
        else if (s == itemNeeded[2]) // "pesticide"
            isPested = false;
        Debug.LogWarning("Nutrition Counter Error, Cannot find : " + s);
    }

    /// <summary>
    /// ketika stage dari game naik, set ulang value dari plant.
    /// </summary>
    private void ChangePlantState()
    {
        // ganti sprite dengan yang baru
        ChangeSprite();
        // atur ulang value dari plant
        ResetPlantState();
    }

    private void ResetPlantState()
    {
        water = 0;
        fertilizer = 0;
        growthCounter = 0;

        isPested = false;
    }

    private void ChangeSprite()
    {
       
    }
}
