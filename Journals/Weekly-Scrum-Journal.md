# Weekly Team Scrum Journal

## Week 1

### 1. What tasks did I work on / complete?
* Clifton Francis
	* Downloaded and installed Unity
	* Unity Tutorials completed:
		- Basic tutorials 1 - 4
		- Roll a ball

	* Created and added tasks to Scrum task board
	* Create UI wireframe for level 1 prototype and level 2
	* Added new cross platform Unity project for game code
	* Configured Unity project for Git compatibility
	* Integrated over prototype code to our cross platform project
	* Added timer, current level text, and game object skeleton for win/lose text

* Animesh Grover
	* Downloaded and installed Unity
	* Read and watched unity tutorials
	* Added sprint task board template
	* Created the map and terrain for level 1
	* added assets to the project
	* Added potential enemy sprite to the project

* Watcharit Maharutainont
	* Downloaded and installed Unity
	* Went through Unity tutorials
	* Implemented animation for the movement of main character
	* Wrote a script for main character's movement
	* Implemented object collision detection for player and items

* Phani Teja Kantamneni
	* Downloaded and installed unity
	* Completed the unity tutorials and gained insights into how the components work
	* Browsed through the asset store and got hold of a few sprites for items
	* Wrote a prototype script for fixed path enemy movement, using waypoints

### 2. What am I planning to work on next?

* Clifton Francis
	* Find asset(s) for player sprite
	* Add rigid body on terrain for collision detection

* Animesh Grover
	* Working with Enemy movement script
	* Utilizing Unity AI for enemy movement
	* Getting more enemy sprites for other levels
	* Working with terrain collision detection

* Watcharit Maharutainont
	* Find item assets
	* Implement animation for items usage

* Phani Teja Kantamneni
	* Add 2D Collider components to detect collision between player and enemy
	* Trigger an event on Player-Enemy collision (The player character loses life)
	* Find the assets for enemy sprite


### 3. What tasks are blocked waiting on another team member?

* Accessing public variables of other game objects
* Waiting for enemy sprite to be created and eventually killed to display win/lose text

## Week 2

### 1. What tasks did I work on / complete?

* Clifton Francis
	* Added player collision detection with terrain to avoid travelling though objects
	* Found Assets for enemy sprites and items
	* Edited sprite sheets and imported sprites into project
* Animesh Grover
	* Added and updated Enemy movement
	* looked into Enemy collision logic
	* discussed and added few enemy sprites and stated using it in project
* Watcharit Maharutainont
	* Fixed bug - object rotation when collision occurred
	* Added interfaces for Enemy and GameSystem objects
	* Implemented MovePattern class to route enemies, based on configuration file
	* Minor refactored codes for enemies movement
	* Implemented animations for items
* Phani Teja Kantamneni
	* Added player-enemy collision detection
	* Added an event trigger, whenever the player comes in direct contact with the enemy, the player sprite is disabled and "You Lose" text is displayed

### 2. What am I planning to work on next?

* Clifton Francis
	* Decide on design pattern to implement
	* Design level 5
	* Begin implementing level 5
* Animesh Grover
	* looking into Unity AI
	* Implementing more complex enemy movements
	* Implement Enemy damage and misc events
* Watcharit Maharutainont
	* Implement GameSystem class template
	* Implement enemies factory
	* Implement enemy animations
* Phani Teja Kantamneni
	* Add an event to display "You Lose" text when the enemy reaches the destination without being killed by the player
	* Implement the funtionality to store the type of items collected by the player, based on the Tag of the item
	* Add functionality for the usage of items collected by the player

### 3. What tasks are blocked waiting on another team member?
* N/A

## Week 3

### 1. What tasks did I work on / complete?

* Clifton Francis
	* Decided to work on Main Menu. I will be applying the design command pattern for the buttons.
	* Went through the Creating a Main Menu Unity tutorial
	* Looked into designing a main menu using just code as opposed to Unity's GUI.
	* Design concepts for Level 5
* Animesh Grover
	* Decided to work with enemy sprites and movement and try to implement decorator pattern.
	* Going through examples and tutorial that explain how to spawn different type of enemies
	* went through tutorials and played around with enemy related events

* Watcharit Maharutainont
	* Implemented GameSystem and GameLevel1 templates
	* Implemented enemies factory
	* Implemented enemy animations
	* Implemented spawning template for enemies

* Phani Teja Kantamneni

### 2. What am I planning to work on next?

* Clifton Francis
	* Implement the game's main menu with the command design pattern
	* Begin implementing level 5
* Animesh Grover
	* Implement Design pattern into the Enemy spawn logic.
	* Complete Level 3 implementation

* Watcharit Maharutainont
	* Implement items factory
	* Add more animations

* Phani Teja Kantamneni

### 3. What tasks are blocked waiting on another team member?
* Phani was having issues placing items in a location relative to the player's coordinates.
	* Clifton will help with finding out how to implement this functonality.
