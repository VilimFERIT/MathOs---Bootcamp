import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function ProductPut() {


    const [products, updateProduct] = useState([]);   

    const updateProductById = (event) => {
        event.preventDefault();
        let id = document.forms["productForm"]["product"].value;
        let price = document.forms["productForm"]["price"].value;
        axios.put('https://localhost:44343/webapi/updatePriceMla?productId='+ id + '&newPrice='+price).then((response)=>{
            console.log(response.data);
            updateProduct(response.data);
        })
        .catch(error => console.error('Error!'));
    }

      return (
        <div>
            <form name="productForm">
          <ul>
          <li>
          <textarea id="product" ></textarea>
          </li>  
          <li>
   
            <textarea id="price" ></textarea>
            </li>
          </ul>
          
          <input type="submit" onClick={updateProductById}></input>
          </form>

        <pre>
        </pre>
        </div>
  
  
      );
    }