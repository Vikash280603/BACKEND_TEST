import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import ProductList from './components/ProductList'
import ProductForm from './components/ProductForm'
import { BrowserRouter , Route, Routes ,Link} from 'react-router-dom'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>

      {/* <ProductList/>
      <ProductForm/> */}
      <BrowserRouter>
      <nav>
        <Link to="/">Products</Link> 
        |
        <Link to="/create">Add Product</Link>

      </nav>
      <Routes>
        <Route path='/' element={<ProductList/>}/>
        <Route path='/create' element={<ProductForm/>}/>
        <Route path='/edit/:id' element={<ProductForm/>}/>
      </Routes>
      </BrowserRouter>

    </>
  )
}

export default App
