using UnityEngine;

public class coin : Collectable

{

    int score = 0;
    protected override void Collect()
    {
      int increasedscore =  score++;
        Debug.Log(increasedscore + " point added");
        Destroy(gameObject);
    }
}
