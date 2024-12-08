var user=localStorage.getItem('data');
var userData=JSON.parse(user);

async function postItem()
 {
    var itemName = document.getElementById('itemName').value;
    var price = document.getElementById('price').value;
    var address = document.getElementById('address').value;
    var categories = document.getElementsByName('category').value;
    var conds = document.getElementsByName('cond').value;
    var desc = document.getElementById('itemDesc').value;
    var pictures = document.getElementById('pictures').value;
    for (var i = 0, length = categories.length; i < length; i++) {
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
        userId: userData.username,
        pictures: pictures
    };
    await postData("/UploadItem", data, false)
        .then(async (response) => {
            if (response.success) {
                alert('Sikeres hirdetés feladás!');
                window.location.href = "index.html";
            } else {
                alert(await response.message || 'Hiba történt a hirdetés feladása során!');
            }
        });
 }