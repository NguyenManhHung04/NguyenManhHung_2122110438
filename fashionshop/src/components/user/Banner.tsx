import React from 'react';
import '../../assets/css/reset.css';
import '../../assets/css/Banner.css'; // Import file CSS từ thư mục assets
import bannerImage from '../../assets/images/review.png'; // Import hình ảnh đúng cách

const Banner: React.FC = () => {
  return (
    <div className="banner">
      <div className="banner-text">
        <h4>Shirts Collection 2023</h4>
        <h2>New Arrivals</h2>
        <button>Shop now</button>
      </div>
      <div className="banner-image">
        <img src={bannerImage} alt="Banner" /> {/* Sử dụng hình ảnh đã import */}
      </div>
    </div>
  );
};

export default Banner;