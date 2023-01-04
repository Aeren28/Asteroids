using UnityEngine;

public class GameManager : MonoBehaviour{

    public Player player;

    public ParticleSystem explosion;

    public float respawnTime = 3.0f;

    public float respawnInvulnerabilityTime = 3.0f;

    public int lives = 3;

    public int score = 0;


    public void AsteroidDestroyed(Asteroid asteroid) {

        //si los asteroides se destruyen activa particulas
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        //cada asteroides destruido sumamos al score
        if (asteroid.size < 0.15f){
            this.score += 100;
        }

        else if (asteroid.size < 0.15f) {
            this.score += 50;
        }

        else {
            this.score += 25;
        }

    }
    
    public void PlayerDied(){

        //si te matan activa particulas
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        //quita 1 vida si mueres con un maximo de 3 vidas
        this.lives--;

        if (this.lives <= 0) {

            GameOver();
        }
        else { 
           
            //respawnea si mueres
            Invoke(nameof(Respawn), this.respawnTime);
        }

    }
    private void Respawn(){

        //te dejo tiempo de respawn para no morir instantaneamente
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);
        
        Invoke(nameof(TurnOnCollisions), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisions() {

        //ya no eres invulnerable y te pueden volver a matar
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver() {
        
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }
}
