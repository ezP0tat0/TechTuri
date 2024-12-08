var user=localStorage.getItem('data');
var userData=JSON.parse(user);

window.onload=function()
{
    //if(user===null)
    //    {
    //        logout();
    //    }

    displayUserInfo();
    showItems();
}
function displayUserInfo()
{
    
    if(user)
    {
        document.getElementById("profileData").innerHTML=
        `</br>${userData.name} </br>`;
    } 
}
function logout()
 {
    try
    {
        localStorage.clear();
        window.location.replace("login.html");
    }
    catch(error)
    {
        console.error("logout error: ",error);
    }
 }