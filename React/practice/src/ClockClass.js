import { render } from "react-dom";
import React from 'react';
import { useState, useEffect } from 'react';
 
class ClockClass extends React.Component{
    constructor(props)
    {
        super(props);
        this.state={date: new Date()};
    }
      
    componentDidMount() 
    {
    setInterval(() => this.updateClock(),1000);
      } //lifecycle metode
    
    updateClock()
      {
            this.setState({date: new Date()});
      }  

            render() 
            {
                return (
                <div>
                <h2>The current time is:</h2>
                <h1>{this.state.date.toLocaleTimeString()}</h1>
                    </div>);
            }
    }
    
    export default ClockClass;