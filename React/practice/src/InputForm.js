import './InputForm.css';
import Table from './Table';
function InputForm() {
    return (
      <div>
    <form>
 <ul>
  <li>
    <label for="name">fame:</label>
    <input type="text" id="name"/>
  </li>
  <li>
    <label for="mail">Email:</label>
    <input type="email" id="mail"/>
  </li>
  <li>
    <label for="msg">Message:</label>
    <textarea id="msg"></textarea>
  </li>
 </ul>
 <input type="submit"></input>

</form>

      </div>
    );
  }




  export default InputForm;