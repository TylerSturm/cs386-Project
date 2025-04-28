# Deliverbale 7
## Description
Our Casino Shooter is a unique blend of casino-style games and shooter action. 
In our game, players engage in various classic card and casino games to determine their loadout, weapons, and abilities for the shooter phase. 
Based on how well you do in each game, you will earn different tiers of weapons, health, and other abilities for when you enter the shooter phase of our game. 
In the shooter phase, you will face an AI opponent and will be given rewards for winning.
## Verification
Test framework used: Unity Test Framework  
Link to Test folder: https://github.com/TylerSturm/cs386-Project/tree/main/Tests  
We used mock objects in the Ride the Bus testing, utilizing a FakeDeckManager to force specific cards and test player behavior against those controlled cards. 
A similar approach was used in other tests, where we forced card values to validate game logic reliably.  

![Image of test results for ride the bus game.](/Tests/rideWB.png)

# Acceptance Test
Test framework used: Unity Test Framework

Link to Test Folder: https://github.com/TylerSturm/cs386-Project/tree/main/Tests  

In the Ride the Bus tests, we verify whether the user is correctly or incorrectly guessing card outcomes. 
In Unity, simulating key presses programmatically is difficult because our games rely heavily on player input. 
As a result, we were unable to fully automate input-based acceptance tests. 
However, through manual testing, we confirmed that the program behaves correctly during gameplay.  

![Image of test results for ride the bus game.](/Tests/rideBB.png)

# Validation

**User Evaluation 1:** Alex Deines interviewed by Brodric Martinez  
B - Hey Alex, do you have some time to check out a game some friends and I are making and give us some feedback?  
A - Yea I’m free right now. What’s the game about?  
B - Our game is combining traditional card games with a shooter game. You will play a card game and depending on your results you can get an advantage in the shooter.  
A - Sounds cool let me try it out.   
A - Plays card games and shooter  
B - Alright now what do you think of how the games are working? How about the design and how everything looks overall?  
A - Well the games do all work how they should but there wasn’t a bonus or something in the shooter part.  
B - Yea that’s the last thing we’re finishing up on so the bonus part isn’t actually working yet but will be soon. How about the looks? Can you score it 1-10?  
A - Honestly it doesn’t look especially great compared to other games and apps I think. I’d give it a 6/10.  
B - That’s fair we’re not professionals yet after all. What are your overall thoughts on the game?  
A - It’s a solid idea and can be fun once it’s fully done. It’s pretty good considering you guys are still students.  
B - Thanks for your time today. Your answers were very helpful to us.  

**User evaluation 2:** Seth Jenner interviewed by Tyler Sturm  
Tyler: Hey Seth, do you have a minute to do an interview for one of our classes?  
Seth: Sure, what’s it for?  
Tyler: We are making a game that mixes aspects of casino games with a top down shooter. We are looking to have people test it.  
Seth: *plays game*  
Tyler: So what did you think of the gameplay?  
Seth: It's an interesting idea that I haven't seen before and it seems to be well executed, but some of the card games seem a little bare bones.   
Tyler: That's understandable, what about the aesthetic and visuals of the game?  
Seth: The card games seem pretty basic, but I liked the retro look of the shooter part.   
Tyler: Overall what would you rate the experience?  
Seth: Honestly, I would give it like a 5/10. The idea is good and you have a solid base, there just seems to be a lot of refiling that needs to be done.  
Tyler: That all makes sense. Do you have any other suggestions that we could add?   
Seth: Since you are going for a casino theme, you could add a form of betting, either real money or just in game credits.  
Tyler: We have been discussing that exact idea but haven’t added it yet. Since you think it'll be a good addition we'll be sure to add it in the future. Thanks for all your help.  


**User evaluation 3:** Mark Meikle interviewed by Brodric Martinez  
B - Hey Mark, do you have some free time to try out a game me and some classmates are making?  
M - Yea sure I got time.  
B - Great! In this game we are combining some card games with a shooter game. You will play a card game first and depending on your results could get an advantage in the shooter game after.   
M - Sounds good let me try it out.  
M - Plays game  
B - Alright now that you’ve tried the game can I ask you some questions to help us get some feedback?  
M - Yea go ahead.  
B - First off, how would you compare our game to other games on the market?  
M - The idea is unique. I haven't seen a game that’s really like this. Little rough around the edges for s  ure but I can see the potential.   
B - Did anything stand out to you as either a strength or weakness of the game?
M - I think the idea of the game is a strength because there’s not any games like this that I’ve heard of. For a weakness I’d say probably the shooter part because there are games like that which are better.  
B - What do you think we can improve?  
M - Probably the shooter part. The card games all work and there’s not much to improve because they’re simple.  
B - Alright thanks for the feedback. Have a good rest of your day  

**Reflections:**  
Overall, I’d say the users we had try the game liked it for the most part. They liked the concept of the game, but all believed there was room for improvement. 
The card game features worked well, and there is practically no problem there with the functionality, but the design of the game could be improved. 
The learning curve is that some of the users did need to have the rules for some of the card games explained, so a rules page is something we can consider implementing. 
The users performed the tasks as expected after learning the rules of the card games, and the shooter game is pretty self-explanatory for that. 
I would say our value proposition is accomplished because we filled a niche with the game by combining card games and a shooter game, which isn’t really on the market, and the users found interesting.
