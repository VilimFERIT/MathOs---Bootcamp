import logo from './logo.svg';
import './App.css';
import InputForm from './InputForm';
import Clock from './Clock';
import React, { useEffect, useState } from "react";
import ClockClass from './ClockClass'
import ComplaintForm from './ComplaintForm'
import Product from './Product'
import ProductGetById from './ProductGetById';
import ProductPut from './ProductPut';



//komentar
function App() {

  return (
    <div className="App">
      <header className="App-header">
       
        {element}
        <Product/>
      
        
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>

        

        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >Learn React</a>
      </header>
    </div>
  );
}

const element = React.createElement(
  'h1',
  {className: 'greeting'},
  'Hello, user!'
);

export default App;
