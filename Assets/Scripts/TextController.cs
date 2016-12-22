using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public GameObject InputField2;
	public Text text;
	public InputField input;
	private enum States {
			intro, cell_0, cell_1, cell_2, cell_3, mirror_0, bed_0, bed_1, bed_2, bed_3, door_0, door_1, door_2, table_0, table_1, oillamp_0,
			pillow_0, pillow_1, corridor_0, freedom
			};
	private States myState;
	private States PreviousmyState;
	private bool lamp;
	public string command;


	// Use this for initialization
	void Start () {
		lamp = false;
		myState = States.intro;
		PreviousmyState = States.cell_0;
	}
	
	// Update is called once per frame
	void Update () {
	// print (myState);
		if 		(myState == States.intro) 		{intro();}
		else if	(myState == States.cell_0) 		{cell_0();}
		else if (myState == States.cell_1) 		{cell_1();}
		else if (myState == States.cell_2) 		{cell_2();}
		else if (myState == States.cell_3) 		{cell_3();}
		else if (myState == States.mirror_0) 	{mirror_0();}
		else if (myState == States.bed_0) 		{bed_0();}
		else if (myState == States.bed_1) 		{bed_1();}
		else if (myState == States.bed_2) 		{bed_2();}
		else if (myState == States.bed_3) 		{bed_3();}
		else if (myState == States.pillow_0) 	{pillow_0();}
		else if (myState == States.pillow_0) 	{pillow_1();}
		else if (myState == States.door_0) 		{door_0();}
		else if (myState == States.door_1) 		{door_1();}
		else if (myState == States.door_2) 		{door_2();}
		else if (myState == States.table_0) 	{table_0();}
		else if (myState == States.table_1) 	{table_1();}
		else if (myState == States.oillamp_0) 	{oillamp_0();}
		else if (myState == States.corridor_0) 	{corridor_0();}
	}
	
	public void GetCommand(string comm){ // Gets command from player
		command = input.text;
		//input.text = "";
		Debug.Log("command is " + command);
	}
	
	
	
	void intro () {
		text.text = "You open your eyes slowly. At first you cannot see much. " + 
			"The room you are in is dark and only a small oil lamp on top of a table in the corner " + 
				"illuminates the space. As your eyes adjust to the darkness " + 
				"you realize you are in a prison cell. You try to recall why " + 
				"you are there. In the last memory you have you were in a forest. " + 
				"However you do not know why or what you were doing. Suddenly a feeling of danger haunts " + 
				"your mind. Immediately you stand up and decide to search the prison cell. " + 
				"There must be a way out or a way to discover why you are there! \n" + 
				"Press Escape to continue";
		if (Input.GetKeyDown(KeyCode.Escape))		{myState = States.cell_0;}
	}
	
	void cell_0 () {
		text.text = "The room is small. There is a small bed with a dirty pillow, " + 
					"a mirror, a small old wodden table and a solid metalic " + 
					"door locked from the outside. \n" + 
					"You can use commands like the following: " + 
					"'Go to...'; 'Use the...'; 'Hide in...'; 'Take the...'. " + 
					"And the objects to interact " + 
					"are described in the text (bed, mirror, door or table).";
					//Debug.Log (command);
		if (command.Contains("Go") && command.Contains("bed"))		{myState = States.bed_0;}
		else if(Input.GetKeyDown(KeyCode.Z)) 	{myState = States.mirror_0;}
		else if(Input.GetKeyDown(KeyCode.A)) 	{myState = States.door_0;}
		else if(Input.GetKeyDown(KeyCode.Q)) 	{myState = States.table_0;}
	}
	
	void cell_1 () {
		text.text = "You are still in the room. There is a small bed with a dirty pillow, " + 
					" a small old wodden table and a solid metalic " + 
					"door locked from the outside. \n" + 
					"What shall be your next move?";
		PreviousmyState = States.cell_1;
		if (Input.GetKeyDown(KeyCode.B))		{myState = States.bed_1;}
		else if(Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_1;}
		else if(Input.GetKeyDown(KeyCode.T)) 	{myState = States.table_0;}
	}
	
	void cell_2 () {
		text.text = "You are still in the room. You have now a misterious key in your hand. " + 
					"There is a small bed, " + 
					" a small old wodden table and a solid metalic " + 
					"door locked from the outside. \n" + 
					"What shall be your next move?";
		PreviousmyState = States.cell_2;
		if (Input.GetKeyDown(KeyCode.B))		{myState = States.bed_2;}
		else if(Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_2;}
		else if(Input.GetKeyDown(KeyCode.T)) 	{myState = States.table_0;}
	}
	
	void cell_3 () {
		text.text = "You opened the door but you need to gather your thoughts before adventuring into the unknown. " + 
					"The room remains dark and cold. The bed and the table are still here." + 
					"You still don't know why you were locked there and who wrote that letter and gave you that key? " + 
					"Is this a dream? You calm down for a second. \n" + 
					"What shall be your next move?";
		PreviousmyState = States.cell_3;
		if (Input.GetKeyDown(KeyCode.B))		{myState = States.bed_3;}
		else if(Input.GetKeyDown(KeyCode.D)) 	{myState = States.door_2;}
		else if(Input.GetKeyDown(KeyCode.T)) 	{myState = States.table_0;}
	}
	
	void mirror_0 () {
		text.text = "A broken mirror lies on the floor. It has sharp edges so you carefully pick it up. " + 
					"You look yourself in the mirror. You look tired and blank like all the blood was sucked out of your face. \n" + 
					"Now that you have the broken mirror what do you do " + 
					"next? \n\nType C to return to the cell.";
		if (Input.GetKeyDown(KeyCode.C))		{myState = States.cell_1;}
	}
	
	void bed_0 () {
		text.text = "The bed is covered in stains that look like dry blood. " + 
					"Shivers run through your spine. The pillow " + 
					"is dirty and bloddy as well and has a strange form. \nWhat do you do " + 
					"next? \n\nTip: If you type return you go back to your previous location.";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.cell_0;}
		else if (Input.GetKeyDown(KeyCode.P))		{myState = States.pillow_0;}
	}
	
	void bed_1 () {
		text.text = "The bed still creeps you out. You cannot imagine yourself sleeping in that. " + 
					"The pillow is also still there with its strange form almost like somthing is inside. " + 
					"Shall I try to rip it off with the broken mirror? \n" + 
					"Type your next command (Tip: Use ....)";
		if (Input.GetKeyDown(KeyCode.R))			{myState = States.cell_1;}
		else if (Input.GetKeyDown(KeyCode.P))		{myState = States.pillow_1;}
	}
	
	void bed_2 () {
		text.text = "The bed still creeps you out. You cannot imagine yourself sleeping in that. " + 
					"The pillow now is torn apart. Nothing new here. \n" +  
					"What is your next step?";
		if (Input.GetKeyDown(KeyCode.C))			{myState = States.cell_2;}
	}
	
	void bed_3 () {
		text.text = "The bed is still here. You could try to rest a little bit before " + 
					"leaving the cell but it's just too disgusting. \n" +  
					"You should get back...";
		if (Input.GetKeyDown(KeyCode.C))			{myState = States.cell_3;}
	}
	
	void pillow_0 () {
		text.text = "The pillow has a strange bump like something is hidden inside. " + 
					"You try to rip it off, but the material is suprising resistent. " +  
					"Also you seem to be weak, like your forces were sucked out of you. \n" + 
					"You should investigate the rest of the room...";
		if (Input.GetKeyDown(KeyCode.C))			{myState = States.cell_0;}
		else if (Input.GetKeyDown(KeyCode.B))		{myState = States.bed_0;}
	}
	
	void pillow_1 () {
		text.text = "The pillow has a strange bump like something is hidden inside. " + 
					"You rip it off using the broken mirror. " +  
					"Inside an envelope with a letter and a misterious key. The key has a format of a skull. " + 
					"The letter is directed to you. You freeze, how do they know your name.... What is happening? " + 
					"It says: \n'In due time you will get your answers. For now just use me.'\n" + 
					"You have no idea what it means but now you are in the possession of a strange key. What is your next move?";
		if (Input.GetKeyDown(KeyCode.C))			{myState = States.cell_2;}
		else if (Input.GetKeyDown(KeyCode.B))		{myState = States.bed_2;}
	}
		
	void door_0 () {
		text.text = "The door is closed. You try to budge it but it does not move. " + 
					"It is solid metal and it is tighly closed. " + 
					"You try to hear any sound from outside but nothing. \nWhat do you do " + 
					"next? \n\nTip: If you type return you go back to your previous location.";
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell_0;}
	}
	
	void door_1 () {
		text.text = "The door is still firmly closed. You try to budge it but it does not move. " + 
					"Everything is still silent outside. \n" + 
					"You should continue to search the cell. Type your command: ";
		if (Input.GetKeyDown(KeyCode.R))		{myState = States.cell_1;}
	}
	
	void door_2 () {
		text.text = "The door is still firmly closed. But now you notice that suprisingly you can " + 
					"open the lock from the inside. The lock has a strange skull format. \n" + 
					"You hold the misterious key in your hand and slowly you put the key in the lock. You " + 
					"turn the key and with a click the door opens. A dark corridor is ahead." + 
					"Unknown and freedom is at your reach now. Shall you dare to leave?\n" + 
					"Type your next move (tip: You can now go to the corridor):";
		if (Input.GetKeyDown(KeyCode.L))		{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.cell_3;}
	}
	
	void table_0 () {
		text.text = "The bedside table is small, round and old. It has three legs with one being clearly smaller " + 
					"than the others. A small oil lamp stands on top. You notice nothing else of particular importance. \n" + 
					"What shall you do next? (Tip: Remember the commands you can use like " + 
					"'Go to...'; 'Use the...'; 'Hide in...'; 'Take the...'.)";
					
		if (Input.GetKeyDown(KeyCode.L))			{myState = States.oillamp_0;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = PreviousmyState;}
	}
	
	void table_1 () {
		text.text = "The bedside table has not changed. It is still small, round and old, with one of the three legs smaller " + 
					"than the others. You notice nothing else of particular importance. \n" + 
					"Maybe you should go back to the cell? ";
		if (Input.GetKeyDown(KeyCode.L))			{myState = PreviousmyState;}
	}
	
	void oillamp_0 () {
		text.text = "The ligh coming from the lamp is faint and cold. The oil lamp still has a little bit of oil " + 
					"and you decide to take it with you. You never know when you might need it. \n" + 
					"Type 'Go to cell' to return to explore the rest of the room.";
		lamp = true;
		if (Input.GetKeyDown(KeyCode.L))			{myState = PreviousmyState;}
	}
		
	void corridor_0 () {
		text.text = "You slightly open the door just enough to take a look outside" + 
					"There is a dark corridor but you don't see anyone " + 
					"or hear anything. It is like the place is deserted. You take a " + 
					"deep breath and step outside into the unknown into your freedom! \n\n" + 
					"Press P to play again.";
		if (Input.GetKeyDown(KeyCode.P))		{myState = States.intro;}
	}
	

}