using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour {

	#region Overworld Reference Variables
	private GameManager manager;
	private static Vector3 playerOverworldPos;
	private static GameObject enemyObject;
	#endregion

	//Merged the HeroChar and animator into a single structure.
	//Merged the EnemyChar and animator into a single structure
	#region Combat Object Structures
	struct HeroCombatCharacter
	{
		public HeroChar charStats;
		public Animator animator;
	};
	struct EnemyCombatCharacter
	{
		public EnemyChar enemyStats;
		public Animator animator;
	};
	#endregion

	#region Battle Variables
	public bool enemyTurn;
	private static string lastAttack;
	private BattleAnimMenuScript BattleMenu;
	private Transform multiTargetAttackTarget;
	private int charTurn = 0;
	#endregion

	#region Player Character Variables
	private HeroCombatCharacter[] Heroes = new HeroCombatCharacter[3];
	private HeroCombatCharacter Luke;
	private HeroCombatCharacter Izzy;
	private HeroCombatCharacter Yogurt;
	#endregion

	#region Enemy Variables
	private EnemyCombatCharacter[] Enemies;
	private int numberOfEnemies;
	public string enemyName1;//, enemyName2, enemyName3, enemyName4;
	#endregion

	#region Test Variables
	private GameObject pointer;
	private Vector3 HoverDistance = new Vector3(0f, 2f, 0f);
	#endregion

	// Use this for initialization
	void Start () {
		pointer = GameObject.Find ("Pointer");
		manager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		playerOverworldPos = GameObject.Find ("Player").GetComponent<Transform> ().transform.position;
		BattleMenu = GameObject.Find("BattleMenu").GetComponent<BattleAnimMenuScript>();
		Luke.animator = GameObject.Find("Luke").GetComponent<Animator> ();
		Luke.charStats = GameObject.Find ("Luke").GetComponent<Luke> ();
		Izzy.animator = GameObject.Find("Izzy").GetComponent<Animator> ();
		Izzy.charStats = GameObject.Find ("Izzy").GetComponent<Izzy> ();
		Yogurt.animator = GameObject.Find("Yogurt").GetComponent<Animator> ();
		Yogurt.charStats = GameObject.Find ("Yogurt").GetComponent<Yogurt> ();
		Heroes [Luke.charStats.getCombatPosition ()] = Luke;
		Heroes [Izzy.charStats.getCombatPosition ()] = Izzy;
		Heroes [Yogurt.charStats.getCombatPosition ()] = Yogurt;
		enemyTurn = false;
		multiTargetAttackTarget = GameObject.Find ("MultiAttackTarget").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Luke.animator.SetInteger("AttackNumber", 0);
		Izzy.animator.SetInteger("AttackNumber", 0);
		Yogurt.animator.SetInteger("AttackNumber", 0);
		pointer.transform.position = Heroes [charTurn].animator.transform.position + HoverDistance;
		if(!enemyTurn){
			Debug.Log(BattleMenu.currentState);
			if((Input.GetButtonDown("A")) && (BattleMenu.currentState == "Switch")) {
				int temp = Heroes[charTurn].charStats.getCombatPosition();
				charTurn = (charTurn + 1) % 3;
			} else if((Input.GetButtonDown("A")) && (BattleMenu.currentState == "Item")) {
				
			} else if((Input.GetButtonDown("A")) && (BattleMenu.currentState == "Attack")) {
				Heroes[charTurn].animator.SetInteger("AttackNumber", 1);
				charTurn = (charTurn + 1) % 3;
			} else if((Input.GetButtonDown("A")) && (BattleMenu.currentState == "Defend")) {
				Heroes[charTurn].animator.SetInteger("AttackNumber", 2);
				charTurn = (charTurn + 1) % 3;
			}
			//
			//
			//
		} else {

		}
	}

	// Player Turn Start
	// Regenerate Stamina based on Position
	// Resolve Status Effects
		// Check if Status Effects cause win/loss
			// win :: goto Win()
			// lose :: goto Lose()
	// Pos1 input command
		// Check if possible to execute
			// If impossible to execute return to input
		// Determine Target(s)
	// if attack :: Execute Pos1 attack
		// Deprecate Pos1 Stamina
		// Deprecate Target Health if applicable
		// Check if Status Effect can affect if applicable
			// Add Status Effect
		// Check if result cause win/loss
			// win :: goto Win()
			// lose :: goto Lose()
	// if item :: Execute Pos1 item
		// Delete item from inventory
		// Check item type
		// Determine Target
		// Add Health/Stamina to Pos1-3
		// OR remove Status Effects from Pos1-3
		// OR add Atk/Def to Pos1-3
		// OR remove KO from Pos1-3 AND add Health/Stamina
		// OR remove Atk/Def from Target
		// OR add Status Effect to Target(s)
	// Pos2 input command
	// Execute Pos2 command

	void updateHealth(){
		// Display new health after getting hit
		// Display new health after effects of Stinky
		// Display new health after healing in any way
	}

	void updateStamina(){
		// Display new stamina stat after attack
		// Display new stamina at beginning of player turn
	}

	public void startCombat(EnemyChar[] enemies){
		//numberOfEnemies = enemies.Length ();
	}
}
