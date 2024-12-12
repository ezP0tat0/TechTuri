var user=localStorage.getItem('data');
var userData=JSON.parse(user);

window.onload=function()
{
    ProfileData();
}
function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [year, month, day].join('.');
}
async function ProfileData() {
    try {
        const data = await getData('User/UserInfo/'+userData.username);
        var d=Date(data.joinDate);
        console.log(d);
        document.getElementById('uName').textContent = data.username || '';
        document.getElementById('fullName').textContent = data.name || '';
        document.getElementById('regDate').textContent = formatDate(d) || '';
    } catch (error) {
        console.error('Error fetching profile data:', error);
    }
}

async function ProfileDataChange() {
    const originalUsername = document.getElementById('uName').textContent || '';
    const username = document.getElementById('editUName').value || '';
    const name = document.getElementById('editName').value || '';
    const password = document.getElementById('editPw').value || '';

    const requestData = {
        originalUsername: originalUsername,
        username: username,
        name: name,
        password: password
    };

    try {
        const response = await postData('User/ChangeInfo', requestData);
        alert('Sikeresen frissítette az adato(ka)t!');
        window.location.href = 'profile.html';
    } catch (error) {
        console.error('Error updating profile data:', error);
        alert('Sikertelen mentés. Kérjük próbálja újra!');
    }
}