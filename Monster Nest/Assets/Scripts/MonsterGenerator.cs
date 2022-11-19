using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject Goblin;
    public GameObject Mushroom;
    public GameObject FlyingEye;
    public GameObject DeathBringer;
    public List<GameObject> Monsters;
    public List<Vector2> vectors;
    // Start is called before the first frame update
    void Start()
    {
        generatorStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatorStart()
    {
        RaycastHit2D hit;
        Vector2 vector = Vector2.zero;
        Collider2D collider;
        Monsters = new List<GameObject>();
        Monsters.Add(Instantiate(DeathBringer));
        vector = new Vector2(650, -473);
        Monsters[Monsters.Count - 1].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
        for (int i = 0; i < 20; i++)
        {
            int j = UnityEngine.Random.Range(0, 3);

            switch (j)
            {
                case 0:
                    Monsters.Add(Instantiate(Skeleton));
                    Monsters[Monsters.Count - 1].transform.SetParent(gameObject.transform);
                    do
                    {
                        vector = new Vector2((float)UnityEngine.Random.Range(-600, 600), (float)UnityEngine.Random.Range(-600, 600));
                        hit = Physics2D.Raycast(vector, vector);
                    } while (hit.collider.bounds.Contains(vector));
                    Monsters[Monsters.Count - 1].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
                    break;
                case 1:
                    Monsters.Add(Instantiate(Goblin));
                    Monsters[Monsters.Count - 1].transform.SetParent(gameObject.transform);
                    do
                    {
                        vector = new Vector2((float)UnityEngine.Random.Range(-600, 600), (float)UnityEngine.Random.Range(-600, 600));
                        hit = Physics2D.Raycast(vector, vector);
                    } while (hit.collider.bounds.Contains(vector));
                    Monsters[Monsters.Count - 1].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
                    break;
                case 2:
                    Monsters.Add(Instantiate(Mushroom));
                    Monsters[Monsters.Count - 1].transform.SetParent(gameObject.transform);
                    do
                    {
                        vector = new Vector2((float)UnityEngine.Random.Range(-600, 600), (float)UnityEngine.Random.Range(-600, 600));
                        hit = Physics2D.Raycast(vector, vector);
                    } while (hit.collider.bounds.Contains(vector));
                    Monsters[Monsters.Count - 1].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
                    break;
                case 3:
                    Monsters.Add(Instantiate(FlyingEye));      
                    do
                    {
                        vector = new Vector2((float)UnityEngine.Random.Range(-600, 600), (float)UnityEngine.Random.Range(-600, 600));
                        hit = Physics2D.Raycast(vector, vector);
                    } while (hit.collider.bounds.Contains(vector));
                    Monsters[Monsters.Count - 1].transform.SetPositionAndRotation(vector, new Quaternion(0, 0, 0, 0));
                    break;
            }
        }
    }
}
