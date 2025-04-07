# Deliverable 5: Design
## Description  
Our Casino Shooter is a unique blend of casino-style games and shooter action. In our game, players engage 
in various classic card and casino games to determine their loadout, weapons, and abilities for the shooter 
phase. Based on how well you do in each game, you will earn different tiers of weapons, health, and 
other abilities for when you enter the shooter phase of our game. In the shooter phase, you will face an AI 
opponent and will be given rewards for winning.

# Architecture  
We designed our game so the user will interact by pressing buttons that will be displayed on the screen. 
The UI will be managed by a system to determine which casino card game they are going to play and then the shooter 
game once done with card games. The card games will share info whether they won or lost and what the outcome was, busted 
by 1 or got 3 out of 4 correct in ride the bus. This will be shared with the shooter game to determine weapons health etc.

![Image](/deliverables/package.pdf)

# Class Diagrams   

# Sequence Diagrams  
Player plays a card game, gets advantage for the shooter game based on winning or losing, then plays the shooter game.

![Image of the UML diagram](/deliverables/class.pdf)

# Design Patterns 
State Pattern (Behavioral)

Decorator Pattern (Structural)





# Design Principles  
How does your design observe the SOLID principles? Provide a short description of the following principles giving three concrete examples from your classes.

S - Single responsibility - In our code, each of the games is in its own class, giving each class a certain function of running a singular game and switching to the next once the game ends.

O - Open/Closed - The way our code is structured allows for us to add more features after the current games we have without changing their functionality or structure.

I - Interface segregation - Our game functions in a way that only one game mode is on the screen or running at a time, making it easy for the user to know what they are supposed to be doing.
