using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    public void PlayerDamaged()
    {
        animator.Play("morir_hades");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MorirAquiles()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
