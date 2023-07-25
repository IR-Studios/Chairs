using System.Collections;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [Header("Shotgun Properties")]
    public int damage = 10;
    public float range = 50f;
    public int pelletsCount = 8;
    public float spreadAngle = 15f;
    public int maxAmmo = 8;
    public float reloadTime = 2f;
    public float fireRate = 1f;

    [Header("Components")]
    public Transform shootPoint;
    public ParticleSystem muzzleFlash;
    public GameObject hitEffectPrefab;
    public Transform weaponModel;
    public Animation weaponAnimation;

    [Header("Sway Settings")]
    public bool isWeaponSwayEnabled = true;
    public float swayAmount = 0.1f;
    public float swaySpeed = 2f;

    [Header("Recoil Settings")]
    public float recoilKickBack = 0.5f;
    public float recoilKickUp = 30f;

    [Header("ADS Settings")]
    public Transform adsPosition;
    public float adsSpeed = 5f;

    [Header("Camera Shake Settings")]
    public CameraShake cameraShake;

    public bool isDrawn;


    private Quaternion initialWeaponRotation;
    private Vector3 initialWeaponPosition;

    private int currentAmmo;
    private bool isReloading;
    private float nextFireTime;
    private bool isAimingDownSights = false;
    private bool isADSActive = false;
    public bool canFire = true;
    private Vector3 originalWeaponPosition;

    private AudioSource audioSource;

    private void Start()
    {
        currentAmmo = maxAmmo;
        audioSource = GetComponent<AudioSource>();

        initialWeaponPosition = weaponModel.localPosition;
        initialWeaponRotation = weaponModel.localRotation;
        originalWeaponPosition = initialWeaponPosition;
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime && canFire)
        {
            if (currentAmmo > 0)
            {
                Shoot();
                nextFireTime = Time.time + 1f / fireRate;
            }
            else
            {
                // Play empty ammo sound or provide feedback to the player
            }
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && !isADSActive)
        {
            StartCoroutine(Reload());
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isADSActive = true;
            StartCoroutine(MoveWeaponToTargetPosition(adsPosition.localPosition, adsSpeed));
        }
        else if (Input.GetButtonUp("Fire2"))
        {
            isADSActive = false;
            StartCoroutine(MoveWeaponToTargetPosition(originalWeaponPosition, adsSpeed));
        }


        if (isWeaponSwayEnabled)
        {
            float swayX = -Input.GetAxis("Mouse X") * swayAmount;
            float swayY = -Input.GetAxis("Mouse Y") * swayAmount;
            Vector3 targetWeaponPosition = isADSActive ? adsPosition.localPosition + new Vector3(swayX, swayY, 0f) : initialWeaponPosition + new Vector3(swayX, swayY, 0f)  ;
            weaponModel.localPosition = Vector3.Lerp(weaponModel.localPosition, targetWeaponPosition, Time.deltaTime * swaySpeed);
        }
    }

    private void Shoot()
    {
        audioSource.Play();
        muzzleFlash.Play();



        Vector3 recoilKickDirection = isADSActive ? -Vector3.forward : Vector3.back;
        weaponModel.localPosition -= recoilKickDirection * recoilKickBack;

        currentAmmo--;

        for (int i = 0; i < pelletsCount; i++)
        {
            float spreadAngleRad = Mathf.Deg2Rad * (spreadAngle * 0.5f);
            float randomRadius = Random.Range(0f, spreadAngleRad);
            float randomAngle = Random.Range(0f, 2f * Mathf.PI);

            float normalizedRadius = Mathf.Sqrt(randomRadius);
            float x = normalizedRadius * Mathf.Cos(randomAngle);
            float y = normalizedRadius * Mathf.Sin(randomAngle);
            Vector3 coneDirection = -shootPoint.right + shootPoint.up * x + shootPoint.forward * y;

            RaycastHit hit;
            if (Physics.Raycast(shootPoint.position, coneDirection, out hit, range))
            {
                Vector3 spawnLocation = hit.point + hit.normal * 0.05f;
                GameObject hitEffect = Instantiate(hitEffectPrefab, spawnLocation, Quaternion.LookRotation(-hit.normal));
                hitEffect.transform.parent = hit.transform;

                if (hit.transform.CompareTag("Chair"))
                {
                    ChairAI AI = hit.transform.GetComponent<ChairAI>();
                    AI.health = AI.health - damage;
                    if (AI.health <= 0) 
                    {
                        AI.onDeath(shootPoint, 3f, 20f);
                    }
                   
                }

                if (hit.transform.CompareTag("Piece"))
                {   
                    ChairAI AI = hit.transform.GetComponentInParent<ChairAI>();
                    Rigidbody rb = AI.returnRB(hit.transform.gameObject);

                    rb.isKinematic = false;

                    Vector3 explosionDirection = rb.transform.position - shootPoint.position;
                    rb.AddForce(explosionDirection.normalized * 10f, ForceMode.Impulse);
                }
            }
        }
        Quaternion kickupRotation = Quaternion.Euler(-recoilKickUp, 0f, 0f);
        weaponModel.localRotation = kickupRotation * weaponModel.localRotation;

        StartCoroutine(ResetRotation());
        cameraShake.Shake();
        StartCoroutine(pumpShotgun());
    }

    public IEnumerator pumpShotgun() 
    {
        yield return new WaitForSeconds(0.5f);
        weaponAnimation.Play("Shotgun_Pump_Temp");  
    }

    private IEnumerator MoveWeaponToTargetPosition(Vector3 targetPosition, float speed)
    {
        Vector3 startPosition = weaponModel.localPosition;
        Quaternion startRotation = weaponModel.localRotation;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            weaponModel.localPosition = Vector3.Lerp(startPosition, targetPosition, t);
            weaponModel.localRotation = Quaternion.Lerp(startRotation, adsPosition.localRotation, t);
            yield return null;
        }
    }

    private IEnumerator ResetRotation()
    {
        yield return new WaitForSeconds(0.1f);

        while (Quaternion.Angle(weaponModel.localRotation, initialWeaponRotation) > 0.1f)
        {
            weaponModel.localRotation = Quaternion.Lerp(weaponModel.localRotation, initialWeaponRotation, Time.deltaTime * 10f);
            yield return null;
        }
    }


    private IEnumerator Reload()
    {
        isReloading = true;
        audioSource.Play();
        weaponAnimation.Play("Shotgun_Reload_Temp");
        yield return new WaitForSeconds(reloadTime);
        weaponAnimation.Play("Shotgun_Reload_Return_Temp");
        currentAmmo = maxAmmo;
        isReloading = false;
    }

    public void ShotgunDraw() 
    {
        weaponAnimation.Play("Shotgun_Draw_Temp");    
        isDrawn = true;
    }

    public void ShotgunPutAway() 
    {
        weaponAnimation.Play("Shotgun_PutAway_Temp");
        isDrawn = false;
    }

    public void DisableShotgun() 
    {
        this.gameObject.SetActive(false);
    }

    public void FirstDraw() 
    {
        weaponAnimation.Play("Shotgun_FirstPickUp_Temp");
        isDrawn = true;
    }
}
