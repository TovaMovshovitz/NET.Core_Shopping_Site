
async function signUp() {
    const button = document.getElementById("singUp-button");
    button.disable = true;
    button.innerHTML = "wait...";

    if (!isPasswordValid()) {
        button.disable = false;
        button.innerHTML = "Sign Up";
    }

    const password = document.getElementById("new-password").value;
    const email = document.getElementById("new-email").value;
    const firstName = document.getElementById("first-name").value;
    const lastName = document.getElementById("last-name").value;
    
    const dataToSent = {
        email,
        password,
        firstName,
        lastName
    };

    const res = await fetch("api/users/signUp", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });

    const status = res.status;

    if (status == 200) {
        showSignIn();
    }
    else {
        document.getElementById("singUpError").innerHTML = "one or more details aren't valid";
        button.disable = false;
        button.innerHTML = "Sign Up";
    }
}

function isPasswordValid(){
    const passwordRate = document.getElementById("strength-rate").value;
    if (passwordRate < 2) {
        document.getElementById("singUpError").innerHTML = "The password is not strong enough";
        return false;
    }

    const password = document.getElementById("new-password").value;
    if (password.length < 5) {
        document.getElementById("singUpError").innerHTML = "The password is not long enough";
        return false;
    }
    return true;
}

async function signIn() {
    const button = document.getElementById("singIn-button");
    button.disable = true;
    button.innerHTML = "wait...";

    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const dataToSent = {
        email,
        password
    }
    const res = await fetch('api/users/signIn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(dataToSent)
    });

    handleSignInResponse(res)
}

async function handleSignInResponse(res) {

    const error = document.getElementById("singInError");

    if (res.status == 401) {
        error.innerHTML = 'user name or password are incorrect';
    }
    else if (res.status == 200) {
        const user = await res.json();
        sessionStorage.setItem("user", JSON.stringify(user));
        const urlParams = new URLSearchParams(window.location.search);
        const flag = await urlParams.get("fromShoppingBag")

        if (flag)
            window.location.assign("./shoppingBag.html");
        else
            window.location.assign("./UserDetails.html");
    }
    else {
        error.innerHTML = `res.status = ${status}`;
    }
    const button = document.getElementById("singIn-button");
    button.disable = false;
    button.innerHTML = "Sign In";
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

    const result = await fetch("api/PasswordStrength", {
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
