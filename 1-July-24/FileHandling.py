from pathlib import Path
from datetime import datetime
Path('.').exists()

def check_file_exists(path):
    return (Path(path).exists())
    
def read_file(filename):
    with open(filename, 'r') as file:
        content = file.read()
        print(content)
    
def write_file(filename, content):
    with open(filename, 'w') as file:
        file.write(content)
def append_file(filename, content):
    with open(filename, 'a') as file:
        file.write(content)

def read_file_line_by_line(filename):
    with open(filename, 'r') as file:
        for line in file:
            print(line.strip())

check_file_exists('.')
read_file('File.txt')
write_file('File.txt', 'Hello, World! ')
append_file('File.txt', f'\nThis is a new line. {datetime.now()}')
read_file_line_by_line('File.txt')