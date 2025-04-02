import pytest
from models.card import Card
from models.deck import Deck
from models.player import Player

class Game: 
    def __init__(self): 
        newman = Player("Newman")
        jerry = Player("Jerry")
        self.players = [jerry, newman]
        self.table = []

    def play_game(self): 
        game_on = True
        deck = Deck()
        deck.shuffle_deck()
        for _ in range(26): 
            self.players[0].add_cards([deck.deal_one()])
            self.players[1].add_cards([deck.deal_one()])
        while game_on: 
            result, message = self.play_turn(self.players[0], self.players[1])
            print(message)
            if not result: 
                game_on = False

        print("Game over!")

    def play_turn(self, player1 : Player, player2: Player) -> tuple[bool, str]: 
        if len(player1.hand) > 0: 
            player1Card = player1.hand.pop(0)
            self.table.append(player1Card)
        else: 
            message = f"{player1.name} loses! He's out of cards!"
            return False, message
        
        if len(player2.hand) > 0: 
            player2Card = player2.hand.pop(0)
            self.table.append(player2Card)
        else: 
            message = f"{player2.name} loses! He's out of cards!"
            return False, message
        
        if player1Card.value == player2Card.value: 
            result, message = self.battle(player1, player2)
            return result, message
        elif player1Card.value > player2Card.value: 
            message = f"{player1.name} takes {player2.name}'s {player2Card} with a {player1Card}"
            player1.hand.extend(self.table)
            self.table.clear()
            
        else: 
            message = f"{player2.name} takes {player1.name}'s {player1Card} with a {player2Card}"
            player2.hand.extend(self.table)
            self.table.clear()
        
        message += f" {player1.name} has {len(player1.hand)} cards; {player2.name} has {len(player2.hand)} cards"
        
        return True, message


    def battle(self, player1: Player, player2: Player) -> tuple[bool, str]: 
        its_on = True
        draw_count = 3
        while its_on: 
            print("IT's WAR!!")
            if len(player1.hand) < draw_count + 1: 
                its_on = False
                message = f"{player1.name} can't play, the war is over. He's out of cards!"
                return message, False
            for _ in range(draw_count): 
                self.table.append(player1.hand.pop(0))
            player1Card = player1.hand.pop(0)
            self.table.append(player1Card)

            if len(player2.hand) < draw_count + 1: 
                its_on = False
                message = f"{player2.name} can't play, the war is over. He's out of cards!"
                return message, False
            for _ in range(draw_count): 
                self.table.append(player2.hand.pop(0))
            player2Card = player2.hand.pop(0)
            self.table.append(player2Card)

            if player1Card.value == player2Card.value: 
                continue
            elif player1Card.value > player2Card.value: 
                message = f"{player1.name} wins a handsome cache of {len(self.table)} cards"
                player1.hand.extend(self.table)
                self.table.clear()
                return message, True
            else: 
                message = f"{player2.name} wins a handsome cache of {len(self.table)} cards"
                player2.hand.extend(self.table)
                self.table.clear()
                return message, True

if __name__ == "__main__": 
    pytest.main([__file__])
    Game().play_game()