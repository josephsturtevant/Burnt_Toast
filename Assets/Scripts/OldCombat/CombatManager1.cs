using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour {

	public static bool inCombat = false;
	private static bool enemyTurn = false;
	private static Camera combatCamera, worldCamera;
	private static Hero Luke, Girl, Dog;
	private static Vector3 origPlayerPos, origEnemyPos;
	//enemyObject is the game object that gets deleted
	private static GameObject enemyObject, playerObject;
	//opponent is what keeps all the HP stuff
	private static Enemy opponent;
	public static Hero[] CombatPositions = new Hero[3];
	//Locations from Combat Camera
	private static Vector3 playerPos1 = new Vector3(-10f, 7f, 9f);
	private static Vector3 playerPos2 = new Vector3(-10f, -7f, 9f);
	private static Vector3 playerPos3 = new Vector3(-20f, 0f, 9f);
	private static Vector3 enemyPos = new Vector3(10f, 0f, 9f);
	private static int turnCounter = 0;
	private const int RESOURCE_REGEN = 10;
	private const int HEALTH_REGEN = 20;
	private const bool IN_GUARD = true;
	private static bool hasIncreasedResources = false;
	//GUI stuff
	private static string lastAttack;
	//Seperated for GUI
	private static int enemyDmg, playerDmg;
	//Put this here for GUI
	private static int rand = -1;


	
	// Use this for initialization
	void Start () {
		//Setting the world cameras
		combatCamera = GameObject.Find ("CombatCamera").GetComponent<Camera> ();
		worldCamera = GameObject.Find ("MainCamera").GetComponent<Camera> ();
		combatCamera.gameObject.SetActive (false);
		//Setting initial Combat Positions
		Luke = GameObject.Find ("Egg").GetComponent<Hero>();
		CombatPositions [0] = Luke;
		Girl = GameObject.Find ("Chicken").GetComponent<Hero>();
		CombatPositions [1] = Girl;
		Dog = GameObject.Find ("Dog").GetComponent<Hero>();
		CombatPositions [2] = Dog;
		//Setting girl and dog to false, so they don't show up in World until combat
		Girl.gameObject.SetActive (false);
		Dog.gameObject.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
		//Exit Combat (Only used for debugging)
		if (Input.GetKeyDown(KeyCode.Escape)){
			EndCombat();
		}
		//Main Combat Logic
		if (inCombat) {
			if(enemyTurn){
				//Enemy's Turn
				rand = Random.Range(0, 3);
				enemyDmg = opponent.regularAttack();
				if (rand == 2)
					enemyDmg = enemyDmg / 2;
				CombatPositions[rand].lowerHP(enemyDmg);
				EndTurn();
			} else if (turnCounter == 2){
				//Guard Turn
				CombatPositions[turnCounter].increaseHP(HEALTH_REGEN);
				CombatPositions[turnCounter].regenResource(IN_GUARD);
				EndTurn();
			} else {
				//Player's Turn
				//Increases Resources once before acting
				if (!hasIncreasedResources)
					ResourceRegenPhase();
				if (Input.GetKeyDown(KeyCode.J)){
					lastAttack = "Power Attack";
					playerDmg = CombatPositions[turnCounter].powerAttack();
					opponent.lowerHP(playerDmg);
					EndTurn();
				}
				if (Input.GetKeyDown(KeyCode.K)){
					lastAttack = "Regular Attack";
					playerDmg = CombatPositions[turnCounter].regularAttack();
					opponent.lowerHP(playerDmg);
					EndTurn();
				}
				//Switch Position, don't do damage or regen
				if (Input.GetKeyDown(KeyCode.L)){
					lastAttack = "Switched Position";
					Hero temp;
					temp = CombatPositions[2];
					CombatPositions[2] = CombatPositions[turnCounter];
					CombatPositions[turnCounter] = temp;
					LoadPositions();
					EndTurn();
				}
			}
		}
	}

	public static void StartCombat(GameObject player, GameObject enemy){
		if (!inCombat) {
			//Saves original position of player and enemy.
			CombatManager.origPlayerPos = player.transform.position;
			CombatManager.origEnemyPos = enemy.transform.position;
			CombatManager.inCombat = true;
			CombatManager.hasIncreasedResources = false;
			//Switches cameras
			CombatManager.worldCamera.gameObject.SetActive(false);
			CombatManager.combatCamera.gameObject.SetActive(true);
			//Activates girl and dog
			Girl.gameObject.SetActive(true);
			Dog.gameObject.SetActive(true);
			//Sets positions of Players and enemy
			CombatManager.LoadPositions();
			CombatManager.enemyObject = enemy;
			CombatManager.playerObject = player;
			enemyObject.transform.position = combatCamera.transform.position + enemyPos;
			//Gets the script of the enemy
			opponent = enemy.GetComponent<Enemy>();
			//Resets turn counter and and enemy's turn
			turnCounter = 0;
			enemyTurn = false;
		}
	}

	void EndCombat(){
		inCombat = false;
		Destroy(enemyObject);
		//Switches cameras back
		CombatManager.worldCamera.gameObject.SetActive(true);
		CombatManager.combatCamera.gameObject.SetActive(false);
		//Deactivates girl and dog
		Girl.gameObject.SetActive(false);
		Dog.gameObject.SetActive(false);
		//returns player to original position
		playerObject.transform.position = origPlayerPos;
	}

	void EndTurn(){
		if (opponent.getHP() <= 0){
			EndCombat();
			return;
		}
		if (enemyTurn)
			enemyTurn = false;
		else if (++turnCounter > 2){
			enemyTurn = true;
			turnCounter = 0;
		}
		hasIncreasedResources = false;
	}

	void ResourceRegenPhase(){
		CombatPositions[turnCounter].regenResource(!IN_GUARD);
		hasIncreasedResources = true;
	}

	void OnGUI () {
		if (inCombat){
			//player's GUI
			GUI.Label (new Rect(0, 0, 400, 25), 
			           CombatPositions[0].gameObject.name + "'s HP: " + CombatPositions[0].getHP() + " " +
			           CombatPositions[1].gameObject.name + "'s HP: " + CombatPositions[1].getHP() + " " + 
			           CombatPositions[2].gameObject.name + "'s HP: " + CombatPositions[2].getHP());
			GUI.Label (new Rect(0, 25, 400, 25), 
			           CombatPositions[0].gameObject.name + "'s MP: " + CombatPositions[0].getResource() + " " +
			           CombatPositions[1].gameObject.name + "'s MP: " + CombatPositions[1].getResource() + " " + 
			           CombatPositions[2].gameObject.name + "'s MP: " + CombatPositions[2].getResource());
			GUI.Label (new Rect(0, 50, 200, 25), "Last Attack Was: " + lastAttack);
			GUI.Label (new Rect(0, 75, 200, 25), "Attack DMG Was: " + playerDmg);
			GUI.Label (new Rect(0, 100, 200, 25), CombatPositions[turnCounter].gameObject.name + "'s Turn");
			//Enemey's GUI
			GUI.Label (new Rect(500, 0, 150, 25), "Enemy's Target: " + opponent.getHP());
			if (rand != -1){
				GUI.Label (new Rect(500, 25, 150, 25), "Enemy's Target: " + CombatPositions[rand].gameObject.name);
				GUI.Label (new Rect(500, 50, 150, 25), "DMG Dealt: " + enemyDmg);
			}
			//The Controls
			GUI.Label (new Rect(200, 100, 200, 25), "Regular Attack: J");
			GUI.Label (new Rect(200, 125, 200, 25), "Power Attack: K");
			GUI.Label (new Rect(200, 150, 200, 25), "Switch: L");
			GUI.Label (new Rect(200, 175, 200, 25), "End Combat: ESC");
		}
	}

	static void LoadPositions(){
		CombatPositions[0].transform.position = combatCamera.transform.position + playerPos1;
		CombatPositions[1].transform.position = combatCamera.transform.position + playerPos2;
		CombatPositions[2].transform.position = combatCamera.transform.position + playerPos3;
	}

}
