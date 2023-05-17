
function loadData() {
    loadProducts();
    loadCategories();
    updateBagCount();
}

async function loadProducts() {
    const products = await fetchProduct();
    drowProducts(products);
}

async function fetchProduct() {
    const res = await fetch("api/products", {
        method: 'Get',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    const products = await res.json();
    return products;
}

function drowProducts(products) {
    document.getElementById('PoductList').innerHTML = null;
    const cards = products.map(product => designProduct(product));
    cards.forEach(card => document.getElementById('PoductList').appendChild(card))
}

function designProduct(product) {
    const card = createCard('#templateCard');
    card.querySelector('.image').src = `images/products/${product.image}`
    card.querySelector('.price').innerText = `$${product.price}`;
    card.querySelector('.description').innerText = product.description;
    card.querySelector('h1').innerText = product.name;
    card.querySelector('button').addEventListener('click', () => { addToBag(product)});

    return card;
}

function createCard(type) {
    const template = document.querySelector(type);
    const card = template.content.cloneNode(true);
    return card;
}


async function loadCategories() {
    const categories = await fetchCategories();
    drowCategories(categories);
}

async function fetchCategories(){
    const res = await fetch('api/categories', {
        mehtod: 'Get',
        headers: {
            'Content-type': 'application/json'
        }
    })
   
    const categories = await res.json();
    return categories;
}

function drowCategories(categories) {
    const designedCategories = categories.map(category => designCategory(category));
    designedCategories.forEach(category => document.querySelector('#categoryList').appendChild(category));
}


function designCategory(category) {
    const card = createCard('#templateCategory');
    card.querySelector('.OptionName').innerText = category.name;
    card.querySelector('.categoryOption').value = category.id;
    card.querySelector('.categoryOption').addEventListener('change', filterProducts);
    return card;
}

function filterProducts() {
    const categories=document.getElementsByClassName("categoryOption")
    const selectedCategories = [];
    for (let i = 0; i < categories.length; i++)
        if (categories[i].checked)
            selectedCategories.push(categories[i].value)

    const name = document.getElementById('nameSearch').value
    const minPrice = document.getElementById('minPrice').value
    const maxPrice = document.getElementById('maxPrice').value

    fetchFilteredProducts(selectedCategories, name, minPrice, maxPrice);
}

function generateFilterUrl(selectedCategories, name, minPrice, maxPrice) {
    let url = `?`;
    if (name)
        url += `name=${name}&`
    if (minPrice)
        url += `minPrice=${minPrice}&`
    if (maxPrice)
        url += `maxPrice=${maxPrice}&`
    if (selectedCategories.length > 0)
        url += `categoryIds=${selectedCategories.join('&categoryIds=')}&`

    return url;
}

async function fetchFilteredProducts(selectedCategories, name, minPrice, maxPrice) {
    const url=`api/products${generateFilterUrl(selectedCategories, name, minPrice, maxPrice)}`
    const res = await fetch(url, {
        method: 'Get',
        headers: {
            'Content-Type': 'application/json'
        },
    })
    const products = await res.json();
    drowProducts(products);

}

function addToBag(product) {
    const bag = JSON.parse(localStorage.getItem('bag')||'[]');
    newBag = [...bag, product];
    localStorage.setItem('bag', JSON.stringify(newBag));
    updateBagCount();
}

function updateBagCount() {
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    document.getElementById('ItemsCountText').innerText = bag.length;
}

//window.addEventListener('load', fetchProduct());
//document.body.addEventListener('load', fetchProduct());