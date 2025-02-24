#include "black_jack.h"
#include <stdio.h>

void initializeDeck(Card deck[]) {
    char *ranks[] = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    char *suits[] = {"Hearts", "Diamonds", "Clubs", "Spades"};
    int values[] = {2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11};

    int k = 0;
    for (int deck_count = 0; deck_count < 2; deck_count++) {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 13; j++) {
                deck[k].rank = ranks[j];
                deck[k].suit = suits[i];
                deck[k].value = values[j];
                k++;
            }
        }
    }
}

void shuffleDeck(Card deck[]) {
    for (int i = 0; i < DECK_SIZE; i++) {
        int r = rand() % DECK_SIZE;
        Card temp = deck[i];
        deck[i] = deck[r];
        deck[r] = temp;
    }
}

Card dealCard(Card deck[], int *current_card) {
    return deck[(*current_card)++];
}

int calculateHands(Card hand[], int num_cards) {
    int value = 0;
    int aces = 0;

    for (int i = 0; i < num_cards; i++) {
        value += hand[i].value;
        if (hand[i].value == 11) {  // Ace
            aces++;
        }
    }

    // Adjust for Aces if over 21
    while (value > 21 && aces > 0) {
        value -= 10;
        aces--;
    }

    return value;
}

void displayHand(Card hand[], int num_cards) {
    for (int i = 0; i < num_cards; i++) {
        printf("%s of %s\n", hand[i].rank, hand[i].suit);
    }
}

void playerTurn(Card deck[], int *current_card, Card player_hand[], int *player_cards) {
    char choice;
    do {
        printf("Do you want to hit or stand? (h/s): ");
        scanf(" %c", &choice);

        if (choice == 'h') {
            if (*player_cards < MAX_HAND_CARDS) {
                player_hand[(*player_cards)++] = dealCard(deck, current_card);
                printf("Your hand:\n");
                displayHand(player_hand, *player_cards);
            } else {
                printf("You cannot draw more cards. You must stand.\n");
                break;
            }
        }

    } while (choice == 'h' && calculateHands(player_hand, *player_cards) < 21);
}

void dealerTurn(Card deck[], int *current_card, Card dealer_hand[], int *dealer_cards) {
    while (calculateHands(dealer_hand, *dealer_cards) < 17) {
        if (*dealer_cards < MAX_HAND_CARDS) {
            dealer_hand[(*dealer_cards)++] = dealCard(deck, current_card);
        } else {
            break;
        }
    }

    printf("Dealer's hand:\n");
    displayHand(dealer_hand, *dealer_cards);
}

void checkWin(int player_total, int dealer_total) {
    if (player_total > 21) {
        printf("You busted! Dealer wins.\n");
    } else if (dealer_total > 21) {
        printf("Dealer busted! You win.\n");
    } else if (player_total > dealer_total) {
        printf("You win!\n");
    } else if (dealer_total > player_total) {
        printf("Dealer wins.\n");
    } else {
        printf("It's a push!\n");
    }
}
