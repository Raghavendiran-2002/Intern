import random

def generate_secret_number():
    """Generate a 4-digit secret number."""
    digits = list(range(10))
    random.shuffle(digits)
    return digits[:4]

def get_user_guess():
    """Get user's guess as a 4-digit number."""
    while True:
        guess = input("Enter your guess (4 digits): ")
        if len(guess) != 4 or not guess.isdigit():
            print("Invalid guess. Please enter a 4-digit number.")
        else:
            return list(map(int, guess))

def calculate_cows_and_bulls(secret_number, user_guess):
    """Calculate the number of cows and bulls in the user's guess."""
    cows = 0
    bulls = 0
    for i in range(4):
        if user_guess[i] == secret_number[i]:
            cows += 1
        elif user_guess[i] in secret_number:
            bulls += 1
    return cows, bulls

def play_game():
    """Play the Cow and Bull game."""
    secret_number = generate_secret_number()
    score = 0
    while True:
        user_guess = get_user_guess()
        cows, bulls = calculate_cows_and_bulls(secret_number, user_guess)
        score += 1
        print(f"Cows: {cows}, Bulls: {bulls}")
        if cows == 4:
            print(f"Congratulations! You guessed the secret number in {score} attempts.")
            break

play_game()