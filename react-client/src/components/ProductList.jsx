import React, { useEffect , useState}   from 'react'
 
 
const ProductList = () => {
    const [products, setProducts] = useState([])
    useEffect(() => {
        fetch('https://shiny-fortnight-v69rw95rp5qr26974-5195.app.github.dev/Products') 
            .then(response => response.json())
            .then(data => setProducts(data))
            .catch(error => console.error('Error fetching products:', error))
    }, [])
  return (
    <div>
        <h2>Product List</h2>  
        {products.map(product => (
            <div key={product.id}>
 
                <h3>{product.id}</h3>
                <h3>{product.name}</h3>
                <p>Price: ${product.price}</p>
            </div>
        ))}
 
    </div>
  )
}
 
export default ProductList
 