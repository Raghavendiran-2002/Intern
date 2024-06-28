# Sort score and name of players print the top 10

players = [('John', 100), ('Alice', 85), ('Bob', 92), ('Charlie', 78), ('David', 95), ('Eve', 80), ('Frank', 98), ('Grace', 82), ('Harry', 90), ('Isabella', 87)]
def get_score(player):
    return player[1]

sorted_players = sorted(players, key=get_score)

top_10_players = sorted_players[:10]
for player in sorted_players:
    print(f'Name : {player[0]}, Score : {player[1]}')