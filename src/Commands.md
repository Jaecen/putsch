# Command Overview

## Commands

### Income

Increases the player's credits by one.

Command log

		Alex# income

		Alex:
			Credits: 2 -> 3


### Tax

Increases the player's credits by two. Can be blocked by the Duke.

		Alex# tax

		Block
			Ben:	pass
			Cindy:	pass
			Dan:	pass

		Alex:
			Credits: 2 -> 4

### Foreign Aid

Requires the Duke. Increases the player's credits by three.

		Alex# foreignaid

		Challenge
			Ben:	pass
			Cindy:	pass
			Dan:	pass

		Alex:
			Credits: 2 -> 5
		

### Steal

Requires the Captain. Takes two coins from a target and gives them to the player. If the target has less than two coins, then takes all of them. Can be blocked by the Captain or the Ambassador.

		Alex# steal cindy

		Challenge
			Ben:	pass
			Cindy:	pass
			Dan:	pass

		Block
			Ben:	pass
			Cindy:	pass
			Dan:	pass

		Alex:
			Credits: 7 -> 9

		Cindy:
			Credits: 5 -> 3
		

### Exchange

Requires the Ambassador. Takes two cards from the court deck, then returns two cards to the court deck.

		Alex# exchange

			Challenge
				Ben:	pass
				Cindy:	pass
				Dan:	pass

			Cards:
				Captain
				Duke
				Captain
				Assassin

		Alex# return duke

			Cards:
				Captain
				Captain
				Assassin

		Alex# return captain

			Cards:
				Captain
				Assassin

### Assasinate

Requires the Assassin. Decreases the player's credits by three. Reduces a target's influence by one. Can be blocked by the Contessa.

		Alex# assassinate dan

			Alex:
				Credits: 5 -> 2

			Challenge
				Ben:	pass
				Cindy:	pass
				Dan:	pass

			Block
				Ben:	pass
				Cindy:	pass
				Dan:	pass

			Cards:
				Duke
				Ambassador

		Dan# lose ambassador

			Dan:
				Influence: 2 -> 1

### Coup

Decreases the player's credits by three. Reduces the target's influence by one. Required action if the player has ten or more credits.

		Alex# coup ben

		Alex:
			Credits: 7 -> 0

		Ben:
			Influence: 1 -> 0
