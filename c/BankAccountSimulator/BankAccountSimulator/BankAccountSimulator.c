#include <stdio.h>

//Assignment: Basic Bank Account Simulator
//Objective :
//Create a menu - driven program in C that simulates a simple bank account.The program will allow the user to check their balance, deposit funds, withdraw funds, and exit the program.
//
//Requirements :
//
//    Initial Setup :
//
//Start with an initial balance(for example, $1000).
//Menu Options :
//
//Display a text - based menu with options :
//Check Balance : Display the current balance.
//Deposit : Allow the user to deposit an amount into their account.
//Withdraw : Allow the user to withdraw an amount from their account.
//Exit : End the program.
//Input Validation :
//
//Validate all user inputs.For example, when the user enters a menu option or an amount, ensure that :
//The input is numeric.
//The deposit amount is positive.
//The withdrawal amount is positive and does not exceed the current balance.
//If invalid input is detected, display an error message and prompt the user again.
//Looping Behavior :
//
//Use a loop to display the menu repeatedly until the user chooses to exit.
//Modular Design :
//
//Create separate functions for tasks such as :
//Displaying the menu.
//Processing deposits.
//Processing withdrawals.
//Checking the balance.
//Validating numeric input.
//Optional Enhancements :
//
//Transaction History : Keep a record of each deposit and withdrawal in an array and display a summary upon exit.
//Custom Initial Balance : Prompt the user to set an initial balance at the start of the program.
//Error Handling : Enhance input handling by clearing the input buffer for invalid entries(similar to previous assignments).
//Guidelines :
//
//    Plan Your Functions :
//Think about what operations you need(like displayMenu(), deposit(), withdraw(), and getValidInput()) and how they will interact.
//
//Input Handling :
//Use scanf_s(or scanf with proper input clearing) to capture user input.Validate the input by checking the return value, and if invalid, clear the input buffer.
//
//User Feedback :
//Provide clear messages for both successful operations(e.g., "Deposit successful!") and errors(e.g., "Insufficient funds!").
//
//Code Readability :
//Use proper formatting and comments to make your code easy to read and maintain.
//


int currentBalance = 1000;

void displayMenu();
void showMenuOptions();
void checkBalance();
void deposit();
void withdraw();


void showMenuOptions() {
	int chosenOption;

	printf("1. Check Balance\n");
	printf("2. Deposit\n");
	printf("3. Withdraw\n");
	printf("4. Exit\n");
	printf("Choose an option: ");
	scanf_s("%d", &chosenOption);

	switch (chosenOption) {
	case 1:
		checkBalance();
		break;
	case 2:
		deposit();
		break;
	case 3:
		withdraw();
		break;
	case 4:
		exit(0);
		break;
	default:
		printf("Invalid option. Please try again.\n");
		showMenuOptions();
		break;
	}
}

void displayMenu() {
	printf("### Users Nönnöö Bank Account ###\n");
	printf("# Current Balance: %d #\n", currentBalance);
	showMenuOptions();
}

	void checkBalance() {
		printf("Your current balance is: %d\n", currentBalance);
		displayMenu();
	}

	void deposit() {
		int amount;
		printf("Enter the amount to deposit: ");
		scanf_s("%d", &amount);
		if (amount > 0) {
			currentBalance += amount;
			printf("Deposit successful!\n");
		}
		else {
			printf("Invalid amount. Please try again.\n");
		}
		displayMenu();
	}


	void withdraw() {
		int amount;
		printf("Enter the amount to withdraw: ");
		scanf_s("%d", &amount);
		if (amount > 0 && amount <= currentBalance) {
			currentBalance -= amount;
			printf("Withdrawal successful!\n");
		}
		else {
			printf("Invalid amount or insufficient funds. Please try again.\n");
		}
		displayMenu();
	}



int main()
{
	displayMenu();
    return 0;
}


