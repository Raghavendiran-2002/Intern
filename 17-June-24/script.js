document.addEventListener("DOMContentLoaded", function () {
  fetch("https://dummyjson.com/products")
    .then((response) => response.json())
    .then((data) => {
      const productGrid = document.getElementById("product-grid");
      data.products.forEach((product) => {
        const productCard = document.createElement("div");
        productCard.className = "col";
        productCard.innerHTML = `
                    <div class="card h-100">
                        <img src="${product.thumbnail}" class="card-img-top" alt="${product.title}">
                        <div class="card-body">
                            <h5 class="card-title">${product.title}</h5>
                            <p class="category">${product.tags}</p>
                            <p class="card-text">${product.description}</p>
                            <div class="row">
                            <p class="col card-text">Stock : ${product.stock}</p>
                            <p class="col card-text">⭐️${product.rating}</p>
                            </div>
                            <p class="card-text"><strong>$${product.price}</strong></p>
                        </div>
                    </div>
                `;
        productGrid.appendChild(productCard);
      });
    })
    .catch((error) => console.error("Error fetching products:", error));
});
