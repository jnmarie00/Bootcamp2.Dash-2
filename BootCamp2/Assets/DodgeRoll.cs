using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeRoll : MonoBehaviour
{
    private Movement2D move;
    bool roll = false;
    public int cooldownTime = 3;
    [SerializeField] float boost = 30f;

    // Start is called before the first frame update
    void Start()
    {
        move = GetComponent<Movement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode.Mouse1))
        {
            Debug.Log("rightClick");
            
            if (!roll)
            {
                Debug.Log("roll was false");
                roll = true;
                Dodge();
            }
        }
    }

    void Dodge()
    {
        move.Dodger(boost);
        StartCoroutine(CoolDown());
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(.1f);

        float Sd = boost - (boost * 2);

        move.Dodger(sd);
        Debug.Log("coroutine started");

        yield return new WaitForSeconds(cooldownTime);
    }
}
