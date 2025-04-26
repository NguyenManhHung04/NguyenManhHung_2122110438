import React, { useEffect, useState } from 'react';
import { getBrands } from '../../../api/user/brandService'; // Import hàm getBrands
import '../../../assets/css/BrandList.css'; // CSS cho BrandList
import { Brand } from '../../../types/Brand';

const BrandList: React.FC = () => {
  const [brands, setBrands] = useState<Brand[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchBrands = async () => {
      try {
        const data = await getBrands(); // Gọi API để lấy danh sách thương hiệu
        setBrands(data); // Cập nhật danh sách thương hiệu
      } catch (err) {
        setError('Failed to fetch brands');
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchBrands();
  }, []); // Gọi API khi component load

  // Xử lý khi đang tải thương hiệu
  if (loading) return (
    <div className="loading-container">
      <div className="spinner"></div>
      <p>Loading brands...</p>
    </div>
  );

  // Xử lý khi có lỗi
  if (error) return (
    <div className="error-container">
      <p>Error: {error}</p>
      <button onClick={() => window.location.reload()}>Retry</button>
    </div>
  );

  return (
    <section className="brand-section">
      <h1 className="brand-section-title">Brand Overview</h1>
      <div className="brand-list">
        {brands.map((brand) => (
          <div key={brand.id} className="brand-card">
            <img src={brand.imageUrl} alt={brand.name} className="brand-image" />
            <p className="brand-name">{brand.name}</p>
          </div>
        ))}
      </div>
    </section>
  );
};

export default BrandList;
