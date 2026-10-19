using UnityEngine;

public class Ej5PuntosPlayer : MonoBehaviour
{
    private float points = 0f;
    private const float shieldTipo1Value = 5f;
    private const float shieldTipo2Value = 10f;

    void OnCollisionEnter(Collision collision) {
        CheckAndProcessShield(collision.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        CheckAndProcessShield(other.gameObject);
    }

    void CheckAndProcessShield(GameObject hitObject) {
        float pointsToAdd = 0f;

        if (hitObject.CompareTag("EscudoTipo1")) {
            pointsToAdd = shieldTipo1Value;
        } 
        else if (hitObject.CompareTag("EscudoTipo2")) {
            pointsToAdd = shieldTipo2Value;
        }
        // Si el objeto chocado era un escudo válido, sumamos y destruimos
        if (pointsToAdd > 0f) {
            points += pointsToAdd;
            Debug.Log(name + " (jugador) ha sumado +" + pointsToAdd + " puntos. Tiene en total " + points + " puntos.");
            Destroy(hitObject);
        }
    }
}
