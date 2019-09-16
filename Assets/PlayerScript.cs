using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public float tilt;
    public GameObject LazerShot;
    public Transform PrimaryWeapon;
    public GameObject ShipExplosion;
    public GameObject SmallLazerShot;
    public Transform SecondaryWeaponOne, SecondaryWeaponTwo;

    public int primaryBulletSpeed = 65;
    public int secondaryBulletSpeed = 80;

    public float shotDelay;
    private float nextPrimaryShot, nextSecondaryShot;

    public UnityEngine.UI.Text scoreText;
    private static int score = 0;

    public float xMin, xMax, zMin, zMax;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextPrimaryShot)
        {
            //  On LMB pressed
            PrimaryShoot();
        }
        if (Input.GetButton("Fire2") && Time.time > nextSecondaryShot)
        {
            //  On RMB pressed
            SecondaryShoot();
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Rigidbody ship = GetComponent<Rigidbody>();
        ship.velocity = new Vector3(moveHorizontal * speed, 0, moveVertical * speed);
        ship.rotation = Quaternion.Euler(0, 0, moveHorizontal * -tilt);

        //  borders for ship flight
        float xPosition = Mathf.Clamp(ship.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(xPosition, ship.position.y, zPosition);
    }

    private void PrimaryShoot()
    {
        GameObject shot = Instantiate(LazerShot, PrimaryWeapon.position, Quaternion.identity);
        shot.GetComponent<Rigidbody>().velocity = Vector3.forward * primaryBulletSpeed;
        nextPrimaryShot = Time.time + shotDelay;
    }
    private void SecondaryShoot()
    {
        GameObject leftShot = Instantiate(SmallLazerShot, SecondaryWeaponOne.position, Quaternion.Euler(0, 5, 0));
        GameObject rightShot = Instantiate(SmallLazerShot, SecondaryWeaponTwo.position, Quaternion.Euler(0, -5, 0));
        leftShot.GetComponent<Rigidbody>().velocity = new Vector3(.05f, 0, 1) * secondaryBulletSpeed;
        rightShot.GetComponent<Rigidbody>().velocity = new Vector3(-.05f, 0, 1) * secondaryBulletSpeed;
        nextSecondaryShot = Time.time + shotDelay / 4;
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }
}
