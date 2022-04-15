import React, { useEffect, useState } from "react";
import axios from 'axios';

export default function Product() {


    const [products, getProducts] = useState([]);   

    const getAllProducts = () => {
        axios.get('https://localhost:44343/webapi/getallmultilayer').then((response)=>{
            //console.log(response.data);
            getProducts(response.data);
        })
        .catch(error => console.error('Error!'));
    }

      return (
        <div>
            <button onClick={getAllProducts}> Click to get all products! </button>
        <pre>
        {products.map(product=><li>{product.Price} {product.Name} {product.Id}</li>)}
        </pre>
        </div>
  
  
      );
    }