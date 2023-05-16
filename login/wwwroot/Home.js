

async function signUp() {
    const email = document.getElementById("new-email").value;
    const password = document.getElementById("new-password").value;
    const firstName = document.getElementById("first-name").value;
    const lastName = document.getElementById("last-name").value;

    const dataToSent = {
        email,
        password,
        firstName,
        lastName
    };

    const res = await fetch("api/users", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });

    const status = res.status;

    if (status == 200) {
        alert('user signed up successfully');
        showSignIn();
    } else if (status == 601) {
        alert(`Password too weak. Please choose a stronger password. res.status = ${status}`);
    } else if (status == 602) {
        alert(`Password is on a blacklist. Please choose a different password. res.status = ${status}`);
    } else {
        alert(`one or more details aren't valid res.status = ${status}`);
    }
}

async function signIn() {
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const dataToSent = {
        email,
        password
    }
    const res = await fetch('api/users/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });


    if (res.status == 204) {
        alert('user name or password are incorrect');
    } else if (res.status == 200) {
        const user = await res.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        window.location.assign("./UserDetails.html");
    } else {
        alert(`res.status = ${status}`);
    }
}

function showSignUp() {
    const signInDiv = document.querySelector('.signin');
    const signUpDiv = document.querySelector('.signup');

    signInDiv.style.display = 'none';
    signUpDiv.style.display = 'block';
}

function showSignIn() {
    const signInDiv = document.querySelector('.signin');
    const signUpDiv = document.querySelector('.signup');

    signInDiv.style.display = 'block';
    signUpDiv.style.display = 'none';
}

async function setRate() {
    const password = document.getElementById("new-password").value;

    const result = await fetch("api/password", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });


    const strengthRate = await result.json();
    const progress = document.getElementById("strength-rate");
    progress.value = strengthRate;
}
