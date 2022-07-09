using UnityEngine;

public class LighterController : MonoBehaviour
{
    [SerializeField] private GameObject fireSprite;
    
    public static bool lightIsOn;

    private void Start()
    {
        CheckIfOn(fireSprite);
    }

    private void Update()
    {
        SwitchLightBool();
        TurnLightSpriteOnOff();
    }

    private void CheckIfOn(GameObject fire)
    {
        if (fire.activeSelf)
            lightIsOn = true;
        else
            lightIsOn = false;
    }

    private void TurnLightSpriteOnOff()
    {
        if (lightIsOn)
            fireSprite.SetActive(true);
        else
            fireSprite.SetActive(false);
    }

    private void SwitchLightBool()
    {
        if (InputManager.GetInstance().GetLighterPressed())
        { 
            if (lightIsOn)
                lightIsOn = false;
            else
                lightIsOn = true;
        }
    }
}
