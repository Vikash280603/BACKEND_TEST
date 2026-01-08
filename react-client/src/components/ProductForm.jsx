import React, { useState } from 'react'

const ProductForm = () => {
    const [product,setProduct] = useState({
        name:'',
        price:0
    });

    const handleSubmit = (e) => {   
        e.preventDefault();
        fetch('https://shiny-fortnight-v69rw95rp5qr26974-5195.app.github.dev/Products' ,  {
            method:'POST',
        headers:{
            'Content-Type':'application/json'
        },
        body:JSON.stringify(product)

            
        })
    }
  return (
    <div>
      <form onSubmit={handleSubmit} method='POST'>
        <label htmlFor="name">Name</label>
        <input type="text"  onChange={(e) => setProduct({...product, name: e.target.value})}/>
        <label htmlFor="price">Price</label>
        <input type="number"  onChange={(e) => setProduct({...product, price: e.target.value})}/>

        <button type="submit">Submit</button>
      </form>
    </div>
  )
}

export default ProductForm
