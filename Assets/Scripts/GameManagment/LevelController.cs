using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    private int slotCounter;
    [SerializeField] private float multiplier;
    private const float MULTIPLIER_INCREASER = 0.1f;
    private const int SLOTS_COUNT = 5;
    private Transform[] slots;

    public delegate void OnMultiplierIncrease(float multiplier);
    public static event OnMultiplierIncrease MultiplierIncreaseObserver;
    // Use this for initialization
    void Start () {
        slotCounter = 0;
        slots = new Transform[SLOTS_COUNT];
        EndSlotController.EndSlotFiledObserver+=CheckRoundEnded;

    }
	
    private void CheckRoundEnded(Transform slot)
    {
        MakeSlotsArray(slot);

        slotCounter++;
        if (slotCounter == SLOTS_COUNT)
        {
            Debug.Log("Round ends");
            IncreaseMultiplier();
            FreeAllSlots();

            slotCounter = 0;
        }
    }

    private void IncreaseMultiplier()
    {
        MultiplierIncreaseObserver(MULTIPLIER_INCREASER);
    }

    private void FreeAllSlots()
    {
        for (int i = 0; i < SLOTS_COUNT; i++)
        {
            slots[i].GetChild(0).gameObject.SetActive(false);
        }
    }

    private void MakeSlotsArray(Transform slot)
    {
        if (slots[slotCounter] == null)
            slots[slotCounter] = slot;
    }
}
