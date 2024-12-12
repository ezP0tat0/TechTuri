var user=localStorage.getItem('data');
var userData=JSON.parse(user);

window.onload=function()
{
    displayUserInfo();
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
function ProfileData()
{
    fetch('User/UserInfo')
    .then(response => {
        if (!response.ok) {
            throw new Error('Failed to fetch profile data');
        }
        return response.json();
    })
    .then(data => {
        document.getElementById('uName').textContent = data.username || '';
        document.getElementById('fullName').textContent = data.name || '';
        document.getElementById('regDate').textContent = data.joinDate || '';
    })
    .catch(error => {
        console.error('Error fetching profile data:', error);
    });
}

function ProfileDataChange()
{
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

    fetch('User/ChangeInfo', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(requestData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to update profile data');
            }
            return response.json();
        })
        .then(data => {
            alert('Profile updated successfully!');
            window.location.href = 'profile.html';
        })
        .catch(error => {
            console.error('Error updating profile data:', error);
            alert('Failed to update profile. Please try again.');
        });
}