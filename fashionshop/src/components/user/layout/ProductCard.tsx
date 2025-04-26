// src/components/layout/ProductList/ProductCard/ProductCard.tsx
import React from 'react';
import '../../../assets/css/ProductCard.css';

interface ProductCardProps {
    product: {
      id: number;
      name: string;
      price: number;
      imageUrl: string;
      categoryName: string;
      brandName: string;
    };
  }

  const ProductCard: React.FC<ProductCardProps> = ({ product }) => {
    return (
      <div className="product-card">
        <img src={product.imageUrl} alt={product.name} />
        <h3>{product.name}</h3>
        <p>${product.price.toFixed(2)}</p>
        <p>Category: {product.categoryName}</p>
        <p>Brand: {product.brandName}</p>
      </div>
    );
  };

export default ProductCard;