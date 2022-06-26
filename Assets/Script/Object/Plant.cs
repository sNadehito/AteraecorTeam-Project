using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Object
{
    private int water = 0;
    private int fertilizer = 0;
    private int plantGrowth = 0; // plant stage
    public PlayerNeed playerNeed;
    [Header("Item interact with")]
    public string[] itemNeeded = new string[3];
    [Header("Plant Growth State")]
    // terdapat 5 pertumbuhan pada tanaman, membutuhkan 5 sprite untuk menunjukan setiap pertumbuhan.
    public Sprite[] plantSprite = new Sprite[5];
    [Header("Glitch Need")]
    public Sprite[] plantSpriteGlitch = new Sprite[5];
    public int[] growthCountNeeded = new int[5]; // indikasi berapa banyak nutrisi yang dubutuhkan untuk sekali tumbuh
    public int growthCounter;
    [Header("Event Channel")]
    public VoidEventChannelSO _CheckEventChannel;
    [Header("Pest Event")]
    public bool isPested = false;

    /// <summary>
    /// 
    /// </summary>
    public int PlantGrowth
    {
        get { return plantGrowth; }
        set { plantGrowth = value; }
    }

    private void Awake()
    {
        _GlitchEvent.onEventRaised += Glitch;
    }
    /// <summary>
    /// Grown mengecek setiap player melakukan aksi apakah tenaman memiliki water dan fertilizer yang cukup.
    /// setiap player melakukan aksi growthcounter akan bertambah dengan mengambil value dari water dan fertilizer.
    /// growthcounter = water + fertilizer
    /// </summary>
    public void Grown()
    {
        Debug.Log("Growth; water : "+water+"; fertilizer : "+fertilizer);
        if(water > 0 && fertilizer > 0)
        {
            water--;
            fertilizer--;
            growthCounter++;
        }

        if(growthCountNeeded[plantGrowth] <= growthCounter)
        {
            // reset growth counter
            growthCounter = 0;
            // level up plant
            PlantGrowth++;
            // PlantGrouwht()
            ChangePlantState(); // naikan stage dari plant
        }
    }

    public override void Interact()
    {
        _CheckEventChannel.RaiseEvent();
        // bila sedang terkena hama, maka pemain tidak dapat berinteraksi dengan tanaman
        if (isPested)
        {
            var itemname = inventory.itemSlots.ItemName;
            if (itemname == itemNeeded[2])
            {
                IncreaseNutrition(itemname);
                inventory.RemoveItem();
                playerNeed.destroyItemUI();
            }
            else
            {
                // beritahu pemain bawha mereka membutuhkan pesticide
                playerNeed.showObjectNeeded("Pesticide");
                Debug.Log("There is pest on the plant!!, Must get rid the pest first!!");
            }
        }
        else if (CheckItem())
        {
            IncreaseNutrition(inventory.itemSlots.ItemName);
            inventory.RemoveItem();
            playerNeed.destroyItemUI();
        }
        else
        {
            // beritahu pemain apa yang pemain butuhkan
            if(water > fertilizer)
            {
                playerNeed.showObjectNeeded("Fertilizer");
                Debug.Log("Neeed Fertilizer!!");
            }
            else
            {
                playerNeed.showObjectNeeded("Water");
                Debug.Log("Need Water");
            }
        }
        // lakukan cek pada pertumbuhan tanaman
        Grown();
            
    }
    public override void Glitch()
    {
        StartCoroutine(Glitching());
    }

    IEnumerator Glitching()
    {
        var counter = 0;
        while (true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = plantSpriteGlitch[plantGrowth];
            yield return new WaitForSeconds(0.1f);
            //gameObject.GetComponent<SpriteRenderer>().sprite = objectSprite;
            yield return new WaitForSeconds(0.1f);
            counter++;
            if (counter >= 5)
                break;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = plantSprite[plantGrowth];
        yield return null;
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
        else
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
        gameObject.GetComponent<SpriteRenderer>().sprite = plantSprite[plantGrowth];
    }

    /// <summary>
    /// Subcribe dan Unsubscribe channel
    /// </summary>
    /// <param name="other"></param>
    private void OnDestroy()
    {
        _GlitchEvent.onEventRaised -= Glitch;
        _InteractionEvent.onEventRaised -= Interact; // unsubscribe channel
    }

}
