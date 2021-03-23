# Bass Line

## About
Fast-paced platformer/rhythm hybrid game in which the player must traverse expansive, ethereal, and perilous worlds by controlling a snake-like, cubic conga line (the “Bass Line”). Based off of the "Dancing Line" mobile game originally developed by Cheetah Mobile.

The controls are simple; tap/click the screen and the line will make alternating hard 90-degree turns. There are many obstacles and tricky paths, however, and the key to progressing in the game is to tap to the rhythm of the background music which acts as a guide to beating a level.

The Main Menu screen allows the player to select a level and also preview the background music that will play in that level, giving them the opportunity to prepare themselves for how the beat is going to go. 

There are also collectibles placed at select points in the stage where the player will have to pull off highly skilled maneuvers in order to grab them. Obtaining all collectibles and reaching the goal would represent 100% completion of a level.

## How To Play Current Build
Download the executable file `BassLine_ver.xxxx.exe` and the accompanying data ZIP file `BassLine_ver.xxxx_Data`. Then extract the contents of the ZIP file to the same folder where you have stored the executable before running it.

## Pending Features
- Planning to implement checkpoints and progress markers in the stage to show the player how far they have progressed in a level.
	- Checkpoints will give players the option to restart a level from a particular point if they die, rather than starting all the way at the beginning.
	- Checkpoints will be implemented by creating a set number of checkpoints at certain points throughout the level (maybe 10 checkpoints for each 10% increment of level completion), and then randomly choosing a few checkpoints to actually appear. In doing this, the player will not always know where the next checkpoint will be.
- Planning to add animations to the environment as the player traverse a level, adding another layer of difficulty and excitement to the game. This would include certain obstacles popping into or falling into the stage to really test the player’s reflexes.
	- Planning to polish the UI
	- Planning to create more levels

## Current Known Issues
- Issues with Explode() method in the TrailBehavior class, which was meant to simulate the explosion of the Bass Line into many fragments when it hits an obstacle. However, some of the fragments kept shooting off at breakneck speeds for reasons unknown; currently just settling for one fragment.
- Gravity:
	- When the Bass Line is touching the ground, gravity is turned off to allow the line to “slide” across the ground. When it is airborne, gravity is turned back on to allow it to fall.
	- During testing in which I played the game on different devices, the Bass Line fell faster on one device than another, meaning that certain areas became unreachable. This could possibly be due to the internal CPU clock of one device being faster than another, allowing gravity to be calculated faster and therefore have a greater influence on objects in the game.
	- Need to figure out a way to implement gravity and projectile motion in a platform independent manner so that the game behaves the same regardless of device.
