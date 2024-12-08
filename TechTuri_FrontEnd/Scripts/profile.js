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
        document.getElementById("profileData").innerHTML=
        `</br>${userData.username} </br>`;
        document.getElementById("uName").innerHTML=
        `${userData.username}`;
        document.getElementById("fullName").innerHTML=
        `${userData.name}`;
        document.getElementById("regDate").innerHTML=
        `${userData.joinDate}`;
    } 
}