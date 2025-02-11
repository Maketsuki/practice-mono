#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int generateRandomNumber() {
	srand((unsigned int)time(NULL));

	return rand() % 100 + 1;
}

int getValidGuessFromUser() {
	int usersAnswer = 0;
	char validNumberGiven = 'N';

	while (validNumberGiven != 'Y')
	{
		printf("Guess a number between 1 and 100! \n");
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
			if (usersAnswer > 0 && usersAnswer < 100) {
				validNumberGiven = 'Y';
			}
			else {
				printf("Give number between 1-100 \n");
			}
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
	int triesLeft = 15;
	int lowestGuess = 0;
	int highestGuess = 0;
	int lastGuess = 0;
	int usersAnswer = 0;

	while (isGameRunning == 'Y') {
		if (triesLeft == 0) {
			printf("Game is over!\n");

			int playAgain = askToPlayAgain();

			if (playAgain == 1) {
				amountOfGuesses = 0;
				triesLeft = 15;
				lowestGuess = 0;
				highestGuess = 0;
				lastGuess = 0;
				usersAnswer = 0;
				rightAnswer = generateRandomNumber();
			}
			else {
				isGameRunning = 'N';
			}
		}
		else {
			printf("You have %d tries left.\n", triesLeft);
		}

		lastGuess = usersAnswer;
		usersAnswer = getValidGuessFromUser();

		if (usersAnswer <= lastGuess) {
			lowestGuess = usersAnswer;
		}

		if (usersAnswer >= lastGuess) {
			highestGuess = usersAnswer;
		}

		if (usersAnswer <= 0) {
			printf("You entered a negative number or zero. Please enter a positive number.\n");
		}
		else {
			if (usersAnswer < rightAnswer) {
				printf("You guessed too low!\n");
				amountOfGuesses++;
				triesLeft--;
			}
			else if (usersAnswer > rightAnswer) {
				printf("Too guessed too high!\n");
				amountOfGuesses++;
				triesLeft--;
			}
			else {
				printf("Correct!\n");
				amountOfGuesses++;
				triesLeft--;

				displayResults(rightAnswer, amountOfGuesses);

				int playAgain = askToPlayAgain();

				if (playAgain == 1) {
					amountOfGuesses = 0;
					triesLeft = 15;
					lowestGuess = 0;
					highestGuess = 0;
					lastGuess = 0;
					usersAnswer = 0;
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