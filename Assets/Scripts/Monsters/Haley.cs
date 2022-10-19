using UnityEngine;
using System;
using System.Collections;

public class Haley : MonoBehaviour
{

    [SerializeField] private float time_in_alert_mode;

    [SerializeField] private GameObject piano_sound;
    [SerializeField] private GameObject piano_music;

    [SerializeField] private PlayerController player;
    [SerializeField] private Transform ritual_pos;

    [SerializeField] private Transform piano_pos;

    private Animator anim;
    private float timer;

    public event EventHandler piano_monster_kill_player;

    private bool in_alert;
    private bool go_to_player;

    private bool kill_player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ShatteredGlass.glass_steped += React_To_Sound;
    }

    private void Start()
    {
        timer = time_in_alert_mode;
        transform.position = piano_pos.position;
    }
 
    private void Update()
    {
        if(!go_to_player) Timer();
        anim.SetBool("alert", in_alert);
    }

    private void FixedUpdate()
    {
        if (go_to_player && !kill_player)
        {
            Go_Towards_Player();
            CheckDistance();
        }   
    }

    private void Timer()
    {
        if (timer > 0) timer -= Time.deltaTime;
        else
        {
            in_alert = false;
            //piano_music.gameObject.SetActive(true);
            //piano_sound.gameObject.SetActive(false);
        }

    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 0.1f)
        {
            kill_player = true;
            anim.SetTrigger("kill");
            StartCoroutine(KillPlayer());
        }
    }

    private void Go_Towards_Player()
    {  
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .8f);
    }

    private void React_To_Sound(object sender, System.EventArgs e)
    {
        if(!go_to_player)
        {
            if (in_alert)
            {
                piano_monster_kill_player?.Invoke(this, EventArgs.Empty);
                go_to_player = true;
                anim.SetTrigger("go");
                return;
            }
            else
            {
                in_alert = true;
                timer = time_in_alert_mode;
                //piano_music.gameObject.SetActive(false);
                // piano_sound.gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator KillPlayer()
    {
        player.ToggleSprite(false);

        InputManager.GetInstance().DisableInput();

        InputManager.GetInstance().SetMovementToZero();

        SceneController.instance.PlayAnimation("fade_in", 0.35f);

        yield return new WaitForSeconds(SceneController.instance.anim.GetCurrentAnimatorStateInfo(0).length + 8f);

        player.TeleportPlayer(ritual_pos.position);
       
        transform.position = piano_pos.position;
        kill_player = false;
        go_to_player = false;
        in_alert = false;
        yield return new WaitForSeconds(2f);
        player.ToggleSprite(true);
        player.PlayAnimation("Spawn");
        SceneController.instance.PlayAnimation("fade_out", 1f);
        yield return new WaitForSeconds(.5f);
        
        InputManager.GetInstance().EnableInput();

    }
}
