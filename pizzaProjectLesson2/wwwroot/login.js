let  basicUrl='https://localhost:7170/';
function login()
{
    sessionStorage.clear();
   let name = document.getElementById("nameLogin").value;
    let password = document.getElementById("passwordLogin").value;
    // var pizzabody=document.getElementById('pizzabody');
    // var pizzahead=document.getElementById('pizzahead');
    // var workerbody=document.getElementById('workerbody');
    // var workerhead=document.getElementById('workerhead');
    // pizzahead.innerHTML="";
    // pizzabody.innerHTML="";
    // workerhead.innerHTML="";
    // workerbody.innerHTML="";
    var json=`{\"name"\:${name},\"password\"\:${password}}`;
    var requestOptions=
    {
      method: "POST",
      body:json,
      redirect:'follow'

    };
    fetch(`${basicUrl}Login/${name}/${password}`,requestOptions)
    .then((res)=>res.text())
    .then((result)=>{
        sessionStorage.setItem("token",result);
        location.href="pizza.html";
     })

    .catch(err=>{console.log(err)})


}
