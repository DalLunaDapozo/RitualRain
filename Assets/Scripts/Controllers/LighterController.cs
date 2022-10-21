using UnityEngine;

public class LighterController : MonoBehaviour
{
    [SerializeField] private GameObject fireSprite;
    
    public static bool lightIsOn;

    private void Start()
    {
        fireSprite.gameObject.SetActive(false);
        CheckIfOn(fireSprite);
    }

    private void Update()
    {
        SwitchLightBool();
        CheckIfOn(fireSprite);
    }

    private void CheckIfOn(GameObject fire)
    {
        if (fire.activeSelf)
            lightIsOn = true;
        else
            lightIsOn = false;
    }

    public void SetLighter(bool a)
    {
        fireSprite.SetActive(a);
    }

    private void SwitchLightBool()
    {
        if (InputManager.GetInstance().GetLighterPressed())
        {
            if (fireSprite.activeSelf) SetLighter(false);
            else SetLighter(true);
        }
    }
}
