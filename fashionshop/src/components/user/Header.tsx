import React from 'react';
import '../../assets/css/reset.css';
import '../../assets/css/Header.css'; // Đường dẫn đến file CSS
import logo from '../../assets/images/logo.png'; // Import hình ảnh

const Header: React.FC = () => {
  return (
    <header className="header">
      <div className="logo">
        <img src={logo} alt="Logo" /> {/* Sử dụng hình ảnh đã import */}
      </div>
      <nav className="menu">
        <a href="/">Home</a>
        <a href="#">Shop</a>
        <a href="/productlist">Features</a>
        <a href="#">Blog</a>
        <a href="#">About</a>
        <a href="/contact">Contact</a>
      </nav>
      <div className="login-register">
        <a href="/login">Login</a> {/* Sử dụng React Router Link nếu có */}
        <a href="/register">Register</a>
      </div>
    </header>
  );
};

export default Header;