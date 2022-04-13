import { render } from "react-dom";
import React from 'react';
import { useState, useEffect } from 'react';
 
function Clock(){
      const[date,setDate]=useState(new Date());
      
      function updateClock()
      {
            setDate(new Date());
      }

      useEffect(() => {
            const timerId = setInterval(updateClock, 1000);});
      
            return (
        <h1>
          {date.toLocaleTimeString()}
        </h1>
      );
    }
    
    export default Clock;
          

