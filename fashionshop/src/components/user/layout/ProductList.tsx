import React, { useEffect, useState } from 'react';
import { getProducts } from '../../../api/user/productService'; // Import hàm getProducts
import ProductCard from './ProductCard';
import '../../../assets/css/ProductList.css';
import { Product } from '../../../types/Product';
const ProductList: React.FC = () => {
  const [products, setProducts] = useState<Product[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchProducts = async () => {
      try {
        const data = await getProducts(); // Gọi API để lấy danh sách sản phẩm
        setProducts(data); // Cập nhật danh sách sản phẩm
      } catch (err) {
        setError('Failed to fetch products');
        console.error(err);
      } finally {
        setLoading(false);
      }
    };

    fetchProducts();
  }, []); // Gọi API khi component load

  // Xử lý khi đang tải sản phẩm
  if (loading) return (
    <div className="loading-container">
      <div className="spinner"></div>
      <p>Loading products...</p>
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
    <section className="product-section">
      <h1 className="product-section-title">Product Overview</h1>
      <div className="product-list">
        {products.map((product) => (
          <ProductCard key={product.id} product={product} />
        ))}
      </div>
    </section>
  );
};

export default ProductList;
