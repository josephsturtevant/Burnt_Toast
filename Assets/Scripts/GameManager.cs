using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour {

	#region Luke Persistent Stat Data
	public Luke LukeStats;
	#endregion

	#region Luke Persistent Stat Data
	public Izzy IzzyStats;
	#endregion

	#region Luke Persistent Stat Data
	public Yogurt YogurtStats;
	#endregion

	#region Key Item Dirty Flags
	public bool hasBasketball;
	public bool hasBaseball;
	public bool hasFoamFinger;
	public bool hasFootball;
	public bool hasSmartphone;
	public bool hasSpeakers;
	public bool hasTablet;
	public bool hasVoucher;
	public bool hasCollar;
	public bool hasChewToy;
	public bool hasOldTreat;
	public bool hasHydrantPic;
	#endregion

	#region Quest Dirty Flags
	#endregion

	#region Other Persistent Data
	public int experience;
	public int currentLevel;
	public int money;
	public Item[] inventory;
	public string currentAreaName;
	#endregion

	public static GameManager control;
	void Awake () {
		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} else if (control != this) {
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}

	public void Save(){
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");
		
		GameData data = new GameData ();
		#region Luke Persistent Stat Data
		data.LukeStats = LukeStats;
//		data.LukeMaxHP = LukeStats.MaxHP;
//		data.LukeCurrentHP = LukeStats.CurrentHP;
//		data.LukeMaxStamina = LukeStats.MaxStamina;
//		data.LukeCurrentStamina = LukeStats.CurrentStamina;
//		data.LukeAttackModifier = LukeStats.AttackModifier;
//		data.LukeDefenseModifier = LukeStats.DefenseModifier;
		#endregion
		
		#region Izzy Persistent Stat Data
		data.IzzyStats = IzzyStats;
//		data.IzzyMaxHP = IzzyStats.MaxHP;
//		data.IzzyCurrentHP = IzzyStats.CurrentHP;
//		data.IzzyMaxStamina = IzzyStats.MaxStamina;
//		data.IzzyCurrentStamina = IzzyStats.CurrentStamina;
//		data.IzzyAttackModifier = IzzyStats.AttackModifier;
//		data.IzzyDefenseModifier = IzzyStats.DefenseModifier;
		#endregion
		
		#region Yogurt Persistent Stat Data
		data.YogurtStats = YogurtStats;
//		data.YogurtMaxHP = YogurtStats.MaxHP;
//		data.YogurtCurrentHP = YogurtStats.CurrentHP;
//		data.YogurtMaxStamina = YogurtStats.MaxStamina;
//		data.YogurtCurrentStamina = YogurtStats.CurrentStamina;
//		data.YogurtAttackModifier = YogurtStats.AttackModifier;
//		data.YogurtDefenseModifier = YogurtStats.DefenseModifier;
		#endregion
		
		#region Key Item Dirty Flags
		data.hasBasketball = hasBasketball;
		data.hasBaseball = hasBaseball;
		data.hasFoamFinger = hasFoamFinger;
		data.hasFootball = hasFootball;
		data.hasSmartphone = hasSmartphone;
		data.hasSpeakers = hasSpeakers;
		data.hasTablet = hasTablet;
		data.hasVoucher = hasVoucher;
		data.hasCollar = hasCollar;
		data.hasChewToy = hasChewToy;
		data.hasOldTreat = hasOldTreat;
		data.hasHydrantPic = hasHydrantPic;
		#endregion
		
		#region Quest Dirty Flags
		#endregion
		
		#region Other Persistent Data
		data.experience = experience;
		data.currentLevel = currentLevel;
		data.money = money;
		data.inventory = inventory;
		data.currentAreaName = currentAreaName;
		#endregion

		bf.Serialize (file, data);
		file.Close ();
	}
	
	public void Load(){
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
			GameData data = (GameData) bf.Deserialize(file);
			file.Close();

			#region Luke Persistent Stat Data
			LukeStats = data.LukeStats;
//			LukeStats.MaxHP = data.LukeMaxHP;
//			LukeStats.CurrentHP = data.LukeCurrentHP;
//			LukeStats.MaxStamina = data.LukeMaxStamina;
//			LukeStats.CurrentStamina = data.LukeCurrentStamina;
//			LukeStats.AttackModifier = data.LukeAttackModifier;
//			LukeStats.DefenseModifier = data.LukeDefenseModifier;
			#endregion
			
			#region Izzy Persistent Stat Data
			IzzyStats = data.IzzyStats;
//			IzzyStats.MaxHP = data.IzzyMaxHP;
//			IzzyCurrentHP = data.IzzyCurrentHP;
//			IzzyMaxStamina = data.IzzyMaxStamina;
//			IzzyCurrentStamina = data.IzzyCurrentStamina;
//			IzzyAttackModifier = data.IzzyAttackModifier;
//			IzzyDefenseModifier = data.IzzyDefenseModifier;
			#endregion
			
			#region Yogurt Persistent Stat Data
			YogurtStats = data.YogurtStats;
//			YogurtMaxHP = data.YogurtMaxHP;
//			YogurtCurrentHP = data.YogurtCurrentHP;
//			YogurtMaxStamina = data.YogurtMaxStamina;
//			YogurtCurrentStamina = data.YogurtCurrentStamina;
//			YogurtAttackModifier = data.YogurtAttackModifier;
//			YogurtDefenseModifier = data.YogurtDefenseModifier;
			#endregion
			
			#region Key Item Dirty Flags
			hasBasketball = data.hasBasketball;
			hasBaseball = data.hasBaseball;
			hasFoamFinger = data.hasFoamFinger;
			hasFootball = data.hasFootball;
			hasSmartphone = data.hasSmartphone;
			hasSpeakers = data.hasSpeakers;
			hasTablet = data.hasTablet;
			hasVoucher = data.hasVoucher;
			hasCollar = data.hasCollar;
			hasChewToy = data.hasChewToy;
			hasOldTreat = data.hasOldTreat;
			hasHydrantPic = data.hasHydrantPic;
			#endregion
			
			#region Quest Dirty Flags
			#endregion
			
			#region Other Persistent Data
			experience = data.experience;
			currentLevel = data.currentLevel;
			money = data.money;
			inventory = data.inventory;
			currentAreaName = data.currentAreaName;
			#endregion

			Application.LoadLevel(currentLevel);
		}
	}
}

// this is a container class
[Serializable]
class GameData{
	#region Luke Persistent Stat Data
	public Luke LukeStats;
//	public int LukeMaxHP;
//	public int LukeCurrentHP;
//	public int LukeMaxStamina;
//	public int LukeCurrentStamina;
//	public int LukeAttackModifier;
//	public int LukeDefenseModifier;
	#endregion
	
	#region Izzy Persistent Stat Data
	public Izzy IzzyStats;
//	public int IzzyMaxHP;
//	public int IzzyCurrentHP;
//	public int IzzyMaxStamina;
//	public int IzzyCurrentStamina;
//	public int IzzyAttackModifier;
//	public int IzzyDefenseModifier;
	#endregion
	
	#region Yogurt Persistent Stat Data
	public Yogurt YogurtStats;
//	public int YogurtMaxHP;
//	public int YogurtCurrentHP;
//	public int YogurtMaxStamina;
//	public int YogurtCurrentStamina;
//	public int YogurtAttackModifier;
//	public int YogurtDefenseModifier;
	#endregion
	
	#region Key Item Dirty Flags
	public bool hasBasketball;
	public bool hasBaseball;
	public bool hasFoamFinger;
	public bool hasFootball;
	public bool hasSmartphone;
	public bool hasSpeakers;
	public bool hasTablet;
	public bool hasVoucher;
	public bool hasCollar;
	public bool hasChewToy;
	public bool hasOldTreat;
	public bool hasHydrantPic;
	#endregion
	
	#region Quest Dirty Flags
	#endregion
	
	#region Other Persistent Data
	public int experience;
	public int currentLevel;
	public int money;
	public Item[] inventory;
	public string currentAreaName;
	#endregion
}
