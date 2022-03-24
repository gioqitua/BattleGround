using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActionStateManager : MonoBehaviour
{
    [HideInInspector] public ActionBaseState currentState;
    public ReloadState Reload = new ReloadState();
    public DefaultState Default = new DefaultState();
    public GameObject currentWeapon;
    [HideInInspector] public WeaponAmmo ammo;
    [HideInInspector] public Animator anime;
    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;
    AudioSource audioSource;
    void Start()
    {
        SwitchState(Default);
        ammo = currentWeapon.GetComponent<WeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        anime = GetComponent<Animator>();

    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(ActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }
    public void MagUot()
    {
        audioSource.PlayOneShot(ammo.magOutSound);
        
    }
    public void MagIn()
    {
        audioSource.PlayOneShot(ammo.magInSound);

    }
    public void ReleaseSlide()
    {
        audioSource.PlayOneShot(ammo.releaseSlideSound);

    }
}
