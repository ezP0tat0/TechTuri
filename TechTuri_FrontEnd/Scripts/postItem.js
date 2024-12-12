var user=localStorage.getItem('data');
var userData=JSON.parse(user);

async function postItem()
 {
    var itemName = document.getElementById('itemName').value;
    var price = document.getElementById('price').value;
    var address = document.getElementById('address').value;
    var categories = document.getElementsByName('category');
    var conds = document.getElementsByName('cond');
    var desc = document.getElementById('itemDesc').value;

    const pictures = new FormData();
    const picturesInput = document.getElementById("pictures");
    for (let i = 0; i < picturesInput.files.length; i++) {
        pictures.append("pictures", picturesInput.files[i]);
    }

    for (var i = 0; i < categories.length; i++) {
        if (categories[i].checked) {
          var category = categories[i].value;
          break;
        }
    }
    for (var i = 0, length = conds.length; i < length; i++) {
        if (conds[i].checked) {
          var cond = conds[i].value;
          break;
        }
    }
    if (isEmpty(itemName) || isEmpty(price) || isEmpty(address) || isEmpty(category) || isEmpty(cond) || isEmpty(desc) || isEmpty(pictures)) {
        alert('Minden mező kitöltése kötelező!');
        return;
    }
    var data = {
        name: itemName,
        description: desc,
        price: price,
        category: category,
        condition: cond,
        location: address,
        username: userData.username
    };
     JSON.stringify(data);
    console.log(data);
    await postData("Item/upload", data, false)
        .then(async (response) => {
            if (!response.success) {
                alert(await response.message || 'Hiba történt a hirdetés feladása során!');
            }
        });
    var data2 = {
        pictures: pictures
    };
     const response = await fetch("http://localhost:5263/api/Item/pictures", {
        method: "POST",
        body: data2
    });

    const result = await response.json();
    console.log(result);
     
 }
 function isEmpty(str) {
    return (!str || 0 === str.length);
}

