function alertName() {
    var input = document.getElementById('userInput').value;
    alert(input);
}

let x,y,z;

x=3;
y=6;

let arrayOfMixedDataTypes = [12, "string", null];

console.log(arrayOfMixedDataTypes);

arrayOfMixedDataTypes.push(9);

console.log(arrayOfMixedDataTypes);

function validateForm() {
    let x = document.forms["myForm"]["fname"].value;
    if (x == "") {
      alert("Ovo polje ne smije ostati prazno");
      return false;
    }
  }

let  example =(function(){
    console.log("something");
  })

  const person = new Object();
  person.firstName = "John";
  person.lastName = "Johnson";


