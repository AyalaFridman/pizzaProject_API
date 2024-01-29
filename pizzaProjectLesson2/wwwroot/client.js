let  basicUrl='https://localhost:7170/';
let Id=3;
function getAllPizzas(){
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    var requestOptions = {
        method: "GET",
        headers: myHeaders,
    };
    fetch(`${basicUrl}Pizza`,requestOptions)
    .then((res)=>res.json())
    .then((data)=>fillPizzaList(data))
    
    .catch(eror=>{console.log(eror)})
}
function fillPizzaList(pizzaList){
    var pizzabody=document.getElementById('pizzabody');
    var pizzahead=document.getElementById('pizzahead');
    pizzabody.innerHTML="";
    pizzahead.innerHTML=
    `<tr>
    <th>id</th>
    <th>name</th>
    <th>price</th>
    <th>isGluten</th>
</tr>`;
    pizzaList.forEach(Pizza=>{
        pizzabody.innerHTML+=`<tr>
        <td>${Pizza.id}</td>
        <td>${Pizza.name}</td>
        <td>${Pizza.price}</td>
        <td>${Pizza.gluten}</td>
        </tr>`
        
    });
}
function getById(){
    let id=document.getElementById("sendGetById").value;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    var requestOptions = {
        method: "GET",
        headers: myHeaders,
    };
    fetch(`${basicUrl}Pizza/GetById/${id}`,requestOptions)
    .then((res)=>res.json())
    .then((data)=>getPizzaById(data))
   
    .catch(eror=>{console.log(eror)})
    }
    function getPizzaById(data) {
        let tbody = document.getElementById('pizzabody');
        pizzahead.innerHTML=
        `<tr>
        <th>id</th>
        <th>name</th>
        <th>price</th>
        <th>isGluten</th>
    </tr>`;
        tbody.innerHTML= `<tr>
        <td>${data.id}</td>
        <td>${data.name}</td>
        <td>${data.price}</td>
        <td>${data.gluten}</td>
        </tr>`
        tbody.innerHTML += tr;
    }
    function create(){
    let name = document.getElementById("createName").value;
    let price = document.getElementById("createPrice").value;
    let gluten = document.getElementById("createGluten").checked;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    let json = `{ \"name\": \" ${name}\", \"gluten\": \ ${gluten}\,\"price\": \ ${price}\}`;
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: json,
        redirect: "follow",
    };
    fetch(`${basicUrl}Pizza`,requestOptions)
    .then((response) => response.text())
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to add!!")
        }
        else{
            alert("wowwwwwwwwwwwwwwwwwwwwwwww");
        }
    })
    .catch(err=>{console.log(err)})
}

function change(){
    let id =document.getElementById("changeId").value;
    let name = document.getElementById("changeName").value;
    let price = document.getElementById("changePrice").value;
    let gluten = document.getElementById("changeGluten").checked;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");

    var raw=`{ \"id\": \ ${id}\,\"name\": \" ${name}\", \"gluten\": \ ${gluten}\,\"price\": \ ${price}\}`;
    var requestOptions={
        method:'PUT',
        body:raw,
        headers:myHeaders,
        redirect:'follow'
    };

    fetch(`${basicUrl}Pizza/${id}`,requestOptions)
    .then(response => response.text())
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to change!!")
        }
        else{
            alert("you succsed to change");
        }
    })
    .catch(error => console.log('error', error));
}

function deleteById(){
    let id=document.getElementById("deleteById").value;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");

    var requestOptions = {
        method: "DELETE",
        headers: myHeaders,
        redirect: "follow",
    };

    fetch(`${basicUrl}Pizza/Delete/${id}`,requestOptions)
    .then((res) => res.json()) 
    .catch(err=>{console.log(err)})
}
function getLength(pizzaList){

return pizzaList.Last().Id+1;

}

//worker
let  basicUrlWorker='https://localhost:7170/Worker';
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
    let name = document.getElementById("changeNameWorker").value;
    let password = document.getElementById("changePasswordWorker").value;
    let role = document.getElementById("changeRoleWorker").value;
    var myHeaders = new Headers();
    var token=sessionStorage.getItem("token");
    myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    let json = `{ \"name\": \" ${name}\", \"password\": \ ${password}\,\"role\": \ ${role}\}`;
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

//order
function getAllOrder(){
    var myHeaders = new Headers();
    // var token=sessionStorage.getItem("token");
    // myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    var requestOptions = {
        method: "GET",
        headers: myHeaders,
    };
    fetch(`${basicUrl}Order`,requestOptions)
    .then((res)=>res.json())
    .then((data)=>fillOrderList(data))
    
    .catch(eror=>{console.log(eror)})
}
function fillOrderList(orderList){
    var orderbody=document.getElementById('orderbody');
    var orderhead=document.getElementById('orderhead');
    orderbody.innerHTML="";
    orderhead.innerHTML=
    `<tr>
    <th>phone</th>
    <th>date</th>
    <th>total amount</th>
</tr>`;
orderList.forEach(Order=>{
    orderbody.innerHTML+=`<tr>
        <td>${Order.phone}</td>
        <td>${Order.date}</td>
        <td>${Order.totalAmount}</td>
        </tr>`       
    });
}
let pizzasId=[];
let AmountItems=[];
function createOrder()
{
    let phone=document.getElementById("phone").value;
    let numOfCredit = document.getElementById("numOfCredit").value;
    let validity = document.getElementById("validity").value;
    let threeDigits = document.getElementById("threeDigits").value;
    var myHeaders = new Headers();
    // var token=sessionStorage.getItem("token");
    // myHeaders.append("Authorization","Bearer "+token);
    myHeaders.append("Content-Type", "application/json");
    let data={
        "id": 0,
        "phone":phone ,
        "date": "2024-01-28T18:45:37.219Z",
        "totalAmount": 0,
        "items":pizzasId ,
        "amountItems":AmountItems,
        "creditPaymentDetails": {
          "numOfCredit": numOfCredit,
          "validity": validity,
          "digits": threeDigits
        }
      }
    let json =JSON.stringify(data) ;
    var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: json,
        redirect: "follow",
    };
    fetch(`${basicUrl}Order`,requestOptions)
    .then((response) => response.text())
    .then((result)=>{
        if(result.includes("400")){
            alert("faild to add!!");
        }
        else{
            alert("wowwwwwwwwwwwwwwwwwwwwwwww");
        }
    })
    .catch(err=>{console.log(err)})
     pizzasId=[];
     AmountItems=[];
}
// function addPizza()
// {
//     let idPizza=document.getElementById("idOfPizza").value;
//     let amount = document.getElementById("amount").value;
//     var myHeaders=new Headers();
//     myHeaders.append("Content-Type", "application/json");
//     let json = `{ \"idOfPizza\": \" ${idPizza}\", \"amount\": \ ${amount}}`;
//     var requestOptions = {
//         method: "POST",
//         headers: myHeaders,
//         body: json,
//         redirect: "follow",
//     };
//     fetch(`${basicUrl}Order/postItem/${idPizza}/${amount}`,requestOptions)
//     .then((response) => response.text())
//     .then((result)=>{
//         if(result.includes("400")){
//             alert(`faild to add!! ${result}`);
//         }
//         else{
//             alert("wowwwwwwwwwwwwwwwwwwwwwwww");
//         }
//     })
//     .catch(err=>{console.log(err)})
// }

function addPizza()
{
   let idPizza=document.getElementById("idOfPizza").value;
   let amount = document.getElementById("amount").value; 
    pizzasId[pizzasId.length]=idPizza;
    AmountItems[AmountItems.length]=amount;
    if(idPizza==3)
    {
        alert("הזמנת את הפיצה הכי טעימה, בתאבון🍕😂")
    }
}

