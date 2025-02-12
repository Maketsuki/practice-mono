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


void displayMenu() {
    int _tempNumber = 1000;
    printf("### Users Nönnöö Bank Account ###\n");
    printf("# Current Balance: %d #\n", _tempNumber);
}



int main()
{
    return 0;
}


