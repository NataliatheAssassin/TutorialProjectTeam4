using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Random : Box
{
    [SerializeField] GameObject bomb;
    [SerializeField] GameObject food;
    [SerializeField] GameObject magazine;
    protected int random;
    // Start is called before the first frame update
    private void Awake()
    {
        maxHp = 5;
        mass = 0.5f;
    }
    void Start()
    {
        base.Start();
        randombox();
    }

    // Update is called once per frame
    void randombox()
    {
        random = Random.Range(0, 2);
        if (random == 0) { Instantiate(bomb, transform.position, transform.rotation); }
        else if (random == 1) { Instantiate(food, transform.position, transform.rotation); }
        else { Instantiate(magazine, transform.position, transform.rotation); }
    }
}
