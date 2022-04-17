import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function ProductPost() {


    const [products, insertProduct] = useState([]);   

    const getProductById = (event) => {
        event.preventDefault();
        let price = document.forms["productForm"]["price"].value;
        let title = document.forms["productForm"]["title"].value;
        let stock = document.forms["productForm"]["stock"].value;
        let countryOfOrigin = document.forms["productForm"]["country"].value;
        console.log(id);
        axios.put('https://localhost:44343/webapi/insertproductmla?Price='+ price +'&Title=' +title+'&Stock='+stock+'&countryOfOrigin=' + countryOfOrigin).then((response)=>{
            console.log(response.data);
            insertProduct(response.data);
        })
        .catch(error => console.error('Error!'));
    }

    /*addProduct = (event) => {
        event.preventDefault();
        let info = document.forms["productForm"]["product"].value;
        console.log(info);
        this.setState(primjer)
      };*/

      return (
        <div>
            <form name="productForm">
          <ul>
          <li>
          <textarea id="price" ></textarea>
          </li>  
          <li>
            <textarea id="title" ></textarea>
            </li>

            <li>
            <textarea id="stock" ></textarea>
            </li>

            <li>
            <textarea id="country" ></textarea>
            </li>
          </ul>
          
          <input type="submit" onClick={getProductById}></input>
          </form>

        <pre>
        {products.map(product=><li>{product.Price} {product.Name} {product.Id}</li>)}
        </pre>
        </div>
  
  
      );
    }