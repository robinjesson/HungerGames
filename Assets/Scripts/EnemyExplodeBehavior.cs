using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplodeBehavior : MonoBehaviour
{
    private Vector3 cubePivot;

    /// <summary>
    /// Desactive l'ennemi et remplace chaque pavé par i*j*k cubes.
    /// </summary>
    /// <param name="bullet"></param>
    public void Explode(Collider bullet)
    {
        this.gameObject.SetActive(false);
        EnemyBehaviour parent = this.gameObject.GetComponentInParent<EnemyBehaviour>();
        int nbCubeExplosionX = (int)(this.transform.localScale.x / parent.cubeExplosionSize);
        int nbCubeExplosionY = (int)(this.transform.localScale.y / parent.cubeExplosionSize);
        int nbCubeExplosionZ = (int)(this.transform.localScale.z / parent.cubeExplosionSize);

        this.cubePivot = new Vector3(parent.cubeExplosionSize * nbCubeExplosionX / 2, parent.cubeExplosionSize * nbCubeExplosionY / 2, parent.cubeExplosionSize * nbCubeExplosionZ / 2);

        for (int i = 0; i < nbCubeExplosionX; i++)
        {
            for (int j = 0; j < nbCubeExplosionY; j++)
            {
                for (int k = 0; k < nbCubeExplosionZ; k++)
                {
                    this.CreatePiece(i, j, k, parent);
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

    private void CreatePiece(int x, int y, int z, EnemyBehaviour parent)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Destroy(piece, 2);

        piece.transform.position = this.transform.position + new Vector3(parent.cubeExplosionSize * x, parent.cubeExplosionSize * y, parent.cubeExplosionSize * z) - cubePivot;
        piece.transform.localScale = new Vector3(parent.cubeExplosionSize, parent.cubeExplosionSize, parent.cubeExplosionSize);

        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "BulletCamera(Clone)")
        {
            this.Explode(other);
            this.gameObject.GetComponentInParent<EnemyBehaviour>().ExplodeChild(gameObject,other);
        }
    }
}
