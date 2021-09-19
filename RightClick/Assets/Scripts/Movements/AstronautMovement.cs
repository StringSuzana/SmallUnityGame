using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AstronautMovement : MonoBehaviour
{
    private new Camera camera;
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Material dissolve;
    [SerializeField]
    private Transform startingPoint;
    private bool canMove;
    private Vector3 directionVector = Vector3.zero;
    private static float currentDissolve;

    [SerializeField]
    private SpaceGame game;

    private bool isAnimating = false;

    void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        currentDissolve = 1f;
        dissolve.SetFloat("_Fade", currentDissolve);
        print(transform.position);
    }

    void Update()
    {
        //var quaternionRotation = Quaternion.LookRotation(Vector3.forward, directionVector);
        if (Input.GetButtonDown(InputKeys.Fire))
        {
            if (EventSystem.current.IsPointerOverGameObject() != true)
            {
                Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
                directionVector = (mousePosition - transform.position) * moveSpeed * Time.deltaTime;
                rb.AddForce(directionVector);
            }

        }
    }

    public IEnumerator FadeAway()
    {
        var delay = 0.2f;

        while (dissolve.GetFloat("_Fade") > 0f)
        {
            isAnimating = true;
            dissolve.SetFloat("_Fade", currentDissolve);
            yield return new WaitForSecondsRealtime(delay);
            currentDissolve -= 0.1f;
        }
        isAnimating = false;
    }
    public IEnumerator FadeIn()
    {
        while (isAnimating)
        {
            yield return new WaitForSecondsRealtime(0.1f);
        }

        yield return new WaitForSecondsRealtime(2f);

        Quaternion orientation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.SetPositionAndRotation(startingPoint.position, orientation);
        transform.up = startingPoint.up;
      var delay = 0.2f;
        while (dissolve.GetFloat("_Fade") < 1f)
        {
            print("currentDissolve: " + currentDissolve);
            dissolve.SetFloat("_Fade", currentDissolve);
            yield return new WaitForSecondsRealtime(delay);
            currentDissolve += 0.1f;
        }
        Time.timeScale = 1f;
    }
    public void Die()
    {
        StartCoroutine(FadeAway());
        game.Died();
    }
}
public struct InputKeys
{
    public static string Fire = "Fire1";
}
