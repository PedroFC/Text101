using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainController : MonoBehaviour {
	
	public Text text; // Scene Text
	// InputField.SubmitEvent se;
	private enum States {
		intro, cell_0, cell_1, cell_2, cell_3, mirror_0, bed_0, bed_1, bed_2, bed_3, door_0, door_1, door_2, table_0, table_1, oillamp_0,
		pillow_0, pillow_1, corridor_0, corridor_1, corridor_2, corridor_3, cabinet_0, cabinet_1, cabinet_2, cabinet_3, cabinet_4, 
		cabinet_5, room_0, room_1, room_2, desk_0, desk_0a, desk_1, desk_1a, window_0, ending_1, key_0, ending_2a, 
		ending_2, gameover
	};
	private States myState;
	private States PreviousmyState;
	private bool lamp; // boolean to know if we pick up the lamp
	private bool readCabinetNote;
	private bool readDeskNote;
	public string command;
		
	[SerializeField]
	public InputField input;
	
	// Use this for initialization
	void Start () {
		lamp = false;
		readCabinetNote = false;
		readDeskNote = false;
		myState = States.intro; // this will be the starting scene
		PreviousmyState = States.cell_0; // this will be updated when we move through different cells states
		input.onEndEdit.AddListener(GetCommand);		
		}
	
	// Update is called once per frame
	void Update () {
		// print (myState);
		
		if 		(myState == States.intro) 		{intro();}
		else if	(myState == States.cell_0) 		{PreviousmyState = States.cell_0; cell_0();}
		else if (myState == States.cell_1) 		{PreviousmyState = States.cell_1; cell_1();}
		else if (myState == States.cell_2) 		{PreviousmyState = States.cell_2; cell_2();}
		else if (myState == States.cell_3) 		{PreviousmyState = States.cell_3; cell_3();}
		else if (myState == States.mirror_0) 	{mirror_0();}
		else if (myState == States.bed_0) 		{bed_0();}
		else if (myState == States.bed_1) 		{bed_1();}
		else if (myState == States.bed_2) 		{bed_2();}
		else if (myState == States.bed_3) 		{bed_3();}
		else if (myState == States.pillow_0) 	{pillow_0();}
		else if (myState == States.pillow_1) 	{pillow_1();}
		else if (myState == States.door_0) 		{door_0();}
		else if (myState == States.door_1) 		{door_1();}
		else if (myState == States.door_2) 		{door_2();}
		else if (myState == States.table_0) 	{table_0();}
		else if (myState == States.table_1) 	{table_1();}
		else if (myState == States.oillamp_0) 	{lamp = true; oillamp_0();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.corridor_1) 	{PreviousmyState = States.corridor_1; corridor_1();}
		else if (myState == States.corridor_2) 	{corridor_2();}
		else if (myState == States.corridor_3) 	{PreviousmyState = States.corridor_3; corridor_3();}
		else if (myState == States.cabinet_0) 	{readCabinetNote = true; cabinet_0();}
		else if (myState == States.cabinet_1) 	{readCabinetNote = true; cabinet_1();}
		else if (myState == States.cabinet_2) 	{readCabinetNote = true; cabinet_2();}
		else if (myState == States.cabinet_3) 	{readCabinetNote = true; cabinet_3();}
		else if (myState == States.cabinet_4) 	{readCabinetNote = true; cabinet_4();}
		else if (myState == States.cabinet_5) 	{readCabinetNote = true; cabinet_5();}
		else if (myState == States.key_0) 		{key_0();}
		else if (myState == States.room_0) 		{room_0();}
		else if (myState == States.room_1) 		{room_1();}
		else if (myState == States.room_2) 		{room_2();}
		else if (myState == States.desk_0) 		{readDeskNote = true; desk_0();}
		else if (myState == States.desk_0a) 	{readDeskNote = true; desk_0a();}
		else if (myState == States.desk_1) 		{readDeskNote = true; desk_1();}
		else if (myState == States.desk_1a) 	{readDeskNote = true; desk_1a();}
		else if (myState == States.window_0) 	{window_0();}
		else if (myState == States.ending_1) 	{ending_1();}
		else if (myState == States.ending_2) 	{ending_2();}
		else if (myState == States.ending_2a) 	{ending_2a();}
		else if (myState == States.gameover) 	{gameover();}
	}
	
	public void GetCommand(string arg0){ // Gets command from player
		command = input.text;
		input.text = "";
		// input.ActivateInputField();
		Debug.Log("command is " + command);
	}
	

	void intro () {
		text.text = "You are slowly opening your eyes. At first, you cannot see much. " + 
			"The room you are in is dark and only a small oil lamp on top of a table in the corner " + 
				"illuminates the space. As your eyes adjust to the darkness " + 
				"you realize you are in a prison cell. You are trying to recall the " + 
				"reason why you are in here. The last thing you remember is being in a forest. " + 
				"However you do not know why you were there or what you were doing. Suddenly, a feeling of danger overwhelms " + 
				"you and makes you promptly stand up. You decide to search the prison cell. " + 
				"After all, there must be a way out or a way to discover why you are there! \n" + 
				"Press Esc to continue";
		if (Input.GetKeyDown(KeyCode.Escape))		{myState = States.cell_0;}
	}
	
	void cell_0 () {
		text.text = "The room is small. There is a small bed with a dirty pillow, " + 
			"a mirror, a small old wodden table and a solid metalic " + 
				"door locked from the outside. \n" + 
				"Tips: you can use the following or similar commands: " + 
				"'Go to...'; 'Use the...'; 'Hide in...'; 'Take the...'. " + 
				"And the objects to interact " + 
				"are described in the text (bed, mirror, door or table). \n" + 
				"Also, after interacting with an object you will always have to return to the main room before being able to interact with other objects.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed"))			{myState = States.bed_0;}
		else if((command.Contains("Go") || command.Contains("go") || command.Contains("Take") || command.Contains("take")) && command.Contains("mirror")) 	{myState = States.mirror_0;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("door")) 	{myState = States.door_0;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("table")) 	{myState = States.table_0;}
	}
	
	void cell_1 () {
		text.text = "You are still in the room. There is a small bed with a dirty pillow, " + 
			" a small old wodden table and a solid metalic " + 
				"door locked from the outside. \n" + 
				"What shall be your next move?";
		// PreviousmyState = States.cell_1;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed"))			{myState = States.bed_1;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("door")) 	{myState = States.door_1;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("table")) 	{myState = States.table_0;}
	}
	
	void cell_2 () {
		text.text = "You are still in the room. You have now a mysterious key in your hand. " + 
			"There is a small bed, " + 
				" a small old wodden table and a solid metalic " + 
				"door locked from the outside. \n" + 
				"What shall be your next move?";
		// PreviousmyState = States.cell_2;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed"))			{myState = States.bed_2;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("door")) 	{myState = States.door_2;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("table")) 	{myState = States.table_0;}
	}
	
	void cell_3 () {
		text.text = "You opened the door but you need to gather your thoughts before adventuring into the unknown. " + 
			"The room remains dark and cold. The bed and the table are still here." + 
				"You still don't know why you were locked there and who wrote that letter and gave you that key? " + 
				"Is this a dream? You calm down for a second. \n" + 
				"What shall be your next move?";
		// PreviousmyState = States.cell_3;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed"))			{myState = States.bed_3;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("door")) 	{myState = States.door_2;}
		else if((command.Contains("Go") || command.Contains("go")) && command.Contains("table")) 	{myState = States.table_0;}
	}
	
	void mirror_0 () {
		text.text = "A broken mirror lies on the floor. It has sharp edges so you carefully pick it up. " + 
			"You look at your reflection in the mirror. You look tired and pale, as if all the blood was drained from your body. \n" + 
				"Now that you have the broken mirror what do you do " + 
				"next? \n\nTip: You can type 'Return' or 'Go to cell' to return to the cell from whatever object you interacted before.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))		{myState = States.cell_1;}
	}
	
	void bed_0 () {
		text.text = "The bed is covered in stains that look like dry blood. " + 
			"Shivers run through your spine. The pillow " + 
				"is dirty and bloddy as well and has a strange form. \nWhat do you do " + 
				"next? \n\nTip: If you type Return you go back to your previous location.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = States.cell_0;}
		else if ((command.Contains("Use") || command.Contains("use")) && command.Contains("pillow"))		{myState = States.pillow_0;}
	}
	
	void bed_1 () {
		text.text = "The bed still creeps you out. You cannot imagine yourself sleeping in that. " + 
			"The pillow is also still there with its strange form almost like something is inside. " + 
				"Shall I try to rip it off with the broken mirror? \n" + 
				"Type your next command (Tip: Use ....)";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = States.cell_1;}
		else if ((command.Contains("Use") || command.Contains("use")) && command.Contains("mirror"))		{myState = States.pillow_1;}
	}
	
	void bed_2 () {
		text.text = "The bed still creeps you out. You cannot imagine yourself sleeping in that. " + 
			"The pillow now is torn apart. Nothing new here. \n" +  
				"What is your next step?";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = States.cell_2;}
	}
	
	void bed_3 () {
		text.text = "The bed is still here. You could try to rest a little bit before " + 
			"leaving the cell but it's just too disgusting. \n" +  
				"You should get back...";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = States.cell_3;}
	}
	
	void pillow_0 () {
		text.text = "The pillow has a strange bump like something is hidden inside. " + 
			"You try to rip it off, but the material is suprising resistent. " +  
				"Also you seem to be weak, like your forces were sucked out of you. \n" + 
				"You should investigate the rest of the room...";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell"))			{myState = States.cell_0;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed") || (command.Contains("Return") || command.Contains("return")))		{myState = States.bed_0;}
	}
	
	void pillow_1 () {
		text.text = "The pillow has a strange bump like something is hidden inside. " + 
			"You rip it off using the broken mirror. " +  
				"Inside the pillow, you find an envelope with a letter and a mysterious skull-shaped key. " + 
				"When you realize the letter is addressed to you, you freeze. You are asking yourself, 'How did they know my name? What is happening?'" + 
				"The letter cryptically says:  \n'You will get your answers in due time. For now just use what came with me.'\n" + 
				"You have no idea what it means but now you are in the possession of a strange key. What is your next move?";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell"))			{myState = States.cell_2;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("bed") || (command.Contains("Return") || command.Contains("return")))		{myState = States.bed_2;}
	}
	
	void door_0 () {
		text.text = "The door is closed. You try to budge it but it does not move. " + 
			"It is solid metal and it is tighly closed. " + 
				"You try to hear any sound from outside but nothing. \nWhat do you do " + 
				"next? \n\nTip: If you type Return you go back to your previous location.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))		{myState = States.cell_0;}
	}
	
	void door_1 () {
		text.text = "The door is still firmly closed. You try to budge it but it does not move. " + 
			"Everything is still silent outside. \n" + 
				"You should continue to search the cell. Type your command: ";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))		{myState = States.cell_1;}
	}
	
	void door_2 () {
		text.text = "The door is still firmly closed. But now you notice that suprisingly you can " + 
			"open the lock from the inside. The lock is also shaped as a skull. \n" + 
				"You hold the mysterious key in your hand and you are slowly putting the key in the lock. " + 
				"As you turn the key, you hear a click and the door opens. you see a dark corridor. " + 
				"The unknown and the freedom are at your reach now. Do you dare to leave?\n" + 
				"Type your next move (tip: You can now go to the corridor):";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor") && lamp == false)		{myState = States.corridor_0;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor") && lamp == true)	{myState = States.corridor_2;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))		{myState = States.cell_3;}
	}
	
	void table_0 () {
		text.text = "The bedside table is small, round and old. It has three legs with one being clearly smaller " + 
			"than the others. A small oil lamp stands on top of it. There is nothing else of particular importance that you can see. \n" + 
				"What shall you do next? (Tip: Remember the commands you can use: " + 
				"'Go to...'; 'Use the...'; 'Hide in...'; 'Take the...'.)";
		
		if ((command.Contains("Take") || command.Contains("take")) && command.Contains("lamp"))			{myState = States.oillamp_0;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))		{myState = PreviousmyState;}
	}
	
	void table_1 () {
		text.text = "The bedside table has not changed. It is still small, round and old, with one of the three legs smaller " + 
			"than the others. You notice nothing else of particular importance. \n" + 
				"Maybe you should go back to the cell? ";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = PreviousmyState;}
	}
	
	void oillamp_0 () {
		text.text = "The ligh coming from the lamp is faint and cold. The oil lamp still has a little bit of oil " + 
			"and you decide to take it with you. You never know when you might need it. \n" + 
				"Type 'Go to cell' to return to explore the rest of the room.";
		// lamp = true;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cell") || (command.Contains("Return") || command.Contains("return")))			{myState = PreviousmyState;}
	}
	
	void corridor_0 () {
		text.text = "You open the door slightly, just enough to take a look outside. " + 
			"The corridor is dark and you cannot see anyone " + 
				"or hear anything. It is like the place is deserted. You take a " + 
				"deep breath and step outside. The door shuts firmly behind you! Your eyes are still adjusting to the darkness when " + 
				"you suddenly hear the steps of what sounds like more than one soldier. You rush to the side of the corridor and hit " +
				"a tall metalic cabinet. You fall to your knees and feel in your hands a new key that was one the floor. The sound is getting nearer and louder. \n" +
				"Test your luck and see if you can hide in time in the cabinet! Type 'Hide in the cabinet'";
		if ((command.Contains("Hide") || command.Contains("hide")) && command.Contains("cabinet") && (Random.Range(1,101) > 65))		{myState = States.gameover;}
		else if ((command.Contains("Hide") || command.Contains("hide")) && command.Contains("cabinet"))								{myState = States.cabinet_0;}
	}
	
	void gameover () {
		text.text = "The luck was not on your side! As you try to fit the newly found key in the cabinet's lock it slips through your fingers. " + 
					"The guards arrive and you notice that they look like monsters. Orc-like creatures just like the ones you read in fantasy books. " + 
				"They are too many to fight, you are overpower by them and one of the creatures smacks you in the head. " + 
				"You faint and fall into the floor. Somehow you think that this happened before.... \n\n" + 
				"GAME OVER!!!! Press P to play again.";
		if (Input.GetKeyDown(KeyCode.P))		{myState = States.intro;}
	}
	
	void cabinet_0 () {
		text.text = "The luck was on your side! Your eyes amazingly quickly adapt to the poor light in the corridor. " + 
			"You quickly fit the newly found key in the cabinet's lock and hide inside. " + 
				"While waiting for the guards to pass you notice some strange scratchs on the door. They form a text: \n" + 
				"'Don't trust him! Desk .... drawer.... press button.....' \n" + 
				"You have no idea what it means, but who ever wrote that seemed to be in a hurry. \n\n" + 
				"Type Continue or press Enter to procede.";
		if (Input.GetKeyDown(KeyCode.Return) || command.Contains("Continue") || command.Contains("continue"))		{myState = States.corridor_1;}
	}
	
	void corridor_1 () {
		text.text = "You wait what it seems like an eternity until you are sure you hear no guards and step outside. " + 
			"Your eyes are now perfectly adjusted to the darkness. You can see the tall metallic cabinet on your side, a door to another room and " + 
				"what it looks like an endless corridor. \n\n" + 
				"What should be your next move? Tip: You can now interact with the next room and the cabinet.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cabinet") && readDeskNote == true)		{myState = States.cabinet_2;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cabinet") && readDeskNote == false){myState = States.cabinet_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("room"))							{myState = States.room_0;}
	}
	
	void cabinet_1 () {
		text.text = "Nothing has changed inside the cabinet. The creepy message is still there: \n" + 
				"'Don't trust him! Desk .... drawer.... press button.....' \n" + 
				"You still don't know what it means, but who ever wrote that seemed to be in a hurry. \n\n" + 
				"Type Return or Go to corridor to go back.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor") || (command.Contains("Return") || command.Contains("return")))	{myState = PreviousmyState;}
	}
	
	void cabinet_2 () {
		text.text = "The creepy message is still there: \n" + 
			"'Don't trust him! Desk .... drawer.... press button.....' \n" + 
				"But now you feel conflicted. Should you trust the message on the desk or should you trust these scratchs. For some reason you feel an urge to " + 
				"push that hidden handle but you hesitate... \n\n" + 
				"What shall be your next command? Should you push the handle or go back?";
		if ((command.Contains("Push") || command.Contains("push")) && command.Contains("handle"))									{myState = States.ending_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && (command.Contains("back") || command.Contains("corridor")))	{myState = States.corridor_1;}
	}
	
	void ending_1 () {
		text.text = "A hidden door opens on the back of the cabinet. \n" + 
			"The passage is dark and upwards. A musty odor comes from the depths of the dark tunel. \n" + 
				"An urge to go upwards intensifies. It feels like you are about to have a closure to your questions. \n" + 
				"Why are you there? How did you end up there? \n" + 
				"At the top of the tunel a new wodden door. You open... \n" + 
				"A tall blond pale man with pointy fangs stands in front of you. A flash of memories flood your mind..... \n" + 
				"You have meet your MAKER! \n" + 
				"THE END!!!! Press P to play again!";
		if (Input.GetKeyDown(KeyCode.P))		{myState = States.intro;}
	}
	
	void room_0 () {
		text.text = "The room is tall and bigger than the prison cell you were but the walls are the same dark mossy stone. " + 
			"The room is dull and plain. There is only a desk in the center and a small round opening in the wall with some thick grids. " + 
				"The air coming from the window is cold but somehow you enjoy it. It is night. A pale light from the moon illuminates the desk.\n\n" + 
				"What should be your next move? Tip: Objects to interact are desk, window or corridor.";
		PreviousmyState = States.room_0;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor"))		{myState = States.corridor_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("desk"))	{myState = States.desk_0;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("window"))	{myState = States.window_0;}
	}
	
	void desk_0 () {
		text.text = "The desk looks like an old antique secretary. Made of solid dark wood with a small lamp pointing to an old paper.  " + 
			"The writing in the old paper is handmade with old fashioned letters. On the bottom of the letter an image of a skull just like the key you" + 
			" found in the cell. You read the text: \n" + 
				"Dear friend, \n" + 
				"I have been waiting for you for a long time. I have laid down for you helping keys along your journey. It is now time for you to take another " + 
				"leap of faith. If you dare go back to the cabinet and there you will find an hidden handle to push. " + 
				"Dare and all your questions shall be answered... your long forgotten memories remembered... \n" + 
				"From M \n" + 
				"Press Enter or Escape to continue. ";
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))		{myState = States.desk_0a;}
	}
	
	void desk_0a () {
		text.text = "Who is M? And has he been helping you all this time? Suddenly you remember the warning in the cabinet. You look to the drawer. " + 
				"It is locked and it won't budge, but then you look closer and find a button. \n" + 
				"Should you 'press the button'? Should you trust the warning or the note in front of you and 'go back'? It is time to decide which questions you want answered...";
		if ((command.Contains("Press") || command.Contains("press")) && command.Contains("button"))									{myState = States.ending_2;}
		else if ((command.Contains("Go") || command.Contains("go")) && (command.Contains("back") || command.Contains("room")))		{myState = PreviousmyState;}
	}
	
	void ending_2 () {
		text.text = "A hidden door opens on the wall behind you. " + 
			"The passage is dark and downwards. A fresh breeze comes from the depths of tunel and you can see a very pale light at the end. \n" + 
				"You step into the tunnel reluctantly. It feels like your questions might end up unanswered. \n" + 
				"But you have come this far and with a deep breath you start your descent. \n" + 
				"At the bottom of the tunel the moonlight almost blinds you. You are outside... at the bottom of a dark castle... in front of a dense forest.";
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))		{myState = States.ending_2a;}
	}
	
	void ending_2a () {
		text.text = "Is this the freedom you waited for? The unkwown awaits you, but with every step forward you feel that you are leaving something behind. \n" + 
				"You reach the border of the forest. A smile rises in your face... an inhuman strenght takes over your body... finally you feel like the forest is " + 
				"your new home... A new dark journey awaits you, and your new found quest for some blood....\n" + 
				"THE END!!!! Press P to play again!";
		if (Input.GetKeyDown(KeyCode.P))		{myState = States.intro;}
	}
	
	void window_0 () {
		text.text = "From the small window a fresh cold air breezes your face. The pale moonlight shines on your face. This revigorates you " + 
			"and you wonder to be outside in freedom. Then you notice that you are in what it looks like a castle and at the bottom you can see a dense dark forest. " + 
			" The forest does not look like a safe place from atop. \n" + 
				"Type the command to go roam the room again (return) ";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("room") || (command.Contains("Return") || command.Contains("return")))			{myState = PreviousmyState;}
	}
	
	void corridor_2 () {
		text.text = "You open the door slightly, just enough to take a look outside. " + 
			"The corridor is dark and you cannot see anyone " + 
				"or hear anything. It is like the place is deserted. You take a " + 
				"deep breath and step outside. The door shuts firmly behind you! With the help of the oil lamp you clearly see the corridor. " + 
				"You can see a tall metallic cabinet on your side, a strange key right next to the cabinet, a door to another room and " + 
				"what it looks like an endless corridor. \n\n" + 
				"What should be your next move? Tip: You can now interact with the next room, the cabinet or the key.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cabinet"))					{myState = States.cabinet_3;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("room"))				{myState = States.room_1;}
		else if ((command.Contains("Take") || command.Contains("take")) && command.Contains("key"))				{myState = States.key_0;}
	}
	
	void cabinet_3 () {
		text.text = "The metal cabinet is locked. You try to budge the door but without a key it won't open." +  
				"Type Return or press Enter to go back.";
		if (Input.GetKeyDown(KeyCode.Return) || command.Contains("Return") || command.Contains("return"))		{myState = States.corridor_2;}
	}
	
	void room_1 () {
		text.text = "The room is tall and bigger than the prison cell you were but the walls are the same dark mossy stone. " + 
			"The room is dull and plain. There is only a desk in the center and a small round opening in the wall with some thick grids. " + 
				"The air coming from the window is cold but somehow you enjoy it. It is night. A pale light from the moon illuminates the desk.\n\n" + 
				"What should be your next move? Tip: Objects to interact are desk, window or corridor.";
		PreviousmyState = States.room_1;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor"))		{myState = States.corridor_2;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("desk"))	{myState = States.desk_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("window"))	{myState = States.window_0;}
	}
	
	void desk_1 () {
		text.text = "The desk looks like an old antique secretary. Made of solid dark wood with a small lamp pointing to an old paper.  " + 
			"The writing in the old paper is handmade with old fashioned letters. On the bottom of the letter an image of a skull just like the key you" + 
				" found in the cell. You read the text: \n" + 
				"Dear friend, \n" + 
				"I have been waiting for you for a long time. I have laid down for you helping keys along your journey. It is now time for you to take another " + 
				"leap of faith. If you dare go back to the cabinet and there you will find an hidden handle to push. " + 
				"Dare and all your questions shall be answered... your long forgotten memories remembered... \n" + 
				"From M \n" + 
				"Press Enter or Escape to continue.";
		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))		{myState = States.desk_1a;}
		}
	
	void desk_1a () {
		text.text = "Who is M? And has he been helping you all this time? You make sure to remember the secret handle in the cabinet in case you go there. " + 
				"There is also a drawer you try to open but its closed. \n" + 
				"Type your command to go back and return to the room";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("room") || (Input.GetKeyDown(KeyCode.Return) || command.Contains("Return") || command.Contains("return")))	{myState = PreviousmyState;}
	}
	
	void key_0 () {
		text.text = "You pick up the key. The bow of the key has the same strange skull format of the first key you found. This one is smaller and rustier. \n" +  
			"Type Return or press Enter to go back to the corridor.";
		if (Input.GetKeyDown(KeyCode.Return) || command.Contains("Return") || command.Contains("return"))		{myState = States.corridor_3;}
	}
	
	void corridor_3 () {
		text.text = "Your eyes are now perfectly adjusted to the darkness to your surprise, you don't even need the lamp anymore. " + 
				"The tall metallic cabinet remains on your side, a door to another room on your left and " + 
				"the corridor remains endless. You dare not to adventure to those pits. \n\n" + 
				"What should be your next move? Tip: You can now interact with the next room and the cabinet.";
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cabinet") && readDeskNote == true)				{myState = States.cabinet_4;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("cabinet") && readDeskNote == false)		{myState = States.cabinet_5;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("room"))									{myState = States.room_2;}
	}
	
	void cabinet_4 () {
		text.text = "You enter the cabinet. It is higher than you and can perfectly fit inside. The door closes inside " + 
		"but the darkness as no effect on you anymore. You notice some strange scratchs on the door. They form a text: \n" + 
			"'Don't trust him! Desk .... drawer.... press button.....' \n" +
				"You remember the note you read while in the room. " + 
				"You feel conflicted. Should you trust the message on the desk or should you trust these scratchs. For some reason you feel an urge to " + 
				"push that hidden handle but you hesitate... \n\n" + 
				"What shall be your next command? Should you push the handle or go back?";
		if ((command.Contains("Push") || command.Contains("push")) && command.Contains("handle"))									{myState = States.ending_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && (command.Contains("back") || command.Contains("corridor")))	{myState = States.corridor_3;}
	}
	
	void cabinet_5 () {
		text.text = "You enter the cabinet. It is higher than you and can perfectly fit inside. The door closes inside " + 
		"but the darkness as no effect on you anymore. You notice some strange scratchs on the door. They form a text: \n" + 
			"'Don't trust him! Desk .... drawer.... press button.....' \n" + 
				"You have no idea what it means, but who ever wrote that seemed to be in a hurry. \n\n" + 
			"Type Return or press Enter to go back to the corridor.";
		if (Input.GetKeyDown(KeyCode.Return) || command.Contains("Return") || command.Contains("return"))		{myState = States.corridor_3;}
	}
	
	void room_2 () {
		text.text = "The room is tall and bigger than the prison cell you were but the walls are the same dark mossy stone. " + 
			"The room is dull and plain. There is only a desk in the center and a small round opening in the wall with some thick grids. " + 
				"The air coming from the window is cold but somehow you enjoy it. It is night. A pale light from the moon illuminates the desk.\n\n" + 
				"What should be your next move? Tip: Objects to interact are desk, window or corridor.";
		PreviousmyState = States.room_2;
		if ((command.Contains("Go") || command.Contains("go")) && command.Contains("corridor"))									{myState = States.corridor_3;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("desk") && readCabinetNote == true)		{myState = States.desk_0;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("desk") && readCabinetNote == false)	{myState = States.desk_1;}
		else if ((command.Contains("Go") || command.Contains("go")) && command.Contains("window"))								{myState = States.window_0;}
	}
	
}