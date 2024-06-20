const fs = require("fs");
const path = require("path");
const html = fs.readFileSync(path.resolve(__dirname, "../index.html"), "utf8");
const { JSDOM } = require("jsdom");

let dom;
let document;
let form;
let username;
let password;
let submitButton;
let usernameError;
let passwordError;

describe("login form", () => {
  beforeEach(() => {
    dom = new JSDOM(html, { runScripts: "dangerously", resources: "usable" });
    document = dom.window.document;

    form = document.querySelector("form");
    username = document.querySelector("#username");
    password = document.querySelector("#password");
    submitButton = document.querySelector("input[type=submit]");
    usernameError = document.querySelector("#js-username-error");
    passwordError = document.querySelector("#js-password-error");
  });

  test("should display username not found error", () => {
    username.value = "invalid";
    password.value = "admin";
    form.dispatchEvent(new dom.window.Event("submit"));
    expect(usernameError.textContent).toBe("Username not found");
  });

  test("should display password is incorrect error", () => {
    username.value = "admin";
    password.value = "invalid";
    form.dispatchEvent(new dom.window.Event("submit"));
    expect(passwordError.textContent).toBe("Password is incorrect");
  });

  test("should login successful", () => {
    username.value = "admin";
    password.value = "admin";
    form.dispatchEvent(new dom.window.Event("submit"));
    expect(passwordError.textContent).toBe("");
    expect(usernameError.textContent).toBe("");
  });
});
