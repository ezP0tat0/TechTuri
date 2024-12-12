var user=localStorage.getItem('data');
var userData=JSON.parse(user);

window.onload=function()
{
    ProfileData();
}
function displayUserInfo()
{
    
    if(user)
    {
        document.getElementById("uName").innerHTML=
        `${userData.username}`;
        document.getElementById("fullName").innerHTML=
        `${userData.name}`;
        document.getElementById("regDate").innerHTML=
        `${userData.joinDate}`;
    } 
}
async function ProfileData() {
    try {
        const data = await getData('User/UserInfo');
        var date = data.joinDate.toLocaleDateString();
        document.getElementById('uName').textContent = data.username || '';
        document.getElementById('fullName').textContent = data.name || '';
        document.getElementById('regDate').textContent = date || '';
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
        alert('Profile updated successfully!');
        window.location.href = 'profile.html';
    } catch (error) {
        console.error('Error updating profile data:', error);
        alert('Failed to update profile. Please try again.');
    }
}