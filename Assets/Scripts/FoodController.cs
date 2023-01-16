using UnityEngine;

public class FoodController : MonoBehaviour
{
    void OnCollisionEnter( Collision collision )
    {
        if( collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy" )
        {
            Destroy( this.gameObject );
        }
    }
}
