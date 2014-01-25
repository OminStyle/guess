Vancouver Game Jam 2014

Theme: “We don't see them as they are, but see them as we are.”

Concept:
	Based on the idea of two people trying to guess what the other is thinking, we created the concept of Revelation. The game start with a completely obscured picture with a small portion randomly revealed. The first player can click somewhere on the image to reveal more of the image, then guess what the image is. (There is one or several correct answers for each picture). However, the second player can win the game by either guessing what the picture is correctly, or guess what the other player guessed. The game continues until either player guessed correctly (either the correct answer, or the other player's answer).

Aesthetics: (TODO)
•	What does Draw Something use?
•	Game-showy

Game Mechanics:

	Gameplay Overview
		The game start with a random image that is mostly obscured, with a small part revealed. Really not enough for any player to accurately guess what it is. Player 1 then has to 1) reveal some additional portion of the picture by clicking somewhere on the obscured image, and 2) Enter up to five words as guesses for what the image is. Player 1 is given points based on how many answer was guessed correctly, then player 2 takes his or her turn. Player 2 also gets to reveal part of the picture, and then make up to 5 guesses. In addition to guessing the correct answer, player 2 is also given points for any guesses that matches the player 1's answer. The game continues until all the correct answer has been guessed.
	Core Game Mechanics
•	Guessing the other player's answer:
◦	Because each player shares the same image, trying to guess what the other player is thinking is an interesting exercise.
◦	There is potentially problems of trying to guess what the other player is thinking is either pretty hard, or pretty easy. We can change the point awards of guessing the other player's answer to reflect the difficulty.
•	Revealing the image:
◦	This mechanic is used to keep the game from becoming too easy. By obscuring the image at first, it will be difficult to guess it right on the first try. But with more and more parts of the image revealed, it will not only be easier to guess the correct answer, but also make two player's answer approach each other.
•	Guessing the Correct Answer:
◦	Each image may have several correct answers. The game ends when all of an image's correct answer has been guessed.
◦	The correct answer serves as a goal for the game, but also create an opportunity cost for the players to try to guess each other's answer.
	Game Flow
•	Each game should take no longer than 5 minutes. Each round (two player's turns) should last about a minute at most. The revealing area should increases as the round number increases, so most of the picture should be revealed after a reasonable amount of rounds (requires prototyping / testing)


Art / Graphics
	We require art mostly for the interface elements, such as frames, scores, fonts. Maybe an interesting background image.

	Image selection: try it out with random sampling of image first. We want to remove images that are guessed correctly too fast, or ones that is just too ambiguous, or not common knowledge.

Audio / Music
	Several background tracks replayed throughout.
	SFX for the following:
•	Revealing part of an image
•	Starting game
•	Starting player's turn
•	Timer counting down
•	Entering guesses
•	Confirming Selection
•	Guessing correct answer
•	Guessing the other player's answer



Some Variations to Prototype:
•	Goal of the game: guess the words associated with the image

Variation 1
•	Each player take turn guessing the image
•	If another player repeats a guess from other player, that player is jinxed
•	Jinxed player cannot make guesses, but must try to guess what the other player will say to “unjinx” himself

•	What are the effects on player?
◦	Focused on predicting the other player's word.
◦	Sounds like it would be slightly difficult, because it depends on the image, and the image is not the same on your turn and their turn
•	Guesses needs to be hidden, and rule enforced by a medium
◦	Can previous turn guesses be revealed?
◦	Is there a time limit on the “jinx” guesses?

Variation 2
•	Each player take turn guessing the image
•	If a player guessed another player's previous guess, the other player is “read”
•	If you successfully read another player, you get some fixed amount of points.

•	Effect on player:
◦	Depending on the point amount, player have dual goal, of both trying to read what the other player's thinking, or guessing what the other player is thinking.
▪	Really in-sync people can get a lot of points by reading each other, but slower in getting the answer
▪	If we punish player for being read, does it feel un-fair for the player being read?


Variation 3
•	Each player take turn guessing the image
•	If a player guessed another player's previous guess, the other player is “read”
•	If a player was “read” 3 times, that player loses the game immediately.

•	Effect on Player:
◦	Player is more conservative about guessing their image, because they don't want the other person to read him or her.


Variation 4
•	Each player can guess as often as they want
•	Gets “read” whenever a player guesses the same after you guessed.

•	Effect on player:
◦	Make as many guesses as possible.
