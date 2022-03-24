using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmo : MonoBehaviour
{
    public int clipSize = 30;
    public int extraAmmo = 120;
    public int currentAmmo;
    public AudioClip magInSound;
    public AudioClip magOutSound;
    public AudioClip releaseSlideSound;


    void Start()
    {
        currentAmmo = clipSize;

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) Reload();
    }
    public void Reload()
    {
        if (extraAmmo >= clipSize)
        {
            int ammoToReload = clipSize - currentAmmo;
            extraAmmo -= ammoToReload;
            currentAmmo += ammoToReload;
        }
        else if (extraAmmo > 0)
        {
            if (extraAmmo + currentAmmo > clipSize)
            {
                int leftOverAmmo = extraAmmo + currentAmmo - clipSize;
                extraAmmo = leftOverAmmo;
                currentAmmo = clipSize;
            }
            else
            {
                currentAmmo += extraAmmo;
                extraAmmo = 0;
            }
        }
    }
}
