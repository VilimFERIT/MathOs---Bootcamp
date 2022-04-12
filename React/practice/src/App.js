import logo from './logo.svg';
import './App.css';
import React from 'react';
import InputForm from './InputForm';
import Clock from './Clock';

function App() {
  return (
    <div className="App">
      <header className="App-header">
       
        {element}
        <InputForm/>
        <Clock/>

        
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        
      
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
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
