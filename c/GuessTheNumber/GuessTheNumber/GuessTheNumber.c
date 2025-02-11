#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_TRIES 15

int generateRandomNumberBetween1And100() {
	return rand() % 100 + 1;
}

int getValidGuessFromUser(int lowerBound, int upperBound) {
	int usersAnswer = 0;
	int inputResult;

	while (1)
	{
		printf("Guess a number between %d and %d: ", lowerBound, upperBound);
		int userInput = scanf_s("%d", &usersAnswer);

		if (userInput != 1) {
			printf("You gave invalid input. Let's try again.\n");

			// Clear the invalid input from the buffer
			int ch;
			while ((ch = getchar()) != '\n' && ch != EOF); // discard characters
			continue;
		}

		if (usersAnswer < lowerBound || usersAnswer > upperBound) {
			printf("Please enter a number within the specified range (%d-%d).\n", lowerBound, upperBound);
			continue;
		}
		break;
	}
	return usersAnswer;
}

void displayResults(int rightAnswer, int amountOfGuesses) {
	printf("\nCorrect! The right number was %d.\n", rightAnswer);
	printf("It took you %d tries to get it right.\n", amountOfGuesses);
}

// Returns 1 for Yes and 2 for No
int askToPlayAgain() {
	int result = 0;
	int inputResult;

	while (1) {
		printf("Want to play again? (1 = Yes, 2 = No): ");
		inputResult = scanf_s("%d", &result);

		if (inputResult != 1) {
			printf("Invalid input. Please enter 1 or 2.\n");
			int ch;
			while ((ch = getchar()) != '\n' && ch != EOF);
			continue;
		}
		if (result == 1 || result == 2) {
			break;
		}
		else {
			printf("Please enter 1 for Yes or 2 for No.\n");
		}
	}
	return result;
}

int main()
{
	srand((unsigned int)time(NULL)); // Here we seed the random generator.

	char isGameRunning = 'Y';

    while (isGameRunning == 'Y') {
        // Initialize game state for each new game.
        int rightAnswer = generateRandomNumberBetween1And100();
        int amountOfGuesses = 0;
        int triesLeft = MAX_TRIES;
        int lowerBound = 1;
        int upperBound = 100;

        printf("\n=== Welcome to Guess the Number! ===\n");

        // Game loop: user has a limited number of tries.
        while (triesLeft > 0) {
            printf("\nYou have %d tries left.\n", triesLeft);
            int guess = getValidGuessFromUser(lowerBound, upperBound);

            // Tick the values
            amountOfGuesses++;
            triesLeft--;

            if (guess < rightAnswer) {
                printf("You guessed too low!\n");
                if (guess + 1 > lowerBound) {
                    lowerBound = guess + 1;
                }
            }
            else if (guess > rightAnswer) {
                printf("You guessed too high!\n");
                if (guess - 1 < upperBound) {
                    upperBound = guess - 1;
                }
            }
            else {
                // Correct guess.
                displayResults(rightAnswer, amountOfGuesses);
                break;
            }

            // Optionally, display a hint using the updated bounds.
            printf("Hint: Try a number between %d and %d.\n", lowerBound, upperBound);

            if (triesLeft == 0) {
                printf("\nGame over! You've run out of tries.\n");
                printf("The correct number was %d.\n", rightAnswer);
            }
        }

        // Ask the user if they want to play again.
        int playAgain = askToPlayAgain();
        if (playAgain == 1) {
            // Restart the game.
            continue;
        }
        else {
            isGameRunning = 'N';
        }
    }
	printf("Thanks for playing! \n");
	return 0;
}