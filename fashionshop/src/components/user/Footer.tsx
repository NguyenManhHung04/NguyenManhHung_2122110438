import React from 'react';
import '../../assets/css/reset.css';
import '../../assets/css/Footer.css';; // Import CSS từ thư mục assets

const Footer: React.FC = () => {
  return (
    <footer className="site-footer">
      <div className="footer-container">
        {/* List category */}
        <div className="footer-section">
          <h3>Category</h3>
          <ul className="footer-links">
            <li>
              <a href="#">Women</a>
            </li>
            <li>
              <a href="#">Men</a>
            </li>
            <li>
              <a href="#">Shoes</a>
            </li>
            <li>
              <a href="#">Watches</a>
            </li>
          </ul>
        </div>

        {/* Help */}
        <div className="footer-section">
          <h3>Help</h3>
          <ul className="footer-links">
            <li>
              <a href="#">Track order</a>
            </li>
            <li>
              <a href="#">Returns</a>
            </li>
            <li>
              <a href="#">Shipping</a>
            </li>
            <li>
              <a href="#">FAQs</a>
            </li>
          </ul>
        </div>

        {/* Address */}
        <div className="footer-section">
          <h3>Address</h3>
          <ul className="footer-info">
            <li>
              Address: 28 white Lower, Street Name, <br />
              New York City, USA
            </li>
            <li>Telephone: +91.0986.987</li>
            <li>
              Email: <a href="mailto:info@gmail.com">info@gmail.com</a>
            </li>
          </ul>
        </div>

        {/* Network */}
        <div className="footer-section">
          <h3>Social Network</h3>
          <ul className="social-links">
            <li>
              <a href="http://youtube.com" target="_blank" rel="noopener noreferrer">Youtube</a>
            </li>
            <li>
              <a href="#" target="_blank" rel="noopener noreferrer">Facebook</a>
            </li>
            <li>
              <a href="#" target="_blank" rel="noopener noreferrer">Twitter</a>
            </li>
          </ul>
        </div>
      </div>
    </footer>
  );
};

export default Footer;