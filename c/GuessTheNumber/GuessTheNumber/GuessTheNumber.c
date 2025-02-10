#include <stdio.h>
#include <stdlib.h>
#include <time.h>


//Objective:
//Create a simple "Guess the Number" game where the computer randomly selects a number between 1 and 100, and the user must guess the number.
//
//Requirements :
//
//	Random Number Generation :
//
//Use the standard library functions(such as rand() and srand()) along with <stdlib.h> and <time.h> to generate a random number between 1 and 100.
//Initialize the random number generator using the current time so that you get a different sequence each time the program runs.
//User Interaction :
//
//Prompt the user to guess the number.
//After each guess, provide feedback :
//If the guess is lower than the target number, display a message like "Too low! Try again."
//If the guess is higher than the target number, display a message like "Too high! Try again."
//If the guess is correct, congratulate the user and display the number of attempts they took.
//Input Validation :
//
//Ensure that the input is a valid integer.
//Handle cases where the user enters non - numeric data by clearing the input buffer and re - prompting the user.
//Looping and Replayability(Optional) :
//
//	After a successful guess, ask the user if they would like to play again.
//	If yes, restart the game; if no, gracefully exit the program.
//	Modular Design :
//
//Organize your code into functions.For example :
//A function to generate the random number.
//A function to get a valid guess from the user.
//A function to check the guess and provide feedback.
//The main game loop.
//Additional Challenges(Optional) :

	//Keep track of the best(lowest) number of guesses the user has taken in a session.
	//Add a limit on the number of guesses and display a "Game Over" message if the user exceeds that limit.


int generateRandomNumber() {
	srand((unsigned int)time(NULL));

	return rand() % 100 + 1;
}

int getValidGuessFromUser() {
	int usersAnswer = 0;
	char validNumberGiven = 'N';

	while (validNumberGiven != 'Y')
	{
		printf("Guess a number! \n");
		int userInput = scanf_s("%d", &usersAnswer);

		if (userInput != 1) {
			printf("You gave invalid input. Let's try again.\n");

			// Clear the invalid input from the buffer
			int ch;
			while ((ch = getchar()) != '\n' && ch != EOF); // discard characters

			usersAnswer = 0;  // reset to force re-prompt
			continue;
		}
		else {
			validNumberGiven = 'Y';
		}
	}
	return usersAnswer;
}

void displayResults(int rightAnswer, int amountOfGuesses) {
	printf("The right number was %d \n", rightAnswer);
	printf("It took you %d tries to get it right. \n", amountOfGuesses);
}

int askToPlayAgain() {
	int result = 0;

	while (result != 1 && result != 2) {
		printf("Want to play again? (1=Yes, 2=No)\n");
		scanf_s("%d", &result);
	}
	return result;
}


int main()
{
	int rightAnswer = generateRandomNumber();
	char isGameRunning = 'Y';
	int amountOfGuesses = 0;


	while (isGameRunning == 'Y') {
		int usersAnswer = getValidGuessFromUser();

		if (usersAnswer <= 0) {
			printf("You entered a negative number or zero. Please enter a positive number.\n");
		}
		else {
			if (usersAnswer < rightAnswer) {
				printf("You guessed too low!\n");
				amountOfGuesses++;
			}
			else if (usersAnswer > rightAnswer) {
				printf("Too guessed too high!\n");
				amountOfGuesses++;

			}
			else {
				printf("Correct!\n");
				amountOfGuesses++;

				displayResults(rightAnswer, amountOfGuesses);

				int playAgain = askToPlayAgain();

				if (playAgain == 1) {
					amountOfGuesses = 0;
					rightAnswer = generateRandomNumber();
				}
				else {
					isGameRunning = 'N';
				}
			}
		}
	}
	printf("Thanks for playing! \n");
	return 0;
}
