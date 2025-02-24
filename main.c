#include "black_jack.h"
#include <stdio.h>

int main() {
    Card deck[DECK_SIZE];
    Card player_hand[MAX_HAND_CARDS], dealer_hand[MAX_HAND_CARDS];
    int player_cards = 0, dealer_cards = 0;
    int current_card = 0;

    srand(time(0));  // Initialize random seed

    initializeDeck(deck);
    shuffleDeck(deck);

    // Initial Deal
    player_hand[player_cards++] = dealCard(deck, &current_card);
    dealer_hand[dealer_cards++] = dealCard(deck, &current_card);
    player_hand[player_cards++] = dealCard(deck, &current_card);
    dealer_hand[dealer_cards++] = dealCard(deck, &current_card);

    printf("\nYour hand:\n");
    displayHand(player_hand, player_cards);

    // Display only the first dealer card
    printf("\nDealer's hand:\n");
    printf("%s of %s\n", dealer_hand[0].rank, dealer_hand[0].suit);
    printf("[Hidden Card]\n");

    // Player's turn
    playerTurn(deck, &current_card, player_hand, &player_cards);

    // Dealer reveals hidden card and takes turn if player hasn't busted
    if (calculateHands(player_hand, player_cards) <= 21) {
        printf("\nDealer reveals the hidden card:\n");
        displayHand(dealer_hand, dealer_cards);
        dealerTurn(deck, &current_card, dealer_hand, &dealer_cards);
    }

    int player_total = calculateHands(player_hand, player_cards);
    int dealer_total = calculateHands(dealer_hand, dealer_cards);

    // Call checkWin to determine the winner
    checkWin(player_total, dealer_total);

    return 0;
}
