async function login() {
    var uName = document.getElementById('uName').value;
    var password = document.getElementById('pw').value;
    if (isEmpty(uName) || isEmpty(password)) {
        alert('Felhasználónév és jelszó megadása kötelező!');
    } else {
        var data = {
            uName: uName,
            password: password
        };
        await postData("auth/login", data, false)
            .then(async (data) => {
                if (await data.token) {
                    localStorage.setItem("data", JSON.stringify(data));
                    window.location.href = "index.html";
                } else {
                    alert(await data.Message);
                }
            });
    }
}

function isEmpty(str) {
    return (!str || 0 === str.length);
}