let  basicUrlWorker='https://localhost:7170/Worker';
let Idl=3;
function getAllWorker(){
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    var requestOptions = {
        method: "GET",
        headers: myHeaders,
    };
    fetch(`${basicUrlWorker}`,requestOptions)
    .then((res)=>res.json())
    .then((data)=>fillWorkerList(data))
    
    .catch(eror=>{console.log(eror)})
}
function fillWorkerList(workerList){
    var workerbody=document.getElementById('workerbody');
    var workerhead=document.getElementById('workerhead');
    workerbody.innerHTML="";
    workerhead.innerHTML=
    `<tr>
    <th>id</th>
    <th>name</th>
    <th>password</th>
    <th>role</th>
</tr>`;
workerList.forEach(Worker=>{
    workerbody.innerHTML+=`<tr>
        <td>${Worker.id}</td>
        <td>${Worker.name}</td>
        <td>${Worker.password}</td>
        <td>${Worker.role}</td>
        </tr>`
        
    });
}
    function createWorker(){
    let id=Idl++;
    let name = document.getElementById("changeNameWorker").value;
    let password = document.getElementById("changePasswordWorker").value;
    let role = document.getElementById("changeRoleWorker").value;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    let json = `{ \"id\": \ ${id}\,\"name\": \" ${name}\", \"password\": \ ${password}\,\"role\": \ ${role}\}`;
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: json,
        redirect: "follow",
    };
    fetch(`${basicUrlWorker}`,requestOptions)
    .then((response) => response.text())
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to add!!")
            Id++;
        }
        else{
            alert("wowwwwwwwwwwwwwwwwwwwwwwww");
        }
    })
    .catch(err=>{console.log(err)})
}

function deleteByIdWorker(){
    let id=document.getElementById("deleteByIdWorker").value;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");

    var requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        redirect: "follow",
    };

    fetch(`${basicUrlWorker}/Delete/${id}`,requestOptions)
    .then((res) => res.json()) 
    .catch(err=>{console.log(err)})
}
// function getId()
// {
//     fetch(`${basicUrlWorker}`)
//     .then((res)=>res.json())
    
//     .catch(eror=>{console.log(eror)})

//     return res.Last().Id++;
// }
