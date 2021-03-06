using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private float health = 100;
    private float hunger = 100;
    private float energy = 100;

	public Slider currentHealthBar;
	public Text healthText;
	public Slider currentHungerBar;
	public Text hungerText;
    public Slider currentEnergyBar;
	public Text energyText;

	void Start(){
		Update ();
	}

	private void HealthUpdate(){
		//If Kevin goes hunrgy, his health will suffer as a consequence
		if (hunger == 0){
           health -= 1.0f * Time.deltaTime;
            currentHealthBar.value = health;
        }
        if (health > 100){
            health = 100;
        }
        if (health < 0){
			health = 0;
		}
		healthText.text = (currentHealthBar.value).ToString ("0") + '%';
    }

	private void HungerUpdate(){
		if ((hunger > 0) && (hunger <=100)){
            hunger -= 1.0f * Time.deltaTime;
            currentHungerBar.value = hunger;
        }
        if (hunger > 100){
            hunger = 100;
        }
        if (hunger < 0){
			hunger = 0;
		}
		hungerText.text = (currentHungerBar.value).ToString ("0") + '%';
    }

    private void EnergyUpdate(){
        if ((energy > 0) && (energy <= 100)){
            //energy -= 5.0f * Time.deltaTime;
            currentEnergyBar.value = energy;
        }
        if (energy > 100){
            energy = 100;
        }
        if (energy < 0){
            energy = 0;
        }
		energyText.text = (currentEnergyBar.value).ToString ("0") + '%';
    }

	public void FeedPet(){
		hunger += 25f;
	}

    void Update(){
		HealthUpdate ();
		HungerUpdate ();
        EnergyUpdate();
	}
}