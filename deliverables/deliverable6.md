# Deliverable 6
## Introduction
Our Casino Shooter is a unique blend of casino-style games and shooter action. 
In our game, players engage in various classic card and casino games to determine their loadout, weapons, 
and abilities for the shooter phase. Based on how well you do in each game, you will earn different tiers of weapons, health, 
and other abilities for when you enter the shooter phase of our game. In the shooter phase, you will face an AI opponent and will 
be given rewards for winning.

https://github.com/TylerSturm/cs386-Project

## Requirements
Requirement: As a developer, I want the card games to be fully functional and have correct responses.  
Issue: https://github.com/TylerSturm/cs386-Project/issues/21  
Pull request: https://github.com/TylerSturm/cs386-Project/pull/22  
Implemented by: Daniel  
Approved by: Brodric  
Print screen: ![Image of ride the bus game.](/deliverables/rideGame.png)

Requirement: As a developer, I want our workspace to be neat and easy to understand  
Issue: https://github.com/TylerSturm/cs386-Project/issues/24  
Pull request: https://github.com/TylerSturm/cs386-Project/pull/23  
Implemented by: Tyler  
Approved by: Daniel  
Print Screen: N/A  

## Tests
**Test framework used:** Unity Test Framework  
**Link to Test folder:** https://github.com/TylerSturm/cs386-Project/tree/main/Tests  
**Class File link:** https://github.com/TylerSturm/cs386-Project/blob/main/code/Ride.cs  
**Test link:** https://github.com/TylerSturm/cs386-Project/blob/main/Tests/NewTestScript.cs  

In this test it will check to see if each section of the ride the bus game works. It will
tests for each section's correct and incorrect guess by the player.  

**Printout of Test results:**  
![Image of test results for ride the bus game.](/deliverables/rideTests.png)

## Demo
Link to Demo Video:  
https://youtu.be/uJxLErCi4K4  

## Code quality
As part of my tasks this week, I went through our code and changed how we switch between games to improve functionality. 
Originally, all of the assets were piled on top of each other in the same scene, causing clutter and making it difficult to 
tell which assets belonged to which game. To fix this, I made it so that each game has its own scene, spawning only the assets 
needed for that specific game when they are needed. With this change, we can address bugs much more easily for any individual game, 
rather than having to sort through every asset at once.

## Lessons Learned
We have been a lot better at getting work done on time and not doing it at the last second. We have figured out a better 
system to work on the shooter code altogether. We really don't have anything we want to change since we are making good progress and 
have the base game done essentially.
