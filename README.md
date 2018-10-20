# BeatShooter
This was an exercise in taking a concept and quickly implementing a version of it within a short amount of time. This focus was on implementing a firing mechanism that is syncopated to the given tempo and the player is able to switch between three different beat divisions. Using these divisions, the player can break blocks to the corresponding beat types.

### Beat Divisions and Blocks
1 (default) is a quarter note division - breaks red blocks

2 is an eighth note division - breaks green blocks

3 is a sixteenth note division - breaks blue blocks


Initial implementation of this system is a infinitely shooting player object and the player can manually switch between the different beat types to break the blocks. Once those blocks are all removed, a new set is created and this continues on until the player hits escape to quit the application.

## Why
Besides diving head first into Unity, another reason is to explore various systems that are normally activated by players and setting constraints but finding other ways of making it fun. With the concept of tying it to the music/environment being experienced, this has the potential to further immersion within the application. Current plans for iterating on this idea:

* Scoring system - Giving a reason to progress through a level or be good at a level
* Also create levels with specific grid patterns, to add ontop of the scoring system
* Using the implemented audio analyzer to create a reactive environment
* Potentially a level editor
* Random infinite level based on streaming music(depends on what is available)


After these are expanded upon, the potential to create it as a full application is also a possibility as well as looking into potential mobile devices
