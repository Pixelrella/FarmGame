using UnityEngine;

public class GrowingCrop : MonoBehaviour
{
    [SerializeField] private GameObject waterButton;
    [SerializeField] private GameObject harvestButton;

    [SerializeField] private Crop crop;

    private bool isGrowing;
    private float timeSinceStart;
    private bool needsHarvest;

    private void Awake()
    {
        waterButton.SetActive(true);
        harvestButton.SetActive(false);
    }

    public void StartGrowing() 
    {
        if (needsHarvest)
            return;

        if (isGrowing)
            return;

        isGrowing = true;

        waterButton.SetActive(false);
    }

    private void Update()
    {
        if (needsHarvest)
            return;

        if (!isGrowing)
            return;

        timeSinceStart += Time.deltaTime;

        if (timeSinceStart >= crop.TimeToYield) 
        {
            needsHarvest = true;
            isGrowing = false;

            harvestButton.SetActive(true);
            timeSinceStart = 0;
        }
    }

    public void Harvest() 
    {
        if(!needsHarvest)
            return;

        needsHarvest = false;

        harvestButton.SetActive(false);
        waterButton.SetActive(true);
    }

}
