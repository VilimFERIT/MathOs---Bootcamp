import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function ProductGetById() {


    const [products, getProduct] = useState([]);   
//`${info}`
    const getProductById = (event) => {
        event.preventDefault();
        let info = document.forms["productForm"]["product"].value;
        console.log(info);
        axios.get(`https://localhost:44343/webapi/getbyidmultilayer?id=${info}`).then((response)=>{
            console.log(response.data);
            getProduct(response.data);
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
          <textarea id="product" ></textarea>
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