using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public bool goFast;

    public GameObject Player;
    public GameObject Campfire;

    public Animator CampfireAnimator;
    public Animator PlayerAnimator;

    public Text GoFastToggleText;

    public void GoFast()
    {

        PlayerAnimator = Player.GetComponent<Animator>();
        CampfireAnimator = Campfire.GetComponent<Animator>();

        if (goFast == false)
        {
            Player.GetComponent<PlayerController>().moveSpeed = 10f;
            PlayerAnimator.speed = 2f;
            CampfireAnimator.speed = 2f;
            GoFastToggleText.text = "2x Speed";
            goFast = true;
        }
        else
        {
            Player.GetComponent<PlayerController>().moveSpeed = 5f;
            PlayerAnimator.speed = 1f;
            CampfireAnimator.speed = 1f;
            GoFastToggleText.text = "1x Speed";
            goFast = false;
        }
    }
    
}
