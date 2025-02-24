#ifndef BLACK_JACK_H
#define BLACK_JACK_H

// header files
#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// global definitions
#define MAX_HAND_CARDS 11
#define DECK_SIZE 104

// data types
typedef struct {
    char *rank;
    char *suit;
    int value;
} Card;

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
void initializeDeck(Card deck[]);

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
void shuffleDeck(Card deck[]);

/**
 * Function:
 * Input argument:
 * Output argument:
 * Return:
 * Dependencies:
 */
Card dealCard(Card deck[], int *current);

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
int calculateHands(Card hand[], int num_cards);

/**
 * Function:
 * Input argument:
 * Output argument:
 * Return:
 * Dependencies:
 */
void displayHand(Card hand[], int num_cards);

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
void playerTurn(Card deck[], int *current_card, Card player_hand[], int *player_cards);

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
void dealerTurn(Card deck[], int *current_card, Card dealer_hand[], int *dealer_cards);

/*
Function:
Input argument:
Output argument:
Return:
Dependencies:
*/
void checkWin(int player_total, int dealer_total);

#endif // BLACK_JACK_H



