document.addEventListener("DOMContentLoaded", () => {
  const wordleGrid = document.getElementById("wordle-grid");
  const keyboard = document.getElementById("keyboard");
  const rows = 6;
  const cols = 5;
  const wordToGuess = "WEARY";

  let currentRow = 0;
  let currentCol = 0;
  let currentGuess = "";

  for (let i = 0; i < rows * cols; i++) {
    const cell = document.createElement("div");
    cell.classList.add("wordle-cell");
    wordleGrid.appendChild(cell);
  }

  const keys = ["QWERTYUIOP", "ASDFGHJKL", "ZXCVBNM"];

  keys.forEach((row) => {
    const rowDiv = document.createElement("div");
    rowDiv.classList.add("keyboard-row");
    row.split("").forEach((letter) => {
      const button = document.createElement("button");
      button.classList.add("btn", "btn-secondary");
      button.textContent = letter;
      button.addEventListener("click", () => handleKeyClick(letter));
      rowDiv.appendChild(button);
    });
    keyboard.appendChild(rowDiv);
  });

  const controlRow = document.createElement("div");
  controlRow.classList.add("keyboard-row");

  const enterButton = document.createElement("button");
  enterButton.classList.add("btn", "btn-secondary", "large");
  enterButton.textContent = "Enter";
  enterButton.addEventListener("click", handleEnter);
  controlRow.appendChild(enterButton);

  const backButton = document.createElement("button");
  backButton.classList.add("btn", "btn-secondary", "large");
  backButton.textContent = "Back";
  backButton.addEventListener("click", handleBackspace);
  controlRow.appendChild(backButton);

  keyboard.appendChild(controlRow);

  function handleKeyClick(letter) {
    if (currentCol < cols && currentRow < rows) {
      const cellIndex = currentRow * cols + currentCol;
      const cell = wordleGrid.children[cellIndex];
      cell.textContent = letter;
      currentGuess += letter;
      currentCol++;
    }
  }

  function handleBackspace() {
    if (currentCol > 0) {
      currentCol--;
      const cellIndex = currentRow * cols + currentCol;
      const cell = wordleGrid.children[cellIndex];
      cell.textContent = "";
      currentGuess = currentGuess.slice(0, -1);
    }
  }

  function handleEnter() {
    if (currentGuess.length === cols) {
      checkGuess(currentGuess);
      currentGuess = "";
      currentCol = 0;
      currentRow++;
    }
  }

  function checkGuess(guess) {
    for (let i = 0; i < cols; i++) {
      const cellIndex = currentRow * cols + i;
      const cell = wordleGrid.children[cellIndex];
      const letter = guess[i];

      if (letter === wordToGuess[i]) {
        cell.classList.add("correct");
      } else if (wordToGuess.includes(letter)) {
        cell.classList.add("present");
      } else {
        cell.classList.add("absent");
      }
    }
  }

  const buttons = document.querySelectorAll("#keyboard button");
  buttons.forEach((button) => {
    button.addEventListener("click", () => {
      button.style.transform = "scale(0.9)";
      setTimeout(() => {
        button.style.transform = "scale(1)";
      }, 100);
    });
  });
});
