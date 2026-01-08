import React, { useEffect, useState } from 'react'
import { getAll } from '../services/productService';
import { useNavigate as navigate, useParams } from 'react-router-dom';


const ProductForm = () => {
    // const [product,setProduct] = useState({
    //     name:'',
    //     price:0
    // });
    // const [id,setId] = useState(null);
    const [name,setName] = useState('');
    const [price,setPrice] = useState(0);

    // const [product, setProduct] = useState({
    // const [id,setId] = useState(null);
    const { id } = useParams();

  useEffect(() => {
    console.log(id);
        if (id) {
            getAll().then(response => response.json()).then(products => {
                const editProduct = products.find(p => p.id == id);
                console.log(editProduct);
                if (editProduct){
                setName(editProduct.name);
                setPrice(editProduct.price);
                } 
            });
        }
    }, [id]);

    const handleSubmit = (e) => {   
        e.preventDefault();
        if(id){
            // Update existing product
            fetch(`https://shiny-zebra-wrp54x5jx65935rq7-5195.app.github.dev/Products/?id=${id}` ,  {
                method:'PUT',
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify({ id:id, name:name, price:price })
          })}
            else{
              fetch('https://shiny-zebra-wrp54x5jx65935rq7-5195.app.github.dev/Products' ,  {
              method:'POST',
              headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify({name:name, price:price })   
        })
    }
    
  }
  return (
    <div>
      <form onSubmit={handleSubmit} >
        {/* {console.log(product)} */}
        <label htmlFor="name">Name</label>
        <input type="text" value={name} onChange={(e) => setName( e.target.value)}/>
        <br />
        <label htmlFor="price">Price</label>
        <input type="number" value={price}  onChange={(e) => setPrice( e.target.value)}/>
        <br />

        <button type="submit">{id ? 'Update Product' : 'Add Product'}</button>
      </form>
    </div>
  )
}

export default ProductForm
