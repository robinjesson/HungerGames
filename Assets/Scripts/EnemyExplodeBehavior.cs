using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeBehavior : MonoBehaviour
{
    private Vector3 cubePivot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void explode(Collider bullet)
    {
        gameObject.SetActive(false);
        EnemyBehaviour parent = gameObject.GetComponentInParent<EnemyBehaviour>();
        int nbCubeExplosionX = (int)(transform.localScale.x / parent.cubeExplosionSize);
        int nbCubeExplosionY = (int)(transform.localScale.y / parent.cubeExplosionSize);
        int nbCubeExplosionZ = (int)(transform.localScale.z / parent.cubeExplosionSize);

        this.cubePivot = new Vector3(parent.cubeExplosionSize * nbCubeExplosionX / 2, parent.cubeExplosionSize * nbCubeExplosionY / 2, parent.cubeExplosionSize * nbCubeExplosionZ / 2);

        for (int i = 0; i < nbCubeExplosionX; i++)
        {
            for (int j = 0; j < nbCubeExplosionY; j++)
            {
                for (int k = 0; k < nbCubeExplosionZ; k++)
                {
                    createPiece(i, j, k, parent);
                }
            }
        }

        Vector3 explosionPos = bullet.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPos, parent.explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(parent.explosionForce, bullet.transform.position, parent.explosionRadius, parent.explosionUpward);
            }
        }
    }

    private void createPiece(int x, int y, int z, EnemyBehaviour parent)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(piece, 2);

        piece.transform.position = transform.position + new Vector3(parent.cubeExplosionSize * x, parent.cubeExplosionSize * y, parent.cubeExplosionSize * z) - cubePivot;
        piece.transform.localScale = new Vector3(parent.cubeExplosionSize, parent.cubeExplosionSize, parent.cubeExplosionSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "BulletCamera(Clone)")
        {
            explode(other);
            gameObject.GetComponentInParent<EnemyBehaviour>().explodeChild(gameObject,other);
        }
    }
}
