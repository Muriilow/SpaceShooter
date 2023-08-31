using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int level = 0;
    [SerializeField] private float waitTime = 5f;
    [SerializeField] private int score = 0;
    private int baseScore = 50;
    private float waitEnemies = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CreateEnemies();

    }

    private void CreateEnemies()
    {
        waitEnemies -= Time.deltaTime;
        if (waitEnemies <= 0)
        {
            int quantity = level * 4;
            //Creating a lot of enemies in one time 
            int quantityEnemies = 0;
            while (quantityEnemies < quantity)
            {
                GameObject enemyCreated;

                //Deciding which enemy will be create based at the level
                float chance = Random.Range(0f, level);
                if (chance > 2f) { enemyCreated = enemies[1]; }
                else { enemyCreated = enemies[0]; }

                //Random values
                float randomX = Random.Range(-8f, 8f);
                float randomY = Random.Range(6f, 13f);
                //Random position
                Vector3 position = new Vector3(randomX, randomY, 0f);
                //Restart timing
                waitEnemies = waitTime;
                //Instantiate 1 enemy in a random position
                Instantiate(enemyCreated, position, transform.rotation);

                quantityEnemies++;
            }
        }
    }
    public void GetPoints(int score)
    {
        this.score += score;
        
        //Getting level if the points are greater than the base
        if(this.score > baseScore * level)
        {
            level++;
        }
    }
}
