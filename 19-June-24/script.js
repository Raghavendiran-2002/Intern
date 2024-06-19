const quotesPerPage = 5;
let currentPage = 1;
let quotesData = [];
const sortAscButton = document.getElementById("sortAsc");
const sortDescButton = document.getElementById("sortDesc");

$(document).ready(function () {
  fetchQuotes();

  $("a.nav-link").on("click", function (e) {
    e.preventDefault();
    const target = $(this).attr("href").substring(1);
    $("section").hide();
    $(`#${target}`).show();
  });
});

function fetchQuotes() {
  $.get("https://dummyjson.com/quotes", function (data) {
    quotesData = data.quotes;
    displayQuotes();
    setupPagination();
  });
}

function displayQuotes() {
  const start = (currentPage - 1) * quotesPerPage;
  const end = start + quotesPerPage;
  const quotesToShow = quotesData.slice(start, end);

  let html = "";
  quotesToShow.forEach((quote) => {
    html += `<blockquote class="blockquote">
                    <p>${quote.quote}</p>
                    <footer class="blockquote-footer">${quote.author}</footer>
                </blockquote>`;
  });
  $("#quotes-container").html(html);
}

async function searchQuotes() {
  let html = "";
  const author = $("#author").val();
  quotesData.forEach((quote) => {
    $("#quotes-search-container").css("background-color", "#e9e7e7");
    $("#quotes-search-container").css("padding", "20px");
    $("#quotes-search-container").css("border-radius", "10px");

    if (quote.author === author) {
      html += `<blockquote class="searchblockquote">
                    <p>${quote.quote}</p>
                    <footer class="blockquote-footer">${quote.author}</footer>
                </blockquote>`;
    }
    if (html === "") {
      html = "<p class='text-center'> No results found </p>";
    }
    $("#quotes-search-container").html(html);
  });
}
function setupPagination() {
  const totalPages = Math.ceil(quotesData.length / quotesPerPage);

  let paginationHtml = "";
  for (let i = 1; i <= totalPages; i++) {
    paginationHtml += `<li class="page-item ${
      i === currentPage ? "active" : ""
    }">
    <a class="page-link" href="#">${i}</a>
    </li>`;
  }
  $("#pagination").html(paginationHtml);

  $(".page-link").on("click", function (e) {
    e.preventDefault();
    currentPage = parseInt($(this).text());
    displayQuotes();
    setupPagination();
  });
}

sortAscButton.addEventListener("click", () => {
  sortAscButton.classList.add("active");
  sortDescButton.classList.remove("active");
  loadQuotes(currentPage, searchInput.value, "asc");
});

sortDescButton.addEventListener("click", () => {
  sortAscButton.classList.remove("active");
  sortDescButton.classList.add("active");
  loadQuotes(currentPage, searchInput.value, "desc");
});
