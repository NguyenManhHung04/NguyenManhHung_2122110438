import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Header from './components/user/Header';
import Banner from './components/user/Banner';
import Footer from './components/user/Footer';
import HotCategory from './components/user/layout/HotCategory';
import ProductList from './components/user/layout/ProductList';
import Login from './pages/user/Login';
import Register from './pages/user/Register';
import BrandList from './components/user/layout/BrandList';
import Contact from './pages/user/Contact';

const App: React.FC = () => {
  return (
    <Router>
      <div className="app">
        <Header />
        <main>
          <Routes>
            <Route path="/" element={
              <>
                <Banner />
                <BrandList/>
                <HotCategory />
                <ProductList />
              </>
            } />
            <Route path="/contact" element={<Contact />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
           
            {/* Thêm các route khác tại đây */}
          </Routes>
        </main>
        <Footer />
      </div>
    </Router>
  );
};

export default App;