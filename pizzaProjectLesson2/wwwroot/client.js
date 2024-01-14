let  basicUrl='https://localhost:7170/';
// let id=3;
function getAllPizzas(){
    fetch(`${basicUrl}Pizza`)
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
    fetch(`${basicUrl}Pizza/GetById/${id}`)
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
    let id=getLength();
    let name = document.getElementById("createName").value;
    let price = document.getElementById("createPrice").value;
    let gluten = document.getElementById("createGluten").checked;
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    let json = `{ \"id\": \ ${id}\,\"name\": \" ${name}\", \"gluten\": \ ${gluten}\,\"price\": \ ${price}\}`;
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

    var raw=`{ \"id\": \ ${id}\,\"name\": \" ${name}\", \"gluten\": \ ${gluten}\,\"price\": \ ${price}\}`;
    var requestOptions={
        method:'PUT',
        body:raw,
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

return pizzaList.Last().Id++;

}
