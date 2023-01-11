

if (localStorage.getItem("basketProducts") != null) {
    basketProducts = JSON.parse(localStorage.getItem("basketProducts"))
}

let basketTableBody = document.querySelector(".basket-table")

for (const basketProduct of basketProducts) {
     
    basketTableBody.innerHTML += ` <tr>
    <td data-id="${basketProduct.Id}" class="flexitem">
        <div class="thumbnail object-cover">
            <a href="#">
                <img src="${basketProduct.Image}" alt="">
            </a>
        </div>
        <div class="content">
            <strong><a href="#">${basketProduct.Name}</a></strong>
            
        </div>
    </td>
    <td>${basketProduct.Price}</td>
    <td>
      <p>${basketProduct.Count}</p>
    </td>
    <td>$${basketProduct.Price * basketProduct.Count}</td>
    <td><a href="#"><i class="ri-close-line basket-delete-btn"></i></a></td>
</tr>`
}


document.querySelector(".basketItem-number").innerText = getBasketProductsCount(basketProducts);

function getBasketProductsCount(items) {
    let sum = 0;
    items.forEach(item => {
        sum += item.Count;
    })
    return sum;
}

const totalPrice = document.querySelector('.total-price')
function GetBasketTotalPrice() {
    let sum = 0;
    basketProducts.forEach(product => {
        sum += Number(product.Price)
    })
    totalPrice.textContent = `$${sum}`;
}
GetBasketTotalPrice();
let deleteBasketBtns = document.querySelectorAll(".basket-delete-btn");

if (deleteBasketBtns) {
    deleteBasketBtns.forEach(btn => {
        btn.addEventListener("click", function (e) {
            e.preventDefault();
            let id = parseInt(this.parentNode.parentNode.parentNode.parentNode.firstElementChild.getAttribute("data-id"));            

            basketProducts = basketProducts.filter(m => m.id == id);
            localStorage.setItem("basketProducts", JSON.stringify(basketProducts));

            this.parentNode.parentNode.parentNode.remove();
            GetBasketTotalPrice();
        })
    })
}
