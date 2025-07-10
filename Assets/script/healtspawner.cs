using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;



public class healtspawner : MonoBehaviour
{
   public GameObject prefab;

   public void Start() {
        InvokeRepeating(nameof(spawnhealt) ,0f, 10f);
   }
   public void spawnhealt()
   {

    //KONUMU SECIYOSUN
        Vector3 spawnPoint = new Vector3();


      //RASGELE KONUM ATIYO
        spawnPoint.x = Random.Range(-3, 3);
        spawnPoint.y = Random.Range(-3,3);
//RASGELE OLAN KONUMDA DOGURUYO
        Instantiate(prefab, spawnPoint, quaternion.identity);
   }


    void Update()
    {
        
    }
   

}


