using UnityEngine;
using CreatorKitCode;


public class SpawnerSample : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public int radius = 3;

    public class LootAngle
    {
        int angle;
        int step;

        public LootAngle(int increment)
        {
            step = increment;
            angle = 0;
        }

        public int NextAngle()
        {
            int currentAngle = angle;
            angle = Helpers.WrapAngle(angle + step);
            
            return currentAngle;
        }
    }

    void SpawnPotion(int angle)
    {
        Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.right;
        Vector3 spawnPosition = transform.position + direction * radius;
        Instantiate(ObjectToSpawn, spawnPosition, Quaternion.identity);
    }

    void Start()
    {
        LootAngle myLootAngle = new LootAngle(45);

        //every call will advance the angle!
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
        SpawnPotion(myLootAngle.NextAngle());
    }
}

