async function loadData() {
    const products=await loadProducts();
    //drowProducts(products);
    setTitles(products);
}

function drowProducts(products) {
    const designedProducts = products.map(product => designProduct(product));
    designedProducts.forEach(product => document.body.appendChild(product));
}

async function loadProducts() {
    const bag = await localStorage.getItem('bag') || '[]'
    return JSON.parse(bag);
}

function setTitles(products) {
    const itemCount = products.length;
    document.querySelector('#item-count').innerText = itemCount;
    let totalAmount = 0;
    products.forEach(product => totalAmount += product.price);
    document.querySelector('#total-amount').innerText = totalAmount;
}

function designProduct(product) {
    const card = createCard('#template-product-card');
    card.querySelector('.description-column').querySelector('.item-name').innerText = product.name;
    card.querySelector('.price').innerText = product.price;
    clone.querySelector(".image-column-img").src = `../images/products/${p.imagePath}.jpg`;
    //clone.querySelector(".descriptionColumn h3").innerText = p.productName;
    //clone.querySelector(".descriptionColumn p").innerText = 1;
    //clone.querySelector(".expandoHeight a").onclick = () => { removeItem(p.productId) }
    //document.querySelector("tbody").appendChild(clone);
    return card;
}

function createCard(type) {
    const template = document.querySelector(type);
    const card = template.content.cloneNode(true);
    return card;
}

function emptyBag() {
    localStorage.setItem("bag",[]);
    loadData();
}
