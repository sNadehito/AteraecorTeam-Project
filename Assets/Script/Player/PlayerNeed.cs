using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeed : MonoBehaviour
{
    public GameObject itemNeededUI;
    public GameObject bucketNeededUI;
    public Vector3 playerOffset = new Vector3(0, 0.6f, 0);

    [Header("Bucket")]
    public GameObject well;
    public Vector3 wellOffset;
    
    [Header("Plant")]
    public GameObject plant;
    public Vector3 plantOffset;

    [Header("ItemUI")]
    public GameObject bucketPrefabUI;
    public GameObject fertilizerPrefabUI;
    public GameObject pesticidePrefabUI;
    public GameObject waterPrefabUI;

    private void FixedUpdate()
    {
        if (bucketNeededUI)
        {
            bucketNeededUI.transform.position = transform.position + playerOffset;
            if (itemNeededUI)
            {
                itemNeededUI.SetActive(false);
            }            
        }
        if (itemNeededUI)
        {
            itemNeededUI.transform.position = transform.position + playerOffset;
        }
    }

    public void showObjectNeeded(string objectNeed)
    {
        if (itemNeededUI && objectNeed != "Bucket")
        {
            Destroy(itemNeededUI);
        }
        //if (!itemNeededUI)
        //{
        if (objectNeed == "Fertilizer")
        {
            itemNeededUI = Instantiate(fertilizerPrefabUI, plant.transform.position + plantOffset, Quaternion.identity);
        }
        else if (objectNeed == "Pesticide")
        {
            itemNeededUI = Instantiate(pesticidePrefabUI, plant.transform.position + plantOffset, Quaternion.identity);
        }
        else if (objectNeed == "Water")
        {
            itemNeededUI = Instantiate(waterPrefabUI, plant.transform.position + plantOffset, Quaternion.identity);
        }
        //}
        if (!bucketNeededUI)
        {
            if (objectNeed == "Bucket")
            {
                bucketNeededUI = Instantiate(bucketPrefabUI, well.transform.position + wellOffset, Quaternion.identity);
            }
        }
        
    }

    public void destroyItemUI()
    {
        if (itemNeededUI)
        {
            Destroy(itemNeededUI);
        }
    }
    public void destroyBucketUI()
    {
        if (bucketNeededUI)
        {
            Destroy(bucketNeededUI);
            if (itemNeededUI)
            {
                itemNeededUI.SetActive(true);
            }
        }
    }
}
