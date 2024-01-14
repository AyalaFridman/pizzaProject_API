let basicUrl='https://localhost:7170/';

function login(){
    fetch(`${basicUrl}/Login`)
    .then((res)=>res.json())
    .then((data)=>print(data))

    .catch((eror)=>console.log(eror))
}
function print(data){
    let hhh=document.getElementById('hhh');
    hhh.innerHTML=data;

}