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
function ProfileData()
{
    //ezeket kapod:
    //username
    //name
    //joinDate
    
    //adj username-t hozzá
    
}

function ProfileDataChange()
{
    //adj:
    //originalUsername
    //username
    //name
    //password
    //ha valami üres az legyen 0 hosszú string 
}