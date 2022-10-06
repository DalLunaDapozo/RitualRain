using UnityEngine;
using System;

public class RitualManager : MonoBehaviour
{
    [SerializeField] private Candle[] candles;
    [SerializeField] private Skull[] skulls;

    [SerializeField] private Transform ritual_transform;
    [SerializeField] private GameObject key;


    public event EventHandler new_candle_is_on;

    private int number_of_candles_on;

    private void Awake()
    {
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].is_on_event += Check_If_Candle_On;
        }

        new_candle_is_on += Candle_Events;
    }

    private void Check_If_Candle_On(object sender, EventArgs e)
    {
        for (int i = 0; i < candles.Length; i++)
        {
            if (candles[i].is_on)
            {
                skulls[i].Turn_On();
                number_of_candles_on += 1;
                new_candle_is_on?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    private void Candle_Events(object sender, EventArgs e)
    {
        switch (number_of_candles_on)
        {
            case 1:

                Spawn_Key();

                break;
        }
    }
    private void Spawn_Key()
    {
        GameObject _key = Instantiate(key, ritual_transform.position, Quaternion.identity);
    }
}
