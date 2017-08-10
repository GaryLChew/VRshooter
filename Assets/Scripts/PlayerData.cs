using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    public int maxHP;
    public int HP;

    public int ammoCount;

    // Use this for initialization
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void hurt(int dmg)
    {
        HP -= dmg;
    }

    public void heal(int amount)
    {
        HP += amount;
        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }

    public void addAmmo(int amt)
    {
        ammoCount += amt;
    }

    public int takeAmmo(int amt)
    {
        if (ammoCount==0)
        {
            return 0;
        }

        if (amt>ammoCount)
        {
            int store = ammoCount;
            ammoCount = 0;
            return store;
        }

        ammoCount -= amt;
        return amt;

    }
}
