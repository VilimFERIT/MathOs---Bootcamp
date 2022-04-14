import React from 'react';

class ComplaintForm extends React.Component{
    constructor(props)
    {
        super(props);
        this.state={complaints: [''], counter:0};
        //this.handleComplaintInput = this.handleComplaintInput.bind(this);
        //this.handleComplaintChange = this.handleComplaintChange.bind(this);
    }

  
/*
      handleComplaintInput(event) {
        event.preventDefault();
        const { complaints} = this.state;
        this.setState({complaints: [...this.state.complaints,complaints], counter: this.state.counter +  1,});  
        console.log(this.state);   
      }

      handleComplaintChange(event, complaint) {
        const { complaints } = this.state;
        complaints[complaint] = event.target.value;
        this.setState({complaints});
      }*/

   addComplaint = (event) => {
        event.preventDefault();

        let info = document.forms["complaintForm"]["complaint"].value;
        let primjer = {complaints: [...this.state.complaints, info] } 

        console.log(info);
        this.setState(primjer)
          //const listOfComplaints =this.state.complaints.map(complaint =><p>{complaint}</p>);
        this.setState({counter: this.state.counter +  1});
      };

    /*countComplaint()
    {
      this.setState({counter: this.state.counter +  1});
    }*/


    
        
    //<input type="submit" onClick={this.addComplaint} {this.countComplaint}></input>
    render()
    {
      const { complaints} = this.state;
      return(
        <div>
          <h3>Please file your anonymous complaints below</h3>
          <h4>There are {this.state.counter} complaints</h4>
          <form name="complaintForm">
          <ul>
          <li>
          <textarea id="complaint" ></textarea>
          </li>  
          </ul>
          
          <input type="submit" onClick={this.addComplaint}></input>
          </form>

          <pre>
          {this.state.complaints.map(complaint =><p>{complaint}</p>)}
          
        </pre>
        
        </div>
      )
    }
  }
//{this.state.complaints.map(complaint =><p>{complaint}</p>)}  
//{complaints.map((complaint) => (<p>{complaint}</p>))}
  export default ComplaintForm;