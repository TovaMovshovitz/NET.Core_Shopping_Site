
async function loadUserDetails() {
        const user = JSON.parse(sessionStorage.getItem('user'));
        const { id, email, firstName, lastName } = user;
        document.getElementById("email").value = email;
        document.getElementById("firstName").value = firstName;
        document.getElementById("lastName").value = lastName;
        document.getElementById("heading").innerHTML = `Hello ${firstName} ${lastName}`;
        await setRate();
}

function shoping() {
    window.location.assign("./Products.html");
}

async function update() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    const { id } = user;
    const email = document.getElementById("email").value;
    const firstName = document.getElementById("firstName").value;
    const lastName = document.getElementById("lastName").value;

    const dataToSend = { id, email, firstName, lastName };
    const res = await fetch(`api/users/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(dataToSend)
    });
    const status = res.status;

    if (status === 200) {
        alert('User details have been updated. You will be taken to the login page.');
        window.location.assign('./home.html');
    } else {
        alert(`One or more details aren't valid. Response status: ${status}`);
    }
}

function showUpdate() {
    const updateDiv = document.querySelector('.update');
    const toUpdateA = document.getElementById('toUpdate');
    updateDiv.style.display = 'block';
    toUpdateA.style.display = 'none';
}

async function setRate() {
    const password = document.getElementById("userPassword").value;
    const strengthRate = await passwordRate(password);
    const progress = document.getElementById("strengh-rate");
    progress.value = strengthRate;
}

async function passwordRate(password) {
    const res = await fetch('api/PasswordStrength', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(password)
    });
    const strengthRate = await res.json();
    return strengthRate;
}
