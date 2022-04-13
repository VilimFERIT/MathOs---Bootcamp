import './InputForm.css';
import Table from './Table';
import React, { useEffect, useState } from "react";
import App from './App';
import addContact from './App';

function InputForm() {

  

  const [contacts, updateContacts] = useState([]);

  const addContact = (contactInfo) => {
    updateContacts([...contacts, contactInfo]);
  };
  
  const[contactInfo, setContactInfo]= useState({
    name:"",
    email:"",
    message:"",
  })

  const listOfContactInfo = contacts.map(contact =><p>{contact.name} {contact.email} {contact.message}</p>);

  

  const handleNameInputChange = (event) => {
    setContactInfo((values) => (
      {
      ...values, name: event.target.value, //... je spread operator tj pamti prijasnji state
    }
    ));
  };

  const handleEmailInputChange = (event) => {
    setContactInfo((values) => (
      {
      ...values, email: event.target.value,
    }
    ));
  };

  const handleMessageInputChange = (event) => {
    setContactInfo((values) => (
      {
      ...values, message: event.target.value,
    }
    ));
  };
  
  const handleSubmit = (event) => {
    event.preventDefault();
    addContact(contactInfo);
    console.log(contactInfo);
    setContactInfo({ name: "", email: "", message: "" });
  };


    return (
      <div>
    <form name="inputForm">
 <ul>
  <li>
    <label for="name">Name:</label>
    <input type="text" id="name" value={contactInfo.name} onChange={handleNameInputChange}/>
  </li>
  <li>
    <label for="mail">Email:</label>
    <input type="email" id="mail" value={contactInfo.email} onChange={handleEmailInputChange}/>
  </li>
  <li>
    <label for="msg">Message:</label>
    <textarea id="msg" value={contactInfo.message} onChange={handleMessageInputChange} ></textarea>
  </li>
 </ul>
 <input type="submit" onClick={handleSubmit}></input>




<p name="info"></p>
</form>

<pre>
   {listOfContactInfo}
 </pre>
      </div>


    );
  }

  

 


 /* const inputArray = [];

  function getInput(event)
  {
    event.preventDefault();
    let name = document.forms["inputForm"]["name"].value;
    let email = document.forms["inputForm"]["mail"].value;
    let message = document.forms["inputForm"]["msg"].value;

    let contact = {
      name: " ",
      email: " ",
      message:" "
  }
       contact.name = document.getElementById("name").value;
      contact.email = document.getElementById("mail").value;
      contact.message = document.getElementById("msg").value;

        inputArray.push(contact);

        document.getElementById("info").innerHTML = JSON.stringify(inputArray, null, 2);

  }*/

  export default InputForm;